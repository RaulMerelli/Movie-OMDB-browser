namespace Movie_omdb
{
    partial class Omdb_main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Omdb_main));
            this.ricerca = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.Label();
            this.rated = new System.Windows.Forms.Label();
            this.searchlist = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.searchtype = new System.Windows.Forms.Label();
            this.searchyear = new System.Windows.Forms.Label();
            this.searchtitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.main = new System.Windows.Forms.Panel();
            this.generic = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.detail = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.b_5 = new System.Windows.Forms.Button();
            this.b_4 = new System.Windows.Forms.Button();
            this.b_3 = new System.Windows.Forms.Button();
            this.b_2 = new System.Windows.Forms.Button();
            this.b_1 = new System.Windows.Forms.Button();
            this.poster = new System.Windows.Forms.PictureBox();
            this.search = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.main.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ricerca
            // 
            this.ricerca.AcceptsReturn = true;
            this.ricerca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ricerca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ricerca.Location = new System.Drawing.Point(6, 3);
            this.ricerca.Name = "ricerca";
            this.ricerca.Size = new System.Drawing.Size(171, 22);
            this.ricerca.TabIndex = 1;
            this.ricerca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ricerca_KeyPress);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(59, 5);
            this.title.MaximumSize = new System.Drawing.Size(160, 90);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(13, 18);
            this.title.TabIndex = 3;
            this.title.Text = "-";
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year.Location = new System.Drawing.Point(59, 59);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(13, 18);
            this.year.TabIndex = 5;
            this.year.Text = "-";
            // 
            // rated
            // 
            this.rated.AutoSize = true;
            this.rated.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rated.Location = new System.Drawing.Point(122, 80);
            this.rated.Name = "rated";
            this.rated.Size = new System.Drawing.Size(13, 18);
            this.rated.TabIndex = 7;
            this.rated.Text = "-";
            // 
            // searchlist
            // 
            this.searchlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchlist.BackColor = System.Drawing.Color.Silver;
            this.searchlist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchlist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.searchlist.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlist.FormattingEnabled = true;
            this.searchlist.ItemHeight = 24;
            this.searchlist.Location = new System.Drawing.Point(0, 0);
            this.searchlist.Name = "searchlist";
            this.searchlist.Size = new System.Drawing.Size(349, 168);
            this.searchlist.TabIndex = 9;
            this.searchlist.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
            this.searchlist.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBox1_MeasureItem);
            this.searchlist.SelectedIndexChanged += new System.EventHandler(this.searchlist_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Anno: ";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Titolo: ";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 22);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tipo: ";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // searchtype
            // 
            this.searchtype.AutoSize = true;
            this.searchtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtype.Location = new System.Drawing.Point(61, 80);
            this.searchtype.Name = "searchtype";
            this.searchtype.Size = new System.Drawing.Size(11, 22);
            this.searchtype.TabIndex = 15;
            this.searchtype.Text = "-";
            this.searchtype.UseCompatibleTextRendering = true;
            // 
            // searchyear
            // 
            this.searchyear.AutoSize = true;
            this.searchyear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchyear.Location = new System.Drawing.Point(61, 59);
            this.searchyear.Name = "searchyear";
            this.searchyear.Size = new System.Drawing.Size(11, 22);
            this.searchyear.TabIndex = 14;
            this.searchyear.Text = "-";
            this.searchyear.UseCompatibleTextRendering = true;
            // 
            // searchtitle
            // 
            this.searchtitle.AutoSize = true;
            this.searchtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtitle.Location = new System.Drawing.Point(61, 5);
            this.searchtitle.MaximumSize = new System.Drawing.Size(160, 90);
            this.searchtitle.Name = "searchtitle";
            this.searchtitle.Size = new System.Drawing.Size(11, 22);
            this.searchtitle.TabIndex = 13;
            this.searchtitle.Text = "-";
            this.searchtitle.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.searchlist);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(12, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 204);
            this.panel1.TabIndex = 16;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackgroundImage = global::Movie_omdb.Properties.Resources.list_bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 170);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(349, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // main
            // 
            this.main.Controls.Add(this.label5);
            this.main.Controls.Add(this.label2);
            this.main.Controls.Add(this.searchtype);
            this.main.Controls.Add(this.label6);
            this.main.Controls.Add(this.searchyear);
            this.main.Controls.Add(this.searchtitle);
            this.main.Location = new System.Drawing.Point(592, 66);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(286, 280);
            this.main.TabIndex = 17;
            // 
            // generic
            // 
            this.generic.AutoSize = true;
            this.generic.BackColor = System.Drawing.Color.Gray;
            this.generic.Cursor = System.Windows.Forms.Cursors.Default;
            this.generic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generic.ForeColor = System.Drawing.Color.White;
            this.generic.Location = new System.Drawing.Point(367, 12);
            this.generic.Name = "generic";
            this.generic.Size = new System.Drawing.Size(110, 24);
            this.generic.TabIndex = 19;
            this.generic.Tag = "";
            this.generic.Text = "Panoramica&";
            this.generic.Click += new System.EventHandler(this.generic_click);
            this.generic.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.generic.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // details
            // 
            this.details.AutoSize = true;
            this.details.BackColor = System.Drawing.Color.Gray;
            this.details.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.details.ForeColor = System.Drawing.Color.White;
            this.details.Location = new System.Drawing.Point(483, 12);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(71, 24);
            this.details.TabIndex = 20;
            this.details.Tag = "";
            this.details.Text = "Dettagli";
            this.details.Click += new System.EventHandler(this.details_Click);
            this.details.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.details.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.ricerca);
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Location = new System.Drawing.Point(12, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(177, 30);
            this.panel3.TabIndex = 23;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Movie_omdb.Properties.Resources.search_left;
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(7, 30);
            this.pictureBox5.TabIndex = 24;
            this.pictureBox5.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(604, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // detail
            // 
            this.detail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detail.Controls.Add(this.label4);
            this.detail.Controls.Add(this.label1);
            this.detail.Controls.Add(this.label7);
            this.detail.Controls.Add(this.label3);
            this.detail.Controls.Add(this.label8);
            this.detail.Controls.Add(this.title);
            this.detail.Controls.Add(this.year);
            this.detail.Controls.Add(this.rated);
            this.detail.Location = new System.Drawing.Point(592, 66);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(283, 280);
            this.detail.TabIndex = 25;
            this.detail.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "Classificazione: ";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Anno: ";
            this.label1.UseCompatibleTextRendering = true;
            this.label1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 22);
            this.label7.TabIndex = 27;
            this.label7.Text = "Titolo: ";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(174, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tipo: ";
            this.label3.UseCompatibleTextRendering = true;
            this.label3.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 22);
            this.label8.TabIndex = 26;
            this.label8.Text = "Anno: ";
            this.label8.UseCompatibleTextRendering = true;
            // 
            // b_5
            // 
            this.b_5.BackColor = System.Drawing.Color.Gray;
            this.b_5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_5.BackgroundImage")));
            this.b_5.FlatAppearance.BorderSize = 0;
            this.b_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_5.Location = new System.Drawing.Point(168, 0);
            this.b_5.Name = "b_5";
            this.b_5.Size = new System.Drawing.Size(36, 36);
            this.b_5.TabIndex = 30;
            this.b_5.Text = "b_5";
            this.b_5.UseVisualStyleBackColor = false;
            this.b_5.Click += new System.EventHandler(this.nav_click);
            // 
            // b_4
            // 
            this.b_4.BackColor = System.Drawing.Color.Gray;
            this.b_4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_4.BackgroundImage")));
            this.b_4.FlatAppearance.BorderSize = 0;
            this.b_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_4.Location = new System.Drawing.Point(126, 0);
            this.b_4.Name = "b_4";
            this.b_4.Size = new System.Drawing.Size(36, 36);
            this.b_4.TabIndex = 29;
            this.b_4.Text = "b_4";
            this.b_4.UseVisualStyleBackColor = false;
            this.b_4.Click += new System.EventHandler(this.nav_click);
            // 
            // b_3
            // 
            this.b_3.BackColor = System.Drawing.Color.Gray;
            this.b_3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_3.BackgroundImage")));
            this.b_3.FlatAppearance.BorderSize = 0;
            this.b_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_3.Location = new System.Drawing.Point(84, 0);
            this.b_3.Name = "b_3";
            this.b_3.Size = new System.Drawing.Size(36, 36);
            this.b_3.TabIndex = 28;
            this.b_3.Text = "b_3";
            this.b_3.UseVisualStyleBackColor = false;
            this.b_3.Click += new System.EventHandler(this.nav_click);
            // 
            // b_2
            // 
            this.b_2.BackColor = System.Drawing.Color.Gray;
            this.b_2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_2.BackgroundImage")));
            this.b_2.FlatAppearance.BorderSize = 0;
            this.b_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_2.Location = new System.Drawing.Point(42, 0);
            this.b_2.Name = "b_2";
            this.b_2.Size = new System.Drawing.Size(36, 36);
            this.b_2.TabIndex = 27;
            this.b_2.Text = "b_2";
            this.b_2.UseVisualStyleBackColor = false;
            this.b_2.Click += new System.EventHandler(this.nav_click);
            // 
            // b_1
            // 
            this.b_1.BackColor = System.Drawing.Color.Gray;
            this.b_1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_1.BackgroundImage")));
            this.b_1.FlatAppearance.BorderSize = 0;
            this.b_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_1.Location = new System.Drawing.Point(0, 0);
            this.b_1.Name = "b_1";
            this.b_1.Size = new System.Drawing.Size(36, 36);
            this.b_1.TabIndex = 26;
            this.b_1.Text = "b_1";
            this.b_1.UseVisualStyleBackColor = false;
            this.b_1.Click += new System.EventHandler(this.nav_click);
            // 
            // poster
            // 
            this.poster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.poster.Location = new System.Drawing.Point(367, 67);
            this.poster.MaximumSize = new System.Drawing.Size(300, 380);
            this.poster.MinimumSize = new System.Drawing.Size(165, 209);
            this.poster.Name = "poster";
            this.poster.Size = new System.Drawing.Size(220, 293);
            this.poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poster.TabIndex = 8;
            this.poster.TabStop = false;
            this.poster.Resize += new System.EventHandler(this.poster_Resize);
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.DarkOrange;
            this.search.BackgroundImage = global::Movie_omdb.Properties.Resources.search_right;
            this.search.FlatAppearance.BorderSize = 0;
            this.search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Image = global::Movie_omdb.Properties.Resources.search_icon;
            this.search.Location = new System.Drawing.Point(186, 11);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(37, 30);
            this.search.TabIndex = 0;
            this.search.UseCompatibleTextRendering = true;
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Movie_omdb.Properties.Resources.list_top;
            this.pictureBox1.Location = new System.Drawing.Point(12, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox3.BackgroundImage = global::Movie_omdb.Properties.Resources.separator;
            this.pictureBox3.Location = new System.Drawing.Point(0, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(890, 14);
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Gray;
            this.pictureBox4.Location = new System.Drawing.Point(0, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(890, 52);
            this.pictureBox4.TabIndex = 22;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.b_1);
            this.panel2.Controls.Add(this.b_5);
            this.panel2.Controls.Add(this.b_2);
            this.panel2.Controls.Add(this.b_4);
            this.panel2.Controls.Add(this.b_3);
            this.panel2.Location = new System.Drawing.Point(85, 310);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 36);
            this.panel2.TabIndex = 31;
            // 
            // Omdb_main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(890, 374);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.detail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.details);
            this.Controls.Add(this.generic);
            this.Controls.Add(this.main);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.poster);
            this.Controls.Add(this.search);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.MinimumSize = new System.Drawing.Size(762, 328);
            this.Name = "Omdb_main";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.main.ResumeLayout(false);
            this.main.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.detail.ResumeLayout(false);
            this.detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox ricerca;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label year;
        private System.Windows.Forms.Label rated;
        private System.Windows.Forms.PictureBox poster;
        private System.Windows.Forms.ListBox searchlist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label searchtype;
        private System.Windows.Forms.Label searchyear;
        private System.Windows.Forms.Label searchtitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel main;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label generic;
        private System.Windows.Forms.Label details;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel detail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button b_1;
        private System.Windows.Forms.Button b_2;
        private System.Windows.Forms.Button b_4;
        private System.Windows.Forms.Button b_3;
        private System.Windows.Forms.Button b_5;
        private System.Windows.Forms.Panel panel2;
    }
}

