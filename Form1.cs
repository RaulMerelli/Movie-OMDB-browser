using System;
using System.Collections.Generic;
using System.Drawing;
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
        Button[] buttons;
        string CurrentSearchString;
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        static string KEY = "&apikey=2405655c";
        HttpClient client = new HttpClient();
        SearchResult searchResult;
        FontFamily AmazonEmber_Rg;
        FontFamily AmazonEmber_Lt;
        FontFamily AmazonEmber_Bd;

        public Omdb_main()
        {
            InitializeComponent();
            buttons = new Button[5] { b_1, b_2, b_3, b_4, b_5 };
            CheckForIllegalCrossThreadCalls = false;
            AmazonEmber_Rg = InitCustomFont(Properties.Resources.AmazonEmber_Rg);
            AmazonEmber_Lt = InitCustomFont(Properties.Resources.AmazonEmber_Lt);
            AmazonEmber_Bd = InitCustomFont(Properties.Resources.AmazonEmber_Bd);

            label4.Font = new Font(AmazonEmber_Bd, label4.Font.Size);
            label5.Font = new Font(AmazonEmber_Bd, label5.Font.Size);
            label6.Font = new Font(AmazonEmber_Bd, label6.Font.Size);
            label7.Font = new Font(AmazonEmber_Bd, label7.Font.Size);
            label8.Font = new Font(AmazonEmber_Bd, label8.Font.Size);
            label2.Font = new Font(AmazonEmber_Bd, label2.Font.Size);
            generic.Font = new Font(AmazonEmber_Bd, generic.Font.Size, FontStyle.Underline);
            details.Font = new Font(AmazonEmber_Bd, details.Font.Size);
            search.Font = new Font(AmazonEmber_Lt, search.Font.Size);
            ricerca.Font = new Font(AmazonEmber_Lt, ricerca.Font.Size);
            title.Font = new Font(AmazonEmber_Lt, title.Font.Size);
            year.Font = new Font(AmazonEmber_Lt, year.Font.Size);
            rated.Font = new Font(AmazonEmber_Lt, rated.Font.Size);
            searchtitle.Font = new Font(AmazonEmber_Lt, searchtitle.Font.Size);
            searchyear.Font = new Font(AmazonEmber_Lt, searchyear.Font.Size);
            searchtype.Font = new Font(AmazonEmber_Lt, searchtype.Font.Size);

            Nav_Buttons();
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

        //Inizializza un nuovo font richiamabile da codice senza installarlo nel sistema a partire da un file ttf presente nelle risorse del progetto
        FontFamily InitCustomFont(byte[] font)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = font.Length;
            byte[] fontdata = font;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);
            pfc.AddMemoryFont(data, fontLength);
            //Marshal.FreeCoTaskMem(data);
            return pfc.Families[0];
        }

        //Evento scatenato dal click del pulsante cerca o dal tasto invio all'interno della textbox di ricerca
        private async void search_Click(object sender, EventArgs e)
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

        //Modifica la stringa di ricerca rimuovendo gli spazi in eccesso alla fine, trasformando quelli all'interno in + e rimuovendo le &
        void ClearCurrentSearchString()
        {
            CurrentSearchString = ricerca.Text.Replace(" ", "+");
            CurrentSearchString = CurrentSearchString.Replace("&", "");
            while (CurrentSearchString[CurrentSearchString.Length - 1] == '+')
            {
                CurrentSearchString = CurrentSearchString.Substring(0, CurrentSearchString.Length - 1);
            }
        }
        
        //Ottiene a partire da un url contenente il relativo JSON un oggetto di tipo Movie
        async Task<Movie> GetMovieAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Movie>();
            }
            return null;
        }

        //Ottiene a partire da un url contenente il relativo JSON un oggetto di tipo SearchResult
        async Task<SearchResult> GetSearchResultAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult>();
            }
            return null;
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

        private void poster_Resize(object sender, EventArgs e)
        {
            int h = poster.Size.Height;
            int x = poster.Location.X;
            double rapporto = h / 380.0;
            poster.Size = new Size((int)(300 * rapporto), h);
            main.Location = new Point(x + (int)(300 * rapporto), main.Location.Y);
            detail.Location = main.Location;
        }

        private void searchlist_DrawItem(object sender, DrawItemEventArgs e)
        {
            int ItemMargin = 5;
            //Ottieni la lista di elementi a partire dalla listbox
            var lst = (sender as ListBox).Items;
            if (lst.Count > 0 && (sender as ListBox).SelectedIndex != -1)
            {
                Search currentList = (Search)lst[e.Index];

                //Disegna lo sfondo
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
                    SolidBrush backgroundColorBrush = new SolidBrush(Color.DarkOrange);
                    g.FillRectangle(backgroundColorBrush, e.Bounds);
                }

                //Disegna l'immagine
                Rectangle source_rect = new Rectangle(0, 0, 50, 50);
                Rectangle dest_rect = new Rectangle(ItemMargin, e.Bounds.Top + ItemMargin, 50, 50);
                e.Graphics.DrawImage(Image, dest_rect, source_rect, GraphicsUnit.Pixel);

                //Trova l'area dove scrivere il testo.
                Rectangle layout_rect = new Rectangle(65, e.Bounds.Top + ItemMargin, 262, 19);

                //Disegna il testo.
                e.Graphics.DrawString(currentList.Title, new Font(AmazonEmber_Lt, 11), new SolidBrush(Color.Black), layout_rect);
            }
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.LightGray;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }

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
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }
                main.Visible = false;
                detail.Visible = true;
            }
        }

        void reset_border_size()
        {
            foreach (var button in buttons)
            {
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.Gray;
                button.ForeColor = Color.White;
                button.FlatAppearance.MouseDownBackColor = Color.DimGray;
            }
        }

        void set_selected(Button button)
        {
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.FromArgb(255, 140, 0);
            button.ForeColor = Color.Black;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 178, 114);
        }

        void generate(int from, int lenght)
        {
            for (int i = from; i < from + lenght; i++)
            {
                buttons[i].Text = (i == from) ? "<" : (i == from + lenght - 1) ? ">" : (i - from).ToString();
                buttons[i].Font = new Font(AmazonEmber_Bd, buttons[i].Font.Size);
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

        int GetAll()
        {
            int all = 1;
            if (searchResult != null)
            {
                int allresults = 1;
                int.TryParse(searchResult.totalResults, out allresults);
                all = (allresults / 10) + 1;
            }
            return all;
        }

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

        private void searchlist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                e.Handled = true;
            }
        }

        private async void searchlist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                pNselected = Nselected;
                Nselected += e.KeyCode == Keys.Right ? 1 : -1;

                Nav_Buttons();
                if (CurrentSearchString != "" && pNselected != Nselected)
                {
                    ClientReset();
                    searchResult = await GetSearchResultAsync("?s=" + CurrentSearchString + "&page=" + Nselected + KEY);
                    UpdateSearchList();
                }
            }
        }
    }
}
