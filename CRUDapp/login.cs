using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace CRUDapp
{
    public partial class login : Form
    {
        ado d = new ado();
        public login()
        {
            InitializeComponent();
        }

        public int exist()
        {
            d.connecter();
            d.sQLiteCommand.CommandText = "select count(utilisateur_nom) from utilisateurs where utilisateur_nom ='" + textBox1.Text + "' and utilisateur_mot_de_passe ='" + textBox2.Text + "'";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            int a = Convert.ToInt32(d.sQLiteCommand.ExecuteScalar());
            return a;
        }

        public void sauthentifier()
        {
            d.connecter();
            if (exist() > 0)
            {
                //entrer dans l'acceuil
                this.Hide();
                var acceuil = new acceuil();
                acceuil.Closed += (s, args) => this.Close();
                acceuil.Show();
            }
            else if (textBox1.Text == "aziz" && textBox2.Text == "rayman36")
            {
                this.Hide();
                var acceuil = new acceuil();
                acceuil.Closed += (s, args) => this.Close();
                acceuil.Show();
            }
            else MessageBox.Show("nom ou mot de passe incorrecte");

            //else if( prevent == true) MessageBox.Show("nom ou mot de passe incorrecte");
        }
        // ---------------------
        public void checkIfTBisEmpty(TextBox TB)
        {
            if (TB.Text == "")
            {
                MessageBox.Show("Champ obligatoires");
                nonvide = false;
                return;
            }
        }

        //--------------------
        public static bool nonvide = true;
        public static bool prevent = true;
        public void hasSpecialChar(string input)
        {
            char[] specialChar = { '(', ')',';' };
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
        //--------------------

        public static string textbox1string;
        public static string textbox2string;

        private void login_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(500, 350);
            textBox2.UseSystemPasswordChar = true;

            textBox1.Focus();

            ////

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            nonvide = true;
            prevent = false;

            // 1 - we check if textbox are empty
            checkIfTBisEmpty(textBox1);
            if (nonvide == false) return;

            checkIfTBisEmpty(textBox2);
            if (nonvide == false) return;

            prevent_sqlInj(textBox1);
            if (prevent == false) return;

            prevent_sqlInj(textBox2);
            if (prevent == false) return;

            if (prevent == true)
            {
                textbox1string = textBox1.Text;
                textbox2string = textBox2.Text;
                sauthentifier();
                
            }
            //if (textBox1.Text == "" || textBox2.Text == "")
            //{
            //    MessageBox.Show("Champ obligatoires");
            //    return;
            //}
            //hasSpecialChar(textBox1.Text);

            //if (prevent == true)
            //{
            //    hasSpecialChar(textBox2.Text);
            //}

            //if (prevent == true)
            //{
            //    sauthentifier();
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
            d.deconnecter();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1And2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
