using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_omdb
{
    public partial class Omdb_main : Form
    {
        int Nselected = 1;
        int pNselected = 1;
        int Build = 10240; //Versione soglia build Windows. In questo caso la prima RTM W10
        Button[] buttons;
        Control[] BoldControls;
        Control[] LiteControls;
        Control[] RegularControls;
        string CurrentSearchString;
        Stopwatch timer = new Stopwatch();

        #if !__MonoCS__
        [DllImport("gdi32.dll")] //questa Dll contiene le basi della grafica di Windows, tra cui l'allocamento in memoria dei font che serve a me. Non esiste in ambienti diversi da API Win32
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts); 
        #endif

        static string KEY = "&apikey=InsertYourApiKeyHere"; //La mia key. 
        HttpClient client; 
        SearchResult searchResult;
        FontFamily AmazonEmber_Rg; //<--La diachiaarazione dei tre font
        FontFamily AmazonEmber_Lt; //<---' |
        FontFamily AmazonEmber_Bd; //<-----'

        public Omdb_main()
        {
            InitializeComponent();
            buttons = new Button[5] { b_1, b_2, b_3, b_4, b_5 };
            BoldControls = new Control[21] { desc_m_1, desc_m_2, desc_m_3, desc_1, desc_2, desc_3, desc_4, desc_5, desc_6, desc_7, desc_8, desc_9, desc_10, desc_11, desc_12, desc_13, desc_14, desc_15, desc_16, desc_17, desc_18 };
            LiteControls = new Control[23] { search, ricerca, title, year, rated, released, runtime, genre, searchtitle, searchyear, searchtype, director, writer, type, boxoffice, country, language, awards, dvd, production, metascore, actors, plot };
            RegularControls = new Control[7] { generic, details, b_1, b_2, b_3, b_4, b_5 };

            CheckForIllegalCrossThreadCalls = false;
            poster_Resize(new object(), new EventArgs());
            UpdateColor();

            #if !__MonoCS__
            if (Environment.OSVersion.Version.Build > Build) //Su Win7 si sono verificati problemi con i custom font. Per evitare crash sulla piattaforma in questione, disabilito previo controllo
            {
                AmazonEmber_Rg = InitCustomFont(Properties.Resources.AmazonEmber_Rg); //<--Inizializzo i tre font
                AmazonEmber_Lt = InitCustomFont(Properties.Resources.AmazonEmber_Lt); //<---' |
                AmazonEmber_Bd = InitCustomFont(Properties.Resources.AmazonEmber_Bd); //<-----'

                foreach (var control in BoldControls) //Applico il font bold sui controlli segnalati come tali
                {
                    control.Font = new Font(AmazonEmber_Bd, control.Font.Size);
                }
                foreach (var control in LiteControls) //Applico il font lite sui controlli segnalati come tali
                {
                    control.Font = new Font(AmazonEmber_Lt, control.Font.Size);
                }
                foreach (var control in RegularControls) //Applico il font regolari sui controlli segnalati come tali
                {
                    control.Font = new Font(AmazonEmber_Rg, control.Font.Size);
                }
            }
            else //workaround con font Predifiniti sans serif per tutte le macchine con OS diverso da Windows con build maggiore di quella definita
            #endif
            {
                foreach (var control in BoldControls)
                {
                    control.Font = new Font(FontFamily.GenericSansSerif, control.Font.Size, FontStyle.Bold);
                }
                foreach (var control in LiteControls) //Non avendo font lite by fontstyle, li tratto come regualar
                {
                    control.Font = new Font(FontFamily.GenericSansSerif, control.Font.Size);
                }
                foreach (var control in RegularControls)
                {
                    control.Font = new Font(FontFamily.GenericSansSerif, control.Font.Size);
                }
            }
            label_MouseLeave(generic, new EventArgs());
            Nav_Buttons();
        }

        protected override void OnClosed(EventArgs e) //ammesso che la chiusura non sia forzata o di un crash, all'uscita salvo le impostazioni e memorizzo colori e stili.
        {
            Properties.Settings.Default.Save();
            base.OnClosed(e);
        }

        void UpdateBarColor() //rende effettivo il colore scelto per il bar color
        {
            Bitmap bitmap = Properties.Resources.search_left;
            Bitmap bitmap2 = Properties.Resources.search_right;
            ChangeColor(bitmap, Color.Black, Properties.Settings.Default.barColor);
            ChangeColor(bitmap2, Color.Black, Properties.Settings.Default.barColor);
            pictureBox5.Image = bitmap;
            search.BackgroundImage = bitmap2;
            pictureBox4.BackColor = Properties.Settings.Default.barColor;
            generic.BackColor = Properties.Settings.Default.barColor;
            details.BackColor = Properties.Settings.Default.barColor;
            pictureBox3.BackColor = Properties.Settings.Default.barColor;
        }

        void UpdateBackColor() //rende effettivo il colore scelto per il back color
        {
            Color color = WhiteOrBlack(Properties.Settings.Default.backColor);
            poster.BackColor = Properties.Settings.Default.backColor;
            BackColor = Properties.Settings.Default.backColor;
            detail.BackColor = Properties.Settings.Default.backColor;
            detail.ForeColor = color;
            main.BackColor = Properties.Settings.Default.backColor;
            main.ForeColor = color;

            Bitmap bitmap = Properties.Resources.list_top;
            Bitmap bitmap2 = Properties.Resources.list_bottom;
            ChangeColor(bitmap, Color.Black, Properties.Settings.Default.backColor);
            ChangeColor(bitmap2, Color.Black, Properties.Settings.Default.backColor);
            pictureBox1.BackgroundImage = bitmap;
            pictureBox1.BackColor = Properties.Settings.Default.listColor;
            pictureBox2.BackgroundImage = bitmap2;
        }

        void colorError(string hex) //semplice msgbox di errore, funzionalizzata per ripetitività
        {
            MessageBox.Show("Colore o HEX non valido: " + hex, "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //permette di cambiare i colori in runtime. E' sufficiente scrivere ad esempio color=Pink o color=#AA4521
        void UpdateColor(string Command)
        {
            Command = Command.ToLower();
            if (Command.Contains("color="))
            {
                if (Command.Contains("=default"))
                {
                    switch(Command.Replace("=default",""))
                    {
                        case "color":
                            Properties.Settings.Default.customColor = Color.DarkOrange;
                            search.BackColor = Properties.Settings.Default.customColor;
                            Properties.Settings.Default.foreColor = Color.Black;
                            search.Image = Properties.Resources.search_icon;
                            break;
                        case "barcolor":
                            Properties.Settings.Default.barColor = Color.DimGray;
                            break;
                        case "backcolor":
                            Properties.Settings.Default.backColor = Color.DarkGray;
                            break;
                        case "listcolor":
                            Properties.Settings.Default.listColor = Color.Silver;
                            break;
                    }
                }
                else if (Command.Substring(0, 4) == "back") //backcolor
                {
                    string hex = Command.Remove(0, 10);
                    try
                    {
                        Properties.Settings.Default.backColor = ColorTranslator.FromHtml(hex);
                    }
                    catch
                    {
                        colorError(hex);
                        return;
                    }
                    if (Properties.Settings.Default.backColor.A < 255)
                    {
                        Properties.Settings.Default.backColor = Color.FromArgb(255, Properties.Settings.Default.backColor);
                    }
                }
                else if (Command.Substring(0, 4) == "list") //listcolor
                {
                    string hex = Command.Remove(0, 10);
                    try
                    {
                        Properties.Settings.Default.listColor = ColorTranslator.FromHtml(hex);
                    }
                    catch
                    {
                        colorError(hex);
                        return;
                    }
                    if (Properties.Settings.Default.backColor.A < 255)
                    {
                        Properties.Settings.Default.listColor = Color.FromArgb(255, Properties.Settings.Default.backColor);
                    }
                }
                else if (Command.Substring(0, 3) != "bar") //color
                {
                    string hex = Command.Remove(0, 6);
                    try
                    {
                        Properties.Settings.Default.customColor = ColorTranslator.FromHtml(hex);
                    }
                    catch
                    {
                        colorError(hex);
                        return;
                    }
                    if (Properties.Settings.Default.customColor.A < 255)
                    {
                        Properties.Settings.Default.customColor = Color.FromArgb(255, Properties.Settings.Default.customColor);
                    }
                    Properties.Settings.Default.foreColor = WhiteOrBlack(Properties.Settings.Default.customColor);
                }
                else //barcolor
                {
                    string hex = Command.Remove(0, 9);
                    try
                    {
                        Properties.Settings.Default.barColor = ColorTranslator.FromHtml(hex);
                    }
                    catch
                    {
                        colorError(hex);
                        return;
                    }
                    if (Properties.Settings.Default.barColor.A < 255)
                    {
                        Properties.Settings.Default.barColor = Color.FromArgb(255, Properties.Settings.Default.barColor);
                    }
                }
            }
            else if (Command.Contains("style=")) //stili
            {
                if (Command.Contains("savestyle=")) //salva gli stili con la conf di colori corrente
                {
                    Properties.Settings.Default.styles += "-" + Command.Remove(0, 10).ToLower() + ";" + ColorTranslator.ToHtml(Properties.Settings.Default.customColor) + "," + ColorTranslator.ToHtml(Properties.Settings.Default.foreColor) + "," + ColorTranslator.ToHtml(Properties.Settings.Default.barColor) + "," + ColorTranslator.ToHtml(Properties.Settings.Default.backColor) + "," + ColorTranslator.ToHtml(Properties.Settings.Default.listColor);
                    MessageBox.Show("Stile salvato come '" + Command.Remove(0, 10).ToLower() + "'.");
                }
                else if (Command.Contains("deletestyle=")) //elimina uno stile con il nome specificato e ricrea la "lista" stili
                {
                    string temp = "";
                    string todelete = Command.Remove(0, 12).ToLower();

                    string[] lines = Properties.Settings.Default.styles.Split('-');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string currentLine1 = lines[i];
                        string[] couple = currentLine1.Split(';');
                        if (couple[0] != todelete)
                        {
                            temp += "-" + lines[i];
                        }
                    }
                    temp.Remove(0, 1);
                    Properties.Settings.Default.styles = temp; 
                    MessageBox.Show("Stile eliminato: '" + todelete + "'.");
                }
                else //applica uno stile
                {
                    string style = Command.Remove(0, 6).ToLower();
                    string[] lines = Properties.Settings.Default.styles.Split('-');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string currentLine1 = lines[i];
                        string[] couple = currentLine1.Split(';');
                        if (couple[0] == style)
                        {
                            ChangeStyle(couple[1]);
                        }
                    }
                }
            }
            UpdateColor(); //rende effettivi i colori scelti
        }

        void ChangeStyle(string colors) //parte dell'interprete degli stili
        {
            string[] colorList = colors.Split(',');
            Properties.Settings.Default.customColor = ColorTranslator.FromHtml(colorList[0]);
            Properties.Settings.Default.foreColor = ColorTranslator.FromHtml(colorList[1]);
            Properties.Settings.Default.barColor = ColorTranslator.FromHtml(colorList[2]);
            Properties.Settings.Default.backColor = ColorTranslator.FromHtml(colorList[3]);
            Properties.Settings.Default.listColor = ColorTranslator.FromHtml(colorList[4]);
        }

        void UpdateColor() //rende effettivi i colori scelti applicandoli
        {
            if (Properties.Settings.Default.foreColor == Color.Black) // il colore che risalta meglio sul barcolor è nero in questo caso
            {
                search.Image = Properties.Resources.search_icon; //l'immagine della lente è già nera. caricala così
            }
            else //in questo caso il colore che risalta meglio sul barcolor è bianco 
            {
                Bitmap bitmap = new Bitmap(Properties.Resources.search_icon); //l'immagine della lente decve diventare bianca. Carico in obj bitmap
                Invert(bitmap); //Inverto i colori della bitmap
                search.Image = bitmap; //carico la bitmap invertita
            }
            search.BackColor = Properties.Settings.Default.customColor;
            UpdateBackColor();
            UpdateBarColor();
            panel1.BackColor = Properties.Settings.Default.listColor;
            searchlist.BackColor = Properties.Settings.Default.listColor;
            int all = GetAll();
            edit(Nselected, all);
            searchlist.Focus();
        }

        //Le bitmap che ho creato sono modulari con canale alpha. Tendenzialmente sono fatte perchè la parte disegnata in nero possa essere sostituita con qualsiasi colore.
        //La funzione qua che ho creato è più generica e accetta anche altri colori come oldcolor oltre al nero, ma non si sa mai che potrebbe servire in futuro, per cui lo lascio più modulare
        void ChangeColor(Bitmap bitmapImage, Color oldColor, Color newColor)
        {
            var bitmapRead = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            var bitmapLength = bitmapRead.Stride * bitmapRead.Height;
            var BGRA = new byte[bitmapLength];
            Marshal.Copy(bitmapRead.Scan0, BGRA, 0, bitmapLength);
            bitmapImage.UnlockBits(bitmapRead);

            for (int i = 0; i < bitmapLength; i += 4)
            {
                if (BGRA[i + 2] == oldColor.R && BGRA[i + 1] == oldColor.G && BGRA[i] == oldColor.B)
                {
                    BGRA[i] = newColor.B;
                    BGRA[i + 1] = newColor.G;
                    BGRA[i + 2] = newColor.R;
                }
            }

            var bitmapWrite = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(BGRA, 0, bitmapWrite.Scan0, bitmapLength);
            bitmapImage.UnlockBits(bitmapWrite);
        }

        //molte immagini sono monocromatiche con canale alpha: questo permette loro che se sono nere possono anche diventare bianche senza magheggi troppo compplicati e soprattutto senza tenere un'altra copia dell'immagine del colore opposto intagrata nel progetto.
        //questo mi consente di tenere molte meno immagini (in questo caso ben 5 in meno) integrate nel progetto. Il dover invertire consuma però tempo di CPU, quindi questa funzione usa UnlockBits e non GetPixel e SetPixel, che blocca e sblocca per ogni singolo pixel.
        //diventa quindi innegabile che così è più comodo, in quanto serve un processore davvero stupido per invertire i colori e si spreca meno RAM e memoria occupata per gli eseguibili.
        //Se il mio obiettivo fosse di rendere il programma ancora più leggero spazio parlando, farei un giro di OptiPNG su ogni PNG e poi una compressione con UPX, ma è superfluo, il vero motivo per cui uso UnlockBits invece di Get e Set Pixel è che li odio.
        public static void Invert(Bitmap bitmapImage)
        {
            var bitmapRead = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            var bitmapLength = bitmapRead.Stride * bitmapRead.Height;
            var bitmapBGRA = new byte[bitmapLength];
            Marshal.Copy(bitmapRead.Scan0, bitmapBGRA, 0, bitmapLength);
            bitmapImage.UnlockBits(bitmapRead);

            for (int i = 0; i < bitmapLength; i += 4)
            {
                bitmapBGRA[i] = (byte)(255 - bitmapBGRA[i]);
                bitmapBGRA[i + 1] = (byte)(255 - bitmapBGRA[i + 1]);
                bitmapBGRA[i + 2] = (byte)(255 - bitmapBGRA[i + 2]);
                //        [i + 3] = ALPHA.
            }

            var bitmapWrite = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
            Marshal.Copy(bitmapBGRA, 0, bitmapWrite.Scan0, bitmapLength);
            bitmapImage.UnlockBits(bitmapWrite);
        }

        //determina sul colore passato se risalta meglio il bianco o il nero
        Color WhiteOrBlack(Color c)
        {
            return (int)Math.Sqrt(c.R * c.R * .299 + c.G * c.G * .587 + c.B * c.B * .114) > 130 ? Color.Black : Color.White;
        }

        //resetta la connessione dell'oggetto client. Così facendo si può aprire una nuova connessione
        void ClientReset()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://www.omdbapi.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //svuota la listbox SearchList e la riempie con i nuovi dati SearchResult
        void UpdateSearchList()
        {
            searchlist.Items.Clear(); //ripulire significa anche cambiare il SelectedIndex a -1. Questo scatena in modo non voluto gli eventi DrawItem e SelectedIndexChanged.
            searchlist.Items.AddRange(searchResult.Search.ToArray());
            searchlist.SelectedIndex = 0;
            searchlist.Focus();
        }

        #if !__MonoCS__
        //Inizializza un nuovo font richiamabile da codice senza installarlo nel sistema a partire da un file ttf presente nelle risorse del progetto.
        //Non applicabile (almeno non con la Dll che ho importato, penso ci sia un suo Shared Object equivalente) su Linux/Mac.
        FontFamily InitCustomFont(byte[] font)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = font.Length;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(font, 0, data, fontLength);
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)font.Length, IntPtr.Zero, ref cFonts);
            pfc.AddMemoryFont(data, fontLength);
            //Marshal.FreeCoTaskMem(data);
            return pfc.Families[0];
        }
        #endif

        //se nella ricerca c'è un uguale arriviamo qui: gestiamo colore, stile e schermo intero.
        void CommandProcessor(string command)
        {
            if(command.ToLower().Contains("color=") || command.ToLower().Contains("style="))
            {
                UpdateColor(command);
            }
            else if (command.ToLower().Contains("fullscreen="))
            {
                command = command.Remove(0, 11);
                if (command=="1" || command=="true")
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
                else if (command == "0" || command == "false")
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        //Evento scatenato dal click del pulsante cerca o dal tasto invio all'interno della textbox di ricerca
        private async void search_Click(object sender, EventArgs e)
        {
            if(ricerca.Text.Contains("="))
            {
                CommandProcessor(ricerca.Text);
            }
            else
            {
                ClientReset();
                try
                {
                    ClearCurrentSearchString();
                    searchResult = await GetSearchResultAsync("?s=" + CurrentSearchString + KEY);
                    UpdateSearchList();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                Nselected = 1;
                Nav_Buttons();
            }
        }

        //Modifica la stringa di ricerca rimuovendo gli spazi in eccesso alla fine, trasformando quelli all'interno in + e rimuovendo le &
        void ClearCurrentSearchString()
        {
            CurrentSearchString = ricerca.Text.Replace(" ", "+");
            CurrentSearchString = CurrentSearchString.Replace("&", "");
            while (CurrentSearchString[CurrentSearchString.Length - 1] == '+')
            {
                CurrentSearchString = CurrentSearchString.Substring(0, CurrentSearchString.Length - 1);
            }
            CurrentSearchString = System.Text.RegularExpressions.Regex.Replace(CurrentSearchString, @"\++", "+");
        }
        
        //Ottiene a partire da un url contenente il relativo JSON un oggetto di tipo Movie
        async Task<Movie> GetMovieAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<Movie>() : null;
        }

        //Ottiene a partire da un url contenente il relativo JSON un oggetto di tipo SearchResult
        async Task<SearchResult> GetSearchResultAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<SearchResult>() : null;
        }

        private void searchlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = searchlist.SelectedIndex;
            if (i != -1)
            {
                generic_click(sender, e);
                if (searchResult != null)
                {
                    if (searchResult.Search[i].Poster != "N/A")
                    {
                        poster.ImageLocation = searchResult.Search[i].Poster;
                    }
                    else
                    {
                        poster.Image = Properties.Resources.no_img;
                    }
                    searchtitle.Text = searchResult.Search[i].Title;
                    searchyear.Text = searchResult.Search[i].Year;
                    searchtype.Text = searchResult.Search[i].Type;
                }
            }
        }

        //L'immagine si adatta alle dimensioni della finestra e smette di ingrandire quando sgranerebbe.
        private void poster_Resize(object sender, EventArgs e)
        {
            int h = poster.Size.Height;
            int x = poster.Location.X;
            double rapporto = h / 380.0;
            poster.Size = new Size((int)(300 * rapporto), h);
            main.Location = new Point(x + (int)(300 * rapporto), main.Location.Y); //le dimensioni di questo panel e del successiovo sono gestite a mano e non da un anchor per motivi di risultati sgraditi nei cambiamenti di stato
            detail.Location = main.Location;
        }

        private void searchlist_DrawItem(object sender, DrawItemEventArgs e)
        {
            int ItemMargin = 5;
            //Ottieni la lista di elementi a partire dalla listbox
            var lst = (sender as ListBox).Items;
            Color localForeColor;
            if (lst.Count > 0 && (sender as ListBox).SelectedIndex != -1)
            {
                Search currentList = (Search)lst[e.Index];

                //Sceglie immagine
                e.DrawBackground();
                Bitmap Image = new Bitmap(50, 50);
                switch (currentList.Type)
                {
                    case "series":
                        Image = Properties.Resources.series_icon;
                        break;
                    case "movie":
                        Image = Properties.Resources.movie_icon;
                        break;
                    case "episode":
                        Image = Properties.Resources.episode_icon;
                        break;
                    case "game":
                        Image = Properties.Resources.game_icon;
                        break;
                }

                //Verifica se l'elemento è selezionato
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    Graphics g = e.Graphics;
                    g.FillRectangle(new SolidBrush(Properties.Settings.Default.customColor), e.Bounds);
                    localForeColor = Properties.Settings.Default.foreColor;
                }
                else
                {
                    localForeColor = WhiteOrBlack(Properties.Settings.Default.listColor);
                }
                if (localForeColor == Color.White)
                {
                    Invert(Image);
                }

                //Disegna l'immagine
                Rectangle source_rect = new Rectangle(0, 0, 50, 50);
                Rectangle dest_rect = new Rectangle(ItemMargin, e.Bounds.Top + ItemMargin, 50, 50);
                e.Graphics.DrawImage(Image, dest_rect, source_rect, GraphicsUnit.Pixel);

                //Trova l'area dove scrivere il testo.
                Rectangle layout_rect = new Rectangle(65, e.Bounds.Top + ItemMargin, 262, 19);

                //Disegna il testo.
                e.Graphics.DrawString(currentList.Title, new Font((Environment.OSVersion.Version.Build > Build) ? AmazonEmber_Lt : FontFamily.GenericSansSerif, 11), new SolidBrush(localForeColor), layout_rect);
            }
        }

        //Hover entrata su label. Sgrigisce e sottolinea
        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.LightGray;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }

        //Hover uscita su label. sbianca e desottolinea
        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.White;
            label.Font = new Font(label.Font, label.Text[label.Text.Length - 1] == '&' ? FontStyle.Underline : FontStyle.Regular);
        }

        //Intercetta i tasti premuti e se è invio simula il click del tasto search
        private void ricerca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                search_Click(sender, e);
            }
        }

        //click sulla panoramica
        private void generic_click(object sender, EventArgs e)
        {
            if (generic.Text[generic.Text.Length - 1] != '&')
            {
                generic.Text = generic.Text + "&";
                details.Text = details.Text.Substring(0, details.Text.Length - 1);
                details.Font = new Font(details.Font, FontStyle.Regular);
                generic.Font = new Font(generic.Font, FontStyle.Underline);
                main.Visible = true;
                detail.Visible = false;
            }
        }

        //click sui dettagli
        private async void details_Click(object sender, EventArgs e)
        {
            if (details.Text[details.Text.Length - 1] != '&')
            {
                details.Text = details.Text + "&";
                generic.Text = generic.Text.Substring(0, generic.Text.Length - 1);
                generic.Font = new Font(generic.Font, FontStyle.Regular);
                details.Font = new Font(details.Font, FontStyle.Underline);
                ClientReset();

                try
                {
                    var imdbID = searchResult.Search[searchlist.SelectedIndex].imdbID;
                    Movie movie = await GetMovieAsync("?i=" + imdbID + KEY);
                    title.Text = movie.Title;
                    year.Text = movie.Year;
                    rated.Text = movie.Rated;
                    released.Text = movie.Released;
                    runtime.Text = movie.Runtime;
                    genre.Text = movie.Genre;
                    director.Text = movie.Director;
                    writer.Text = movie.Writer;
                    boxoffice.Text = movie.BoxOffice;
                    type.Text = movie.Type;
                    language.Text = movie.Language;
                    country.Text = movie.Country;
                    production.Text = movie.Production;
                    dvd.Text = movie.DVD;
                    metascore.Text = movie.Metascore;
                    awards.Text = movie.Awards;
                    actors.Text = movie.Actors;
                    plot.Text = movie.Plot;
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }
                main.Visible = false;
                detail.Visible = true;
            }
        }

        //fa parte della gestione dei pulsanti delle pagine
        void reset_border_size()
        {
            Color BW = WhiteOrBlack(Properties.Settings.Default.barColor);
            foreach (var button in buttons)
            {
                Bitmap bitmap = Properties.Resources.page_button;
                ChangeColor(bitmap, Color.Black, Properties.Settings.Default.backColor);
                button.BackgroundImage = bitmap;
                button.BackColor = Properties.Settings.Default.barColor;
                button.ForeColor = BW;
                button.FlatAppearance.MouseDownBackColor = Color.DimGray;
            }
        }

        //quando uno dei pulsanti della gestione delle pagine corrisponde a quello della pag selezionata allora è "selezionato": cambia colori e altro
        void set_selected(Button button)
        {
            button.BackColor = Properties.Settings.Default.customColor;
            button.ForeColor = Properties.Settings.Default.foreColor;
            button.FlatAppearance.MouseDownBackColor = search.FlatAppearance.MouseDownBackColor;
        }

        //Definisce il contenuto stringa dei 5 pulsanti delle pagine
        void generate(int from, int lenght)
        {
            for (int i = from; i < from + lenght; i++)
            {
                buttons[i].Text = (i == from) ? "<" : (i == from + lenght - 1) ? ">" : (i - from).ToString();
            }
        }

        void edit(int selected, int total)
        {
            reset_border_size();
            if (total <= 3)
            {
                buttons[0].Visible = total == 3;
                buttons[4].Visible = total != 1;
                switch (total)
                {
                    case 1:
                        generate(1, 3);
                        set_selected(buttons[2]);
                        break;
                    case 2:
                        generate(1, 4);
                        set_selected(buttons[selected + 1]);
                        break;
                    case 3:
                        generate(0, 5);
                        set_selected(buttons[selected]);
                        break;
                }
            }
            else
            {
                if (selected <= 2)
                {
                    set_selected(buttons[selected]);
                    buttons[1].Text = "1";
                    buttons[2].Text = "2";
                    buttons[3].Text = "...";
                }
                else
                {
                    buttons[1].Text = "...";
                    if (selected == total)
                    {
                        set_selected(buttons[3]);
                        buttons[2].Text = (selected - 1).ToString();
                        buttons[3].Text = selected.ToString();
                    }
                    else
                    {
                        set_selected(buttons[2]);
                        buttons[2].Text = selected.ToString();
                        buttons[3].Text = (selected + 1 == total) ? (selected + 1).ToString() : "...";
                    }
                }
                buttons[0].Visible = true;
                buttons[4].Visible = true;
                buttons[0].Text = "<";
                buttons[4].Text = ">";
            }
        }

        //Ricava il numero totale di numero di pagine. E' anche incaricato di dare avviso se la ricerca non da risultati
        int GetAll()
        {
            int all = 1;
            if (searchResult != null)
            {
                if (searchResult.totalResults == null)
                {
                    MessageBox.Show("Nessun risultato trovato", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                all = int.Parse(searchResult.totalResults) / 10;
            }
            return all;
        }

        //Click su uno dei 5 pulsaanti per la navigazione delle pagine
        private async void nav_click(object sender, EventArgs e)
        {
            int all = GetAll();
            string name = (sender as Button).Text;
            if (name == ">" || name == "<")
            {
                pNselected = Nselected;
                Nselected += (name == ">" && Nselected < all) ? 1 : (name == "<" && Nselected > 1) ? -1 : 0;
            }
            else if (name != "...")
            {
                pNselected = Nselected;
                Nselected = int.Parse(name);
            }
            if (CurrentSearchString != "" && pNselected != Nselected)
            {
                ClientReset();
                edit(Nselected, all);
                searchResult = await GetSearchResultAsync("?s=" + CurrentSearchString + "&page=" + Nselected + KEY);
                UpdateSearchList();
            }
        }

        void Nav_Buttons()
        {
            int all = GetAll();
            if (Nselected <= all)
            {
                if (Nselected >= 1)
                {
                    edit(Nselected, all);
                }
                else
                {
                    Nselected = 1;
                }
            }
            else
            {
                Nselected = all;
            }
        }

        //evento invocato dalla pressione di un tasto all'interno della listbox. Il codice contenuto permette di far gestire i tasti freccia destra e sinistra in modo disverso dal default.
        private void searchlist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                e.Handled = true;
                if (!timer.IsRunning) //usato per determinare la pressione prolungata
                {
                    timer.Reset();
                    timer.Start();
                }
            }
        }

        //questo evento si scatenza appena un tasto è finito di premere. Con questo evento possiam oquindi gestire i tasti freccia destra e sinistra come vogliamo
        private async void searchlist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                pNselected = Nselected;
                Nselected += e.KeyCode == Keys.Right ? 1 : -1;

                Nav_Buttons();
                if (!await longPress(e.KeyCode == Keys.Right ? ">" : "<")) //usato per determinare la pressione prolungata
                {
                    if (CurrentSearchString != "" && pNselected != Nselected)
                    {
                        ClientReset();
                        searchResult = await GetSearchResultAsync("?s=" + CurrentSearchString + "&page=" + Nselected + KEY);
                        UpdateSearchList();
                    }
                }
            }
        }

        //quando la finestra si ridimensiona bisogna ridimensionare anche aaltre cose a mano
        private void Omdb_main_Resize(object sender, EventArgs e)
        {
            detail.Size = new Size(Size.Width - detail.Location.X, Size.Height - detail.Location.Y);
            main.Size = detail.Size;
            poster_Resize(sender, e);
        }

        //evento usato per determinare la pressione prolungata
        private void btn_mouseDown(object sender, MouseEventArgs e)
        {
            if (!timer.IsRunning)
            {
                timer.Reset();
                timer.Start();
            }
        }

        //pressione prolungata. Si applica ai pulsanti freccia dx e sx sia fisici che virtuali. la press. prolung. a dx porta all'ultima pag., quella sx alla prima.
        async Task<bool> longPress(string name)
        {
            if (timer.IsRunning)
            {
                timer.Stop();
                if (timer.ElapsedMilliseconds > 450 && (name == ">" || name == "<"))
                {
                    int all = GetAll();
                    pNselected = Nselected;
                    Nselected = (name == ">") ? all : 1;
                    if (CurrentSearchString != "" && pNselected != Nselected)
                    {
                        ClientReset();
                        edit(Nselected, all);
                        searchResult = await GetSearchResultAsync("?s=" + CurrentSearchString + "&page=" + Nselected + KEY);
                        UpdateSearchList();
                    }
                    return true;
                }
            }
            return false;
        }

        //evento usato per determinare la pressione prolungata
        private async void btn_mouseUp(object sender, MouseEventArgs e)
        {
            await longPress((sender as Button).Text);
        }
    }
}