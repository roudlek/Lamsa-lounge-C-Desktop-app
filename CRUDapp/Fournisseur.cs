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
    public partial class Fournisseur : Form
    {
        public Fournisseur()
        {
            InitializeComponent();
        }

        ado d = new ado();
        //Declaration de la methode qui va nous dire si le matricule existe qui retourne(1) un entier 
        public int nombre()
        {
            int cpt; // compteur
            d.sQLiteCommand.CommandText = "select count(Fournisseur_Code) from Fournisseurs where Fournisseur_Nom = '" + textBox1.Text + "' and Fournisseur_tel = '"+ textBox2.Text + "'";
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
                d.sQLiteCommand.CommandText = "insert into Fournisseurs values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "')";
                d.sQLiteCommand.Connection = d.sqliteConnection;
                d.sQLiteCommand.ExecuteNonQuery();
                return true;// important tdir return true et false lfcode dyalek
            }
            return false;
        }

        //declaration de la methode supprimer
        public void supprimer()
        {

            //darori les collones lli fihom des character ydar wsthom 'txtnom.Text' matalan

            //en cas dyal foreign key khassk tms7 les info dyalo mn table secondaire 3ad mn be3d katchof table li fiha cle primaire wkatms7 ligne dyalo
            //d.cmd.CommandText = "delete from examen where Matricule_Stagiaire = " + textBox1.Text;
            //d.cmd.Connection = d.con;
            //d.cmd.ExecuteNonQuery();

            d.sQLiteCommand.CommandText = "delete from Fournisseurs where Fournisseur_nom = '" + textBoxCode.Text + "'";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            d.sQLiteCommand.ExecuteNonQuery();

        }
        public bool modifier()
        {
            //if (nombre() != 0)
            //{
                //darori les collones lli fihom des character ydar wsthom 'txtnom.Text' matalan
                d.sQLiteCommand.CommandText = "update Fournisseurs set Fournisseur_Nom ='" + textBox1.Text + "' ,Fournisseur_tel = '" + textBox2.Text + "',Fournisseur_date_entre ='" + dateTimePicker1.Value.ToShortDateString() + "',Fournisseur_localisation ='" + textBox3.Text + "',Fournisseur_Argent_depense ='" + textBox4.Text + "',Fournisseur_Reste_a_payer ='" + textBox5.Text + "',Fournisseur_cheque ='" + comboBox1.Text + "'  where Fournisseur_Code = '" + textBoxCode.Text + "'";
                d.sQLiteCommand.Connection = d.sqliteConnection;
                d.sQLiteCommand.ExecuteNonQuery();
                return true;// important tdir return true et false lfcode dyalek
            //}
            //return false;
        }
        public void vider()
        {
            //if (MessageBox.Show("Vouler vous vider tous les champs? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            textBoxCode.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = comboBox1.Items[1].ToString();
            //}
        }

        public void remplirgrid()
        {
            if (d.dataTable.Rows != null)
            {
                d.dataTable.Clear();
            }
            d.sQLiteCommand.CommandText = "select Fournisseur_Code Code, Fournisseur_nom Nom, Fournisseur_tel Telephone, Fournisseur_date_entre 'Date d''entree', Fournisseur_localisation Localisation, Fournisseur_Argent_depense 'Argent dépensé',Fournisseur_Reste_a_payer 'Reste a payer',Fournisseur_cheque Cheque from Fournisseurs order by Fournisseur_Code desc";
            d.sQLiteCommand.Connection = d.sqliteConnection;
            d.sqliteDataReader = d.sQLiteCommand.ExecuteReader();
            d.dataTable.Load(d.sqliteDataReader);
            dataGridView1.DataSource = d.dataTable;
            d.sqliteDataReader.Close();
        }

        public static bool nonvide = true;
        public static bool prevent = true;
        public void hasSpecialChar(string input)
        {
            char[] specialChar = { '(', ')', ';', '\'', '/' };
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
            prevent_sqlInj(textBox5);
            if (prevent == false) return;
            preventSqlInjfromcombobox(comboBox1);
            if (prevent == false) return;            
        }

        public void preventSqlInjfromcombobox(ComboBox CB)
        {
            hasSpecialChar(CB.Text);
        }

        public void prevent_sqlInj(TextBox TB)
        {
            hasSpecialChar(TB.Text);
        }

        private void AddARow(DataTable table)
        {
            // Use the NewRow method to create a DataRow with 
            // the table's schema.
            // Add the row to the rows collection.
            //int firstColum = Convert.ToInt32(textBoxCode.Text);
            string firstColum;
            if (textBoxCode.Text == "") firstColum = "0";
            else
                firstColum = textBoxCode.Text;

            string secondColum1 = textBox1.Text;
            string secondColum2 = textBox2.Text;
            string dateColum = dateTimePicker1.Value.ToShortDateString();
            string thirdColum = textBox3.Text;

            string FourthColum;
            if(textBox4.Text == "")  FourthColum = "0"; 
            else
                FourthColum = textBox4.Text;

            string FifthColum;
            if (textBox5.Text == "") FifthColum = "0";
            else
                FifthColum = textBox5.Text;

            string SixthColum = comboBox1.Text;
            //string[] row = { firstColum, secondColum, dateColum, thirdColum, FourthColum, FifthColum, SixthColum };

            table.Rows.Add(firstColum,secondColum1, secondColum2, dateColum, thirdColum, FourthColum, FifthColum, SixthColum);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Merci de remplir au moin le nom de fournisseur");
                textBox1.Focus();
                return; //break if the program enters this if
            }
            //securite
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                    //ila drti methode fbutton f if rah katkhdm
                try
                {
                    if (ajouter() == true)
                    {
                        remplirgrid();

                        //MessageBox.Show("Cette Cliente est ajoutee avec succes");
                        //int rowIndex = -1;
                        //foreach (DataGridViewRow row in dataGridView1.Rows)
                        //{
                        //    if (row.Cells[0].Value.ToString().Equals(textBox1.Text))
                        //    {
                        //        rowIndex = row.Index;
                        //        dataGridView1.Rows[rowIndex].Selected = true;
                        //        break;
                        //    }
                        //}
                        int rowIndex = -1;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["Code"].Value != null) // Need to check for null if new row is exposed
                            {
                                if (row.Cells["Code"].Value.ToString().Equals(textBox1.Text))
                                {
                                    rowIndex = row.Index;
                                    //dataGridView1.Rows[rowIndex].Selected = true;
                                    break;
                                }
                            }
                        }
                        this.pictureBox1.Visible = true;
                        Task.Run(() =>
                        {
                            Thread.Sleep(2000);
                            this.Invoke(new Action(() =>
                            {
                                this.pictureBox1.Visible = false;
                            }));
                        });
                        labelTotalResult.Text = dataGridView1.RowCount.ToString();
                        comboBox1.Text = comboBox1.Items[1].ToString();
                        textBox1.Focus();

                        //cas 3adi dataGridView1.Rows.Add(textBox1.Text, textBox1.Text, textBox3.Text, textBox4, dateTimePicker1.Value, textBox5, textBox6);  
                    }
                    else
                    {
                        MessageBox.Show("Ce fournisseur exist deja");
                    }
                }
                
                catch
                {
                    MessageBox.Show("Verifier les prix");
                }
            }
            //this.ActiveControl = textBox1;
        }

        public void deleteRowFromDgv(DataGridView DGV, TextBox TB)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(TB.Text))
                {
                    DGV.Rows.Remove(row);
                    //dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Code"].Value.ToString() == textBox1.Text).Select(s => s.Index).FirstOrDefault());
                }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("selectionner d'abord le fournisseur");
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
                        MessageBox.Show("Ce fournisseur est modifie avec succes", "what");

                        updatefromgridview(dataGridView1, textBoxCode, d.dataTable);
                        textBox1.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ce fournisseur n'exist pas");
                    }
                }
                catch
                {
                    MessageBox.Show("Verifier les prix");
                }
            }
        }

        public void updatefromgridview(DataGridView DGV, TextBox TB, DataTable table)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(TB.Text))
                {
                    row.Cells[1].Value = textBox1.Text;
                    row.Cells[2].Value = textBox2.Text;
                    row.Cells[3].Value = dateTimePicker1.Value.ToShortDateString();
                    row.Cells[4].Value = textBox3.Text;

                    //if(row.Cells[4].Value.Equals(""))
                    //row.Cells[4].Value = "0";
                    //else row.Cells[4].Value = Convert.ToInt32(textBox4.Text);

                    if (textBox4.Text == "")
                        row.Cells[5].Value = "0";
                    else row.Cells[5].Value = Convert.ToInt32(textBox4.Text);

                    if (textBox5.Text == "")
                        row.Cells[6].Value = "0";
                    else row.Cells[6].Value = Convert.ToInt32(textBox5.Text);
                    
                    row.Cells[7].Value = comboBox1.Text;
                    break;
                }
            }
        }

        private void btnVider_Click(object sender, EventArgs e)
        {
            vider();
            comboBox1.Text = comboBox1.Items[1].ToString();
            textBox1.Focus();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Merci de selectionner le fournisseur a supprimer");
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
                    DialogResult dialogResult = MessageBox.Show("voulez vous vraiment supprimer ce fournisseur", "Alert", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        supprimer();

                        deleteRowFromDgv(dataGridView1, textBoxCode);

                        labelTotalResult.Text = dataGridView1.RowCount.ToString();

                        //on vide les champs
                        vider();
                        comboBox1.Text = comboBox1.Items[1].ToString();

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Operation annulee");
                    }
                }
                else if (nombre() == 0)
                {
                    MessageBox.Show("Ce fournisseur n'exist pas");
                }
            }
        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;

            textBox1.Focus();

            d.connecter();
            remplirgrid();
            dataGridView1.ReadOnly = true;
            labelTotalResult.Text = dataGridView1.RowCount.ToString();

            textBox4.Text = "0";
            textBox5.Text = "0";
            comboBox1.Text = comboBox1.Items[1].ToString();

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
         try               
            {
                //var ind = dataGridView1.CurrentRow.Index;
                textBoxCode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                DateTime dateSelectionne = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                dateTimePicker1.Value = dateSelectionne.Date;
                textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox1.Text= dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            catch { }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        
    }
}
