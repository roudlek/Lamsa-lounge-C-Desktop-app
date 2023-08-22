namespace CRUDapp
{
    partial class acceuil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(acceuil));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TitleBar = new System.Windows.Forms.Panel();
            this.BtnMaximize = new System.Windows.Forms.PictureBox();
            this.BtnMinimize = new System.Windows.Forms.PictureBox();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExporter = new System.Windows.Forms.Button();
            this.btnUtilisateurs = new System.Windows.Forms.Button();
            this.Deconnecterbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.botnVente = new System.Windows.Forms.Button();
            this.btnservices = new System.Windows.Forms.Button();
            this.btnDeconecter = new System.Windows.Forms.Button();
            this.btnProduits = new System.Windows.Forms.Button();
            this.btnFournisseurs = new System.Windows.Forms.Button();
            this.ClientsBtn = new System.Windows.Forms.Button();
            this.miseAJour = new System.Windows.Forms.Button();
            this.panelEspaceTopLeft = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelEspaceTopLeft.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(2)))), ((int)(((byte)(23)))));
            this.TitleBar.Controls.Add(this.BtnMaximize);
            this.TitleBar.Controls.Add(this.BtnMinimize);
            this.TitleBar.Controls.Add(this.BtnClose);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Margin = new System.Windows.Forms.Padding(2);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(1482, 38);
            this.TitleBar.TabIndex = 1;
            this.TitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.TitleBar_Paint);
            this.TitleBar.DoubleClick += new System.EventHandler(this.TitleBar_DoubleClick);
            this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            // 
            // BtnMaximize
            // 
            this.BtnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("BtnMaximize.Image")));
            this.BtnMaximize.Location = new System.Drawing.Point(72, 5);
            this.BtnMaximize.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMaximize.Name = "BtnMaximize";
            this.BtnMaximize.Size = new System.Drawing.Size(18, 28);
            this.BtnMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMaximize.TabIndex = 2;
            this.BtnMaximize.TabStop = false;
            this.BtnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("BtnMinimize.Image")));
            this.BtnMinimize.Location = new System.Drawing.Point(48, 5);
            this.BtnMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(18, 28);
            this.BtnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMinimize.TabIndex = 1;
            this.BtnMinimize.TabStop = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Image = ((System.Drawing.Image)(resources.GetObject("BtnClose.Image")));
            this.BtnClose.Location = new System.Drawing.Point(24, 5);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(18, 28);
            this.BtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnClose.TabIndex = 0;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // menu
            // 
            this.menu.AutoScroll = true;
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(5)))), ((int)(((byte)(62)))));
            this.menu.Controls.Add(this.pictureBox1);
            this.menu.Controls.Add(this.btnExporter);
            this.menu.Controls.Add(this.btnUtilisateurs);
            this.menu.Controls.Add(this.Deconnecterbtn);
            this.menu.Controls.Add(this.label3);
            this.menu.Controls.Add(this.button2);
            this.menu.Controls.Add(this.botnVente);
            this.menu.Controls.Add(this.btnservices);
            this.menu.Controls.Add(this.btnDeconecter);
            this.menu.Controls.Add(this.btnProduits);
            this.menu.Controls.Add(this.btnFournisseurs);
            this.menu.Controls.Add(this.ClientsBtn);
            this.menu.Controls.Add(this.miseAJour);
            this.menu.Controls.Add(this.panelEspaceTopLeft);
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.Location = new System.Drawing.Point(2, 2);
            this.menu.Margin = new System.Windows.Forms.Padding(2);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(290, 811);
            this.menu.TabIndex = 3;
            this.menu.Paint += new System.Windows.Forms.PaintEventHandler(this.menu_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.pictureBox1.BackgroundImage = global::CRUDapp.Properties.Resources.output_onlinepngtools;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(1, 150);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnExporter
            // 
            this.btnExporter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.btnExporter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExporter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExporter.FlatAppearance.BorderSize = 0;
            this.btnExporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporter.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.btnExporter.ForeColor = System.Drawing.Color.White;
            this.btnExporter.Location = new System.Drawing.Point(0, 500);
            this.btnExporter.Margin = new System.Windows.Forms.Padding(2);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnExporter.Size = new System.Drawing.Size(315, 50);
            this.btnExporter.TabIndex = 8;
            this.btnExporter.Text = "Exporter";
            this.btnExporter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExporter.UseVisualStyleBackColor = false;
            this.btnExporter.Click += new System.EventHandler(this.btnExporter_Click_1);
            // 
            // btnUtilisateurs
            // 
            this.btnUtilisateurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.btnUtilisateurs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUtilisateurs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUtilisateurs.FlatAppearance.BorderSize = 0;
            this.btnUtilisateurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUtilisateurs.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.btnUtilisateurs.ForeColor = System.Drawing.Color.White;
            this.btnUtilisateurs.Location = new System.Drawing.Point(0, 450);
            this.btnUtilisateurs.Margin = new System.Windows.Forms.Padding(2);
            this.btnUtilisateurs.Name = "btnUtilisateurs";
            this.btnUtilisateurs.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnUtilisateurs.Size = new System.Drawing.Size(315, 50);
            this.btnUtilisateurs.TabIndex = 7;
            this.btnUtilisateurs.Text = "Ajouter un utilisateur";
            this.btnUtilisateurs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilisateurs.UseVisualStyleBackColor = false;
            this.btnUtilisateurs.Click += new System.EventHandler(this.btnUtilisateurs_Click);
            // 
            // Deconnecterbtn
            // 
            this.Deconnecterbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.Deconnecterbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Deconnecterbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Deconnecterbtn.FlatAppearance.BorderSize = 0;
            this.Deconnecterbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deconnecterbtn.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.Deconnecterbtn.ForeColor = System.Drawing.Color.White;
            this.Deconnecterbtn.Location = new System.Drawing.Point(0, 740);
            this.Deconnecterbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Deconnecterbtn.Name = "Deconnecterbtn";
            this.Deconnecterbtn.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.Deconnecterbtn.Size = new System.Drawing.Size(315, 50);
            this.Deconnecterbtn.TabIndex = 22;
            this.Deconnecterbtn.Text = "Deconnecter";
            this.Deconnecterbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Deconnecterbtn.UseVisualStyleBackColor = false;
            this.Deconnecterbtn.Click += new System.EventHandler(this.Deconnecterbtn_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Pro Display", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 651);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 39);
            this.label3.TabIndex = 21;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 400);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(315, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "Autre";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // botnVente
            // 
            this.botnVente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.botnVente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botnVente.Dock = System.Windows.Forms.DockStyle.Top;
            this.botnVente.FlatAppearance.BorderSize = 0;
            this.botnVente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botnVente.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.botnVente.ForeColor = System.Drawing.Color.White;
            this.botnVente.Location = new System.Drawing.Point(0, 350);
            this.botnVente.Margin = new System.Windows.Forms.Padding(2);
            this.botnVente.Name = "botnVente";
            this.botnVente.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.botnVente.Size = new System.Drawing.Size(315, 50);
            this.botnVente.TabIndex = 5;
            this.botnVente.Text = "Ventes";
            this.botnVente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botnVente.UseVisualStyleBackColor = false;
            this.botnVente.Click += new System.EventHandler(this.botnVente_Click);
            // 
            // btnservices
            // 
            this.btnservices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.btnservices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnservices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnservices.FlatAppearance.BorderSize = 0;
            this.btnservices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnservices.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.btnservices.ForeColor = System.Drawing.Color.White;
            this.btnservices.Location = new System.Drawing.Point(0, 300);
            this.btnservices.Margin = new System.Windows.Forms.Padding(2);
            this.btnservices.Name = "btnservices";
            this.btnservices.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnservices.Size = new System.Drawing.Size(315, 50);
            this.btnservices.TabIndex = 4;
            this.btnservices.Text = "Services";
            this.btnservices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnservices.UseVisualStyleBackColor = false;
            this.btnservices.Click += new System.EventHandler(this.btnservices_Click);
            // 
            // btnDeconecter
            // 
            this.btnDeconecter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeconecter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDeconecter.FlatAppearance.BorderSize = 0;
            this.btnDeconecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeconecter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeconecter.ForeColor = System.Drawing.Color.Black;
            this.btnDeconecter.Location = new System.Drawing.Point(0, 915);
            this.btnDeconecter.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeconecter.Name = "btnDeconecter";
            this.btnDeconecter.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDeconecter.Size = new System.Drawing.Size(315, 50);
            this.btnDeconecter.TabIndex = 16;
            this.btnDeconecter.Text = "Deconnecter";
            this.btnDeconecter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeconecter.UseVisualStyleBackColor = false;
            this.btnDeconecter.Click += new System.EventHandler(this.btnDeconecter_Click);
            // 
            // btnProduits
            // 
            this.btnProduits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.btnProduits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduits.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduits.FlatAppearance.BorderSize = 0;
            this.btnProduits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduits.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.btnProduits.ForeColor = System.Drawing.Color.White;
            this.btnProduits.Location = new System.Drawing.Point(0, 250);
            this.btnProduits.Margin = new System.Windows.Forms.Padding(2);
            this.btnProduits.Name = "btnProduits";
            this.btnProduits.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnProduits.Size = new System.Drawing.Size(315, 50);
            this.btnProduits.TabIndex = 3;
            this.btnProduits.Text = "Produits";
            this.btnProduits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduits.UseVisualStyleBackColor = false;
            this.btnProduits.Click += new System.EventHandler(this.btnProduits_Click);
            // 
            // btnFournisseurs
            // 
            this.btnFournisseurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.btnFournisseurs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFournisseurs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFournisseurs.FlatAppearance.BorderSize = 0;
            this.btnFournisseurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFournisseurs.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.btnFournisseurs.ForeColor = System.Drawing.Color.White;
            this.btnFournisseurs.Location = new System.Drawing.Point(0, 200);
            this.btnFournisseurs.Margin = new System.Windows.Forms.Padding(2);
            this.btnFournisseurs.Name = "btnFournisseurs";
            this.btnFournisseurs.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnFournisseurs.Size = new System.Drawing.Size(315, 50);
            this.btnFournisseurs.TabIndex = 2;
            this.btnFournisseurs.Text = "Fournisseurs";
            this.btnFournisseurs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFournisseurs.UseVisualStyleBackColor = false;
            this.btnFournisseurs.Click += new System.EventHandler(this.btnFournisseurs_Click);
            // 
            // ClientsBtn
            // 
            this.ClientsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(3)))), ((int)(((byte)(40)))));
            this.ClientsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClientsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClientsBtn.FlatAppearance.BorderSize = 0;
            this.ClientsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientsBtn.Font = new System.Drawing.Font("SF Pro Display", 12F);
            this.ClientsBtn.ForeColor = System.Drawing.Color.White;
            this.ClientsBtn.Location = new System.Drawing.Point(0, 150);
            this.ClientsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ClientsBtn.Name = "ClientsBtn";
            this.ClientsBtn.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.ClientsBtn.Size = new System.Drawing.Size(315, 50);
            this.ClientsBtn.TabIndex = 1;
            this.ClientsBtn.Text = "Clients";
            this.ClientsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClientsBtn.UseVisualStyleBackColor = false;
            this.ClientsBtn.Click += new System.EventHandler(this.ClientsBtn_Click);
            // 
            // miseAJour
            // 
            this.miseAJour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(2)))), ((int)(((byte)(23)))));
            this.miseAJour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.miseAJour.Dock = System.Windows.Forms.DockStyle.Top;
            this.miseAJour.FlatAppearance.BorderSize = 0;
            this.miseAJour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.miseAJour.Font = new System.Drawing.Font("SF Pro Display", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miseAJour.ForeColor = System.Drawing.Color.White;
            this.miseAJour.Location = new System.Drawing.Point(0, 100);
            this.miseAJour.Margin = new System.Windows.Forms.Padding(2);
            this.miseAJour.Name = "miseAJour";
            this.miseAJour.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.miseAJour.Size = new System.Drawing.Size(315, 50);
            this.miseAJour.TabIndex = 9;
            this.miseAJour.Text = "Menu";
            this.miseAJour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miseAJour.UseVisualStyleBackColor = false;
            this.miseAJour.Click += new System.EventHandler(this.miseAJour_Click_1);
            // 
            // panelEspaceTopLeft
            // 
            this.panelEspaceTopLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.panelEspaceTopLeft.Controls.Add(this.tableLayoutPanel2);
            this.panelEspaceTopLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEspaceTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelEspaceTopLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelEspaceTopLeft.Name = "panelEspaceTopLeft";
            this.panelEspaceTopLeft.Size = new System.Drawing.Size(315, 100);
            this.panelEspaceTopLeft.TabIndex = 7;
            this.panelEspaceTopLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEspaceTopLeft_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.0083F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.9917F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(315, 100);
            this.tableLayoutPanel2.TabIndex = 3;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(247, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.tableLayoutPanel2.SetRowSpan(this.pictureBox2, 2);
            this.pictureBox2.Size = new System.Drawing.Size(54, 96);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(15, 10, 2, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Heure";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(2)))), ((int)(((byte)(17)))));
            this.panelChildForm.Controls.Add(this.pictureBox3);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(296, 2);
            this.panelChildForm.Margin = new System.Windows.Forms.Padding(2);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1184, 811);
            this.panelChildForm.TabIndex = 2;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildForm_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(2)))), ((int)(((byte)(17)))));
            this.pictureBox3.Image = global::CRUDapp.Properties.Resources.dou3aegood_removebg_preview;
            this.pictureBox3.Location = new System.Drawing.Point(3, 250);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1184, 345);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.90553F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.09447F));
            this.tableLayoutPanel1.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelChildForm, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1482, 815);
            this.tableLayoutPanel1.TabIndex = 4;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // acceuil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1482, 853);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "acceuil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "acceuil";
            this.Load += new System.EventHandler(this.acceuil_Load);
            this.TitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelEspaceTopLeft.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.PictureBox BtnClose;
        private System.Windows.Forms.PictureBox BtnMaximize;
        private System.Windows.Forms.PictureBox BtnMinimize;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Button ClientsBtn;
        private System.Windows.Forms.Button miseAJour;
        private System.Windows.Forms.Panel panelEspaceTopLeft;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFournisseurs;
        private System.Windows.Forms.Button btnProduits;
        private System.Windows.Forms.Button btnUtilisateurs;
        private System.Windows.Forms.Button btnDeconecter;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.Button btnservices;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button botnVente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button Deconnecterbtn;

    }
}