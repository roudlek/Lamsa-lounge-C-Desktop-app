using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CRUDapp
{
    public partial class RechercheClient : Form
    {
        public RechercheClient()
        {
            InitializeComponent();

        }
        public void remplirgrid()
        {
            if (d.dataTable.Rows != null)
            {
                d.dataTable.Clear();
            }
            d.sQLiteCommand.CommandText = "select client_code Code, client_nom Nom, client_prenom Prenom, client_tel Telephone, client_date_entree as 'Date d''entrée', client_fidele Fidélité, client_type Type from Clients";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            d.sqliteDataReader = d.sQLiteCommand.ExecuteReader();
            d.dataTable.Load(d.sqliteDataReader);
            dataGridView1.DataSource = d.dataTable;
            d.sqliteDataReader.Close();
        }

        Color oldColor;
        Color newColor = Color.FromArgb(0, Color.LightGray);  // your pick, including Black
        int alpha = 0;

        private void RechercheClient_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;

            oldColor = btnRechercher.BackColor;
            d.connecter();
            remplirgrid();
        }
        private void btnRechercher_MouseEnter(object sender, EventArgs e)
        {
            alpha = 0;
            timer1.Interval = 15;
            timer1.Start();
        }
        private void btnRechercher_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            btnRechercher.BackColor = oldColor;
            btnRechercher.ForeColor = Color.Black;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            alpha += 17;  // change this for greater or less speed
            btnRechercher.BackColor = Color.FromArgb(alpha, newColor);
            if (alpha >= 255) timer1.Stop();
            if (btnRechercher.BackColor.GetBrightness() < 0.3) btnRechercher.ForeColor = Color.White;
        }
        
        ado d = new ado();

        //-------
        
        public static bool nonvide = true;
        public static bool prevent = true;
        public void hasSpecialChar(string input)
        {
            char[] specialChar = { '(', ')', ';' };
            foreach (char item in specialChar) // or foreach var
            {
                if (input.Contains(item))
                {
                    MessageBox.Show("les characters ( et ) et ; sont non autorise");
                    prevent = false;
                    return;
                }
                else prevent = true;
            }
        }
        public void prevent_sqlInj(TextBox TB)
        {
            hasSpecialChar(TB.Text);
        }
        public void preventsqlInjFromAlltextboxes()
        {
            prevent_sqlInj(textBox1);
            if (prevent == false) return;

        }



        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {

        }
        


        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    var ind = guna2DataGridView1.CurrentRow.Index;
            //    textBox1.Text = d.dt.Rows[ind][0].ToString();
            //}
            //catch { }
        }

        private void btnRechercher_Click_1(object sender, EventArgs e)
        {
            d.connecter();
            if (textBox1.Text == "")
            {
                MessageBox.Show("veuillez entrer la cliente a recherche");
                return;
            }
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                if (d.dataTable2.Rows != null)
                {
                    d.dataTable2.Clear();
                }
                d.sQLiteCommand.CommandText = "select client_code Code, client_nom Nom, client_prenom Prenom, client_tel Telephone, client_date_entree as 'Date d''entrée', client_fidele Fidélité, client_type Type from Clients where client_code like '%" + textBox1.Text + "%'";
                d.sQLiteCommand.Connection = d.sqliteConnection;
                d.sqliteDataReader = d.sQLiteCommand.ExecuteReader();
                d.dataTable2.Load(d.sqliteDataReader);
                dataGridView1.DataSource = d.dataTable2;
                d.sqliteDataReader.Close();
            }
        }
    }
}
