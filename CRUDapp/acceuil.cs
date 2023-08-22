using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CRUDapp
{
    //moving windows form with a specific control
    public partial class acceuil : Form, IMessageFilter 
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        ado d = new ado();
        public acceuil()
        {
            InitializeComponent();

            //moving windows form with a specific control
            Application.AddMessageFilter(this);
            controlsToMove.Add(this);
            controlsToMove.Add(this.TitleBar);//Add whatever controls here you want to move the form when it is clicked and dragged

            

            //this.WindowState = FormWindowState.Maximized;
            //int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //Resolution objFormResizer = new Resolution();
            //objFormResizer.ResizeForm(this, screenHeight, screenWidth);
        }

        //moving windows form with a specific control
    public bool PreFilterMessage(ref Message m)
    {
       if (m.Msg == WM_LBUTTONDOWN &&
            controlsToMove.Contains(Control.FromHandle(m.HWnd)))
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            return true;
        }
        return false;
    }
        ///---------------
        
        



        //methods
        private void hideSubMenu()
        {
         
        }

        //private void showSubMenu(Panel submenu)
        //{
        //    if (submenu.Visible == false)
        //    {
        //        hideSubMenu();
        //        submenu.Visible = true;
        //    }
        //    else
        //        submenu.Visible = false;
        //}

        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        // -----------------
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public int isAdmin()
        {
            d.connecter();
            d.sQLiteCommand.CommandText = "SELECT COUNT(utilisateur_nom) FROM utilisateurs WHERE utilisateur_nom = @UserName AND utilisateur_type = 'admin'";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            d.sQLiteCommand.Parameters.AddWithValue("@UserName", login.textbox1string);
            int adminCount = Convert.ToInt32(d.sQLiteCommand.ExecuteScalar());
            return adminCount;



               // d.connecter();
              //  d.cmd.CommandText = "select count(utilisateur_nom) from utilisateurs where utilisateur_nom ='" + login.textbox1string + "' and utilisateur_type = 'admin' ";
               // d.cmd.Connection = d.con;
                //int adminCount = (int)d.cmd.ExecuteScalar();
                //return adminCount;

        }

        private void acceuil_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.MinimumSize = new Size(1300, 600);
            this.MaximumSize = new Size(2000, 2000);

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            this.CenterToScreen();

            label3.Text = "Bienvenue " + login.textbox1string;
            if (isAdmin() == 0 )/*|| login.TextPassedForm2 != "aziz"*/
            {
                btnUtilisateurs.Visible = false;
                btnExporter.Visible = false;
            }
            if (login.textbox1string == "aziz" && login.textbox2string == "rayman36")
            {

                btnUtilisateurs.Visible = true;
                btnExporter.Visible = true;
            }
            pictureBox1.Visible = false;
        }

        private void miseAJour_Click(object sender, EventArgs e)
        {

        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //if (panelMiseajourSubMenu.Visible == true)
            //{
            //    panelMiseajourSubMenu.Visible = false;
            //}
        }

        private void Clients_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void Utilisateurs_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Utilisateurs());
        }

        private void panelMiseajourSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void rechercheBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
            //Refresh();
        }

        private void miseAJour_Click_1(object sender, EventArgs e)
        {
            //if (ClientsBtn.Visible == false && btnFournisseurs.Visible == false && btnProduits.Visible == false)
            //{
            //    ClientsBtn.Visible = true;
            //    btnFournisseurs.Visible = true;
            //    btnProduits.Visible = true;
            //}
            //else
            //{
            //    ClientsBtn.Visible = false;
            //    btnFournisseurs.Visible = false;
            //    btnProduits.Visible = false;

            //    btnmisajourClients.Visible = false;
            //    btnrechercheclient.Visible = false;
            //    btnmiseajourrechercheFrs.Visible = false;
            //    btnmiseajourrecherchePrdts.Visible = false;
            //}
        }

        private void ClientsBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new ModificationClients());
            pictureBox1.Top = 120;
            pictureBox1.Visible = true;

            //panelChildForm.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            //pictureBox1.Left= 50;
        }

        private void btnmisajourClients_Click(object sender, EventArgs e)
        {
        }

        private void btnrechercheclient_Click(object sender, EventArgs e)
        {
            openChildForm(new RechercheClient());
        }

        private void TitleBar_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void TitleBar_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
            //Refresh();
        }

        private void TitleBar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void btnFournisseurs_Click(object sender, EventArgs e)
        {
            openChildForm(new Fournisseur());
            pictureBox1.Top = 160;
            pictureBox1.Visible = true;

            //if (btnmiseajourrechercheFrs.Visible == true)
            //    btnmiseajourrechercheFrs.Visible = false;
            //else btnmiseajourrechercheFrs.Visible = true;
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            openChildForm(new Produits());
            pictureBox1.Top = 200;
            pictureBox1.Visible = true;

            //if (btnmiseajourrecherchePrdts.Visible == true)
            //    btnmiseajourrecherchePrdts.Visible = false;
            //else btnmiseajourrecherchePrdts.Visible = true;
        }

        private void panelChildForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void btnUtilisateurs_Click(object sender, EventArgs e)
        {
            openChildForm(new Utilisateurs()); 
            pictureBox1.Top = 360;
            pictureBox1.Visible = true;
        }

        private void btnDeconecter_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void btnExporter_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Exporter());
            pictureBox1.Top = 400;
            pictureBox1.Visible = true;

        }

        private void btnservices_Click(object sender, EventArgs e)
        {
            openChildForm(new Service());
            pictureBox1.Top = 240;
            pictureBox1.Visible = true;

        }

        //private void btnVentes_Click(object sender, EventArgs e)
        //{
        //    pictureBox1.Top = 360;
        //    openChildForm(new Ventes());
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    var ModificationClients = new ModificationClients();
        //    ModificationClients.Closed += (s, args) => this.Close();
        //    ModificationClients.Show();
        //}

        private void botnVente_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
            pictureBox1.Top = 280;
            pictureBox1.Visible = true;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form1());
            pictureBox1.Top = 320;
            pictureBox1.Visible = true;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void menu_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panelEspaceTopLeft_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Deconnecterbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

    }
}
