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
using System.Threading;
namespace CRUDapp
{
    public partial class Utilisateurs : Form
    {
        ado d = new ado();

        public Utilisateurs()
        {
            InitializeComponent();
        }

        public static bool nonvide = true;
        public static bool prevent = true;
        public void hasSpecialChar(string input)
        {
            char[] specialChar = { '(', ')', ';', '\'', ',', '/' };
            foreach (char item in specialChar) // or foreach var
            {
                if (input.Contains(item))
                {
                    MessageBox.Show("les characters Speciales sont nont autorise");
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
            prevent_sqlInj(textBox2);
            if (prevent == false) return;
            prevent_sqlInj(textBox3);
            if (prevent == false) return;
            prevent_sqlInj(textBox4);
            if (prevent == false) return;
        }
        //public int nombre()
        //{
        //    int cpt; // compteur
        //    d.cmd.CommandText = "select count(utilisateur_code) from utilisateurs where utilisateur_code = '" + textBox1.Text + "'";
        //    d.cmd.Connection = d.con;
        //    cpt = (int)d.cmd.ExecuteScalar();
        //    return cpt;
        //}

        //declaration de la methode ajouter
        public void ajouter()
        {
            //if (nombre() == 0)
            //{
                //darori les collones lli fihom des character ydar wsthom 'txtnom.Text' matalan
                d.sQLiteCommand.CommandText = "insert into utilisateurs(utilisateur_nom, utilisateur_prenom, utilisateur_mot_de_passe, utilisateur_date_entree, utilisateur_type) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + comboBox1.SelectedItem.ToString() + "')";
                d.sQLiteCommand.Connection = d.sqliteConnection;
                d.sQLiteCommand.ExecuteNonQuery();
            //    return true;// important tdir return true et false lfcode dyalek
            //}
            //return false;
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            d.connecter();
            //if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||  textBox6.Text == "")
            if (textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Merci de remplir nom et le mot de passe");
                return; //break if the program enters this if
            }
            //securite
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                //if (ajouter() == true)
                //{
                ajouter();
                try
                {
                    this.pictureBox1.Visible = true;
                    Task.Run(() =>
                    {
                        Thread.Sleep(2000);
                        this.Invoke(new Action(() =>
                        {
                            this.pictureBox1.Visible = false;
                        }));
                    });
                }
                catch { }
                remplirgrid();
                textBox2.Focus();
                    //cas 3adi dataGridView1.Rows.Add(textBox1.Text, textBox1.Text, textBox3.Text, textBox4, dateTimePicker1.Value, textBox5, textBox6);  
                }
            //}
            //this.ActiveControl = textBox1;
        }

        public void remplirgrid()
        {
            if (d.dataTable.Rows != null)
            {
                d.dataTable.Clear();
            }
            d.sQLiteCommand.CommandText = "select * from utilisateurs";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            d.sqliteDataReader = d.sQLiteCommand.ExecuteReader();
            d.dataTable.Load(d.sqliteDataReader);
            dataGridView1.DataSource = d.dataTable;
            d.sqliteDataReader.Close();
        }

        private void Utilisateurs_Load(object sender, EventArgs e)
        {
            d.connecter();
            remplirgrid();

            this.pictureBox1.Visible = false;
            textBox2.Focus();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        public void eviteSuppressionDadmin()
        {
            int cpt; // compteur

            d.sQLiteCommand.CommandText = "select count(utilisateur_code) from utilisateurs where utilisateur_code = '" + textBox1.Text + "'";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            cpt = (int)d.sQLiteCommand.ExecuteScalar();
            if (cpt == 1)
            {
                int a = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    if (row.Cells[5].Value.Equals("Admin"))
                    {
                        a += 1;
                    }
                if (a > 1)
                {
                    d.sQLiteCommand.CommandText = "delete from utilisateurs where utilisateur_code = '" + textBox1.Text + "'";
                    d.sQLiteCommand.Connection = d.sqliteConnection;
                    d.sQLiteCommand.ExecuteNonQuery();
                }
                else if (a == 1)
                {
                    if (dataGridView1.CurrentRow.Cells[5].Value.Equals("Admin"))
                    {
                        MessageBox.Show("operation impossible, il faut avoir au moins un admin");
                    }
                    else
                    {
                        d.sQLiteCommand.CommandText = "delete from utilisateurs where utilisateur_code = '" + textBox1.Text + "'";
                        d.sQLiteCommand.Connection = d.sqliteConnection;
                        d.sQLiteCommand.ExecuteNonQuery();
                    }
                }
                else MessageBox.Show("cette utilisateur n'existe pas");
            }
        } 

        private void btnSuprimer_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Merci de selectionner l'utilisateur a supprimer");
                textBox1.Focus();
                return; //break if the program enters this if
            }
            //securite
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                DialogResult dialogResult = MessageBox.Show("voulez vous vraiment supprimer cette utilisateur", "Alert", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    eviteSuppressionDadmin();
                    remplirgrid();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    comboBox1.Text = comboBox1.Items[0].ToString();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Operation annulee");
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var ind = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                DateTime dateSelectionne = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                dateTimePicker1.Value = dateSelectionne.Date;

            }
            catch { }
        }
    }
}
