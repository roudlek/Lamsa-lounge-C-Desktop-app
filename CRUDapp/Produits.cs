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
    public partial class Produits : Form
    {
        ado d = new ado();

        public Produits()
        {
            InitializeComponent();
        }

        public void remplirgrid()
        {
            if (d.dataTable.Rows != null)
            {
                d.dataTable.Clear();
            }
            d.sQLiteCommand.CommandText = "select produit_code Code, produit_nom Nom, fournisseur_de_produit Fournisseur, produit_date_entre as 'Date d''entrée', produit_prix_dachat 'Prix d''Achat' , produit_prix_de_vente 'Prix de Vente',produit_profit_net as 'Profit net', produit_qualite Qualite from produits order by produit_code desc";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            d.sqliteDataReader = d.sQLiteCommand.ExecuteReader();
            d.dataTable.Load(d.sqliteDataReader);
            dataGridView1.DataSource = d.dataTable;
            d.sqliteDataReader.Close();
        }
        public void updatefromgridview(DataGridView DGV, TextBox TB, DataTable table)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(TB.Text))
                {
                    row.Cells[1].Value = textBox2.Text;
                    row.Cells[2].Value = comboBox1.SelectedItem.ToString();
                    row.Cells[3].Value = dateTimePicker1.Value.ToShortDateString();

                    if (textBox3.Text == "")
                        row.Cells[4].Value = "0";
                    else row.Cells[4].Value = Convert.ToInt32(textBox3.Text);

                    if (textBox4.Text == "")
                        row.Cells[5].Value = "0";
                    else row.Cells[5].Value = Convert.ToInt32(textBox4.Text);

                    if (textBox5.Text == "")
                        row.Cells[6].Value = "0";
                    else row.Cells[6].Value = Convert.ToInt32(textBox5.Text);

                    row.Cells[7].Value = comboBox2.SelectedItem.ToString();
                }
            }
        }
        private void Produits_Load(object sender, EventArgs e)
        {
            d.connecter();
            this.pictureBox1.Visible = false;
            textBox1.Focus();

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox2.Items[0].Equals("Inconnu");

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Text = comboBox2.Items[2].ToString();

            remplircombobox();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox1.Text = "Inconnu";

            remplirgrid();

            dataGridView1.ReadOnly = true;
            labelTotalResult.Text = dataGridView1.RowCount.ToString();
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
        public int nombre()
        {
            int cpt; // compteur
            d.sQLiteCommand.CommandText = "select count(produit_code) from produits where produit_code = '" + textBox1.Text + "'";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            cpt = (int)d.sQLiteCommand.ExecuteScalar();
            return cpt;
        }

        //declaration de la methode ajouter
        public bool ajouter()
        {
            if (nombre() == 0)
            {
                //darori les collones lli fihom des character ydar wsthom 'txtnom.Text' matalan
                d.sQLiteCommand.CommandText = "insert into produits values('" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + textBox3.Text + "','" + textBox4.Text + "','" +  textBox5.Text + "','" + comboBox2.SelectedItem.ToString() + "')";
                d.sQLiteCommand.Connection = d.sqliteConnection;
                d.sQLiteCommand.ExecuteNonQuery();
                return true;// important tdir return true et false lfcode dyalek
            }
            return false;
        }

        private void Utilisateurs_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;
            textBox2.Focus();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        //private void btnCreer_Click_1(object sender, EventArgs e)
        //{
        //    d.connecter();
        //    //if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||  textBox6.Text == "")
        //    if (textBox1.Text == "" || textBox2.Text == "")
        //    {
        //        MessageBox.Show("Merci de remplir au moin le code,et le nom");
        //        return; //break if the program enters this if
        //    }
        //    //securite
        //    preventsqlInjFromAlltextboxes();
        //    if (prevent == true)
        //    {
        //        //ila drti methode fbutton f if rah katkhdm
        //        try { 
        //            if (ajouter() == true)
        //            {
        //                this.pictureBox1.Visible = true;
        //                Task.Run(() =>
        //                {
        //                    Thread.Sleep(2000);
        //                    this.Invoke(new Action(() =>
        //                    {
        //                        this.pictureBox1.Visible = false;
        //                    }));
        //                });

        //                textBox1.Focus();
        //                remplirgrid();

        //                //cas 3adi dataGridView1.Rows.Add(textBox1.Text, textBox1.Text, textBox3.Text, textBox4, dateTimePicker1.Value, textBox5, textBox6);  
        //            }
        //            else
        //            {
        //                MessageBox.Show("Ce produit exist deja");
        //            }
        //        }
        //        catch 
        //        {
        //            MessageBox.Show("verifier les prix");
        //        }
        //    }
        //    //this.ActiveControl = textBox1;
        //}

        public void remplircombobox()
        {
            //comboBox1.Items.Clear();
            d.sQLiteCommand.CommandText = "select Fournisseur_nom from Fournisseurs";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            d.sqliteDataReader = d.sQLiteCommand.ExecuteReader();
            while (d.sqliteDataReader.Read())
            {
                comboBox1.Items.Add(d.sqliteDataReader[0]);
            }
            d.sqliteDataReader.Close();
        }

        private void AddARow(DataTable table)
        {
            // Use the NewRow method to create a DataRow with 
            // the table's schema.
            // Add the row to the rows collection.
            int firstColum = 101;
            string secondColum = textBox2.Text;
            string thirdColum = comboBox1.SelectedItem.ToString();
            string dateColum = dateTimePicker1.Value.ToShortDateString();

            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "0";
            }

            int fifthColum = Convert.ToInt32(textBox3.Text);
            int sixthColum = Convert.ToInt32(textBox4.Text);
            int seventh = Convert.ToInt32(textBox5.Text);
            string eighth = comboBox2.SelectedItem.ToString();

            table.Rows.Add(firstColum, secondColum, thirdColum, dateColum, fifthColum, sixthColum, seventh, eighth);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            d.connecter();
            //if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||  textBox6.Text == "")
            if (textBox2.Text == "")
            {
                MessageBox.Show("Merci de remplir au moin le code");
                return; //break if the program enters this if
            }
            //securite
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                try
                {
                    if (ajouter() == true)
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
                        //AddARow(d.dt);
                        remplirgrid();
                        textBox2.Focus();
                        labelTotalResult.Text = dataGridView1.RowCount.ToString();
                        //cas 3adi dataGridView1.Rows.Add(textBox1.Text, textBox1.Text, textBox3.Text, textBox4, dateTimePicker1.Value, textBox5, textBox6);  
                    }
                    else
                    {
                        MessageBox.Show("Ce produit exist deja");
                    }
                }
                catch { MessageBox.Show("verifier que le fournisseur existe deja"); }

            }
            //this.ActiveControl = textBox1;
        }

        public bool modifier()
        {
            if (nombre() != 0)
            {
                //darori les collones lli fihom des character ydar wsthom 'txtnom.Text' matalan
                d.sQLiteCommand.CommandText = "update produits set produit_nom = '" + textBox2.Text + "',fournisseur_de_produit ='" + comboBox1.SelectedItem.ToString() + "',produit_date_entre ='" + dateTimePicker1.Value.ToShortDateString() + "',produit_prix_dachat ='" + textBox3.Text + "',produit_prix_de_vente ='" + textBox4.Text + "'" + ",produit_profit_net = '" + textBox5.Text + "'" + ",produit_qualite = '" + comboBox2.SelectedItem.ToString() + "'  where produit_code = '" + textBox1.Text + "'";
                d.sQLiteCommand.Connection = d.sqliteConnection;
                d.sQLiteCommand.ExecuteNonQuery();
                return true;// important tdir return true et false lfcode dyalek
            }
            return false;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("veuillez selectionne le produit a modifier");
                textBox1.Focus();
                return; //break if the program enters this if
            }

            //securite
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                try
                {
                    //ila drti methode fbutton f if rah katkhdm
                    if (modifier() == true)
                    {
                        MessageBox.Show("Ce produit est modifie avec succes");

                        updatefromgridview(dataGridView1, textBox1, d.dataTable);
                        textBox1.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ce produit n'exist pas");
                    }
                }
                catch
                {
                    MessageBox.Show("verifier que le fournisseur existe deja");
                }
            }
        }

        public void vider()
        {
            //if (MessageBox.Show("Vouler vous vider tous les champs? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            //}
        }

        private void btnVider_Click(object sender, EventArgs e)
        {
            vider();
            textBox2.Focus();
        }

        public void supprimer()
        {
            //darori les collones lli fihom des character ydar wsthom 'txtnom.Text' matalan

            //en cas dyal foreign key khassk tms7 les info dyalo mn table secondaire 3ad mn be3d katchof table li fiha cle primaire wkatms7 ligne dyalo
            //d.cmd.CommandText = "delete from examen where Matricule_Stagiaire = " + textBox1.Text;
            //d.cmd.Connection = d.con;
            //d.cmd.ExecuteNonQuery();

            d.sQLiteCommand.CommandText = "delete from produits where produit_code = '" + textBox1.Text + "'";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            d.sQLiteCommand.ExecuteNonQuery();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Merci de selectionner le produit a supprimer");
                textBox1.Focus();
                return; //break if the program enters this if
            }
            //securite
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                //ila drti methode fbutton f if rah katkhdm
                if (nombre() == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("voulez vous vraiment supprimer ce produit", "Alert", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        supprimer();

                        d.deleteRowFromDgv(dataGridView1, textBox1);

                        labelTotalResult.Text = dataGridView1.RowCount.ToString();

                        //on vide les champs
                        vider();
                    }
                    //else if (dialogResult == DialogResult.No)
                    //{
                    //    MessageBox.Show("Operation annulee");
                    //}
                }
                else if (nombre() == 0)
                {
                    MessageBox.Show("Ce produit n'exist pas");
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
                comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                DateTime dateSelectionne = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                dateTimePicker1.Value = dateSelectionne.Date;
                textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            catch { }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextboxDesInt_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
