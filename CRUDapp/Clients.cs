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
using System.Text.RegularExpressions;
using System.IO;


namespace CRUDapp
{
    public partial class ModificationClients : Form
    {
        public ModificationClients()
        {
            InitializeComponent();

            //this.WindowState = FormWindowState.Maximized;
            //int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //Resolution objFormResizer = new Resolution();
            //objFormResizer.ResizeForm(this, screenHeight, screenWidth);
        }
        ado activeDataObject = new ado();

        //---------------------------
        //public void checkIfTBisEmpty(TextBox TB)
        //{
        //    if (TB.Text == "")
        //    {
        //        MessageBox.Show("Champ obligatoires");
        //        nonvide = false;
        //        return;
        //    }
        //}

        //--------------------
        public static bool nonvide = true;
        public static bool prevent = true;
        public void hasSpecialChar(string input)
        {
            char[] specialChar = { '(', ')',';','\'',',','/' };
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
        public void preventSqlInjfromcombobox(ComboBox CB)
        {
            hasSpecialChar(CB.Text);
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
            prevent_sqlInj(textboxrecherche);
            if (prevent == false) return;
            preventSqlInjfromcombobox(comboBox1);
            if (prevent == false) return;
            preventSqlInjfromcombobox(comboBox2);
            if (prevent == false) return;
            preventSqlInjfromcombobox(comboBox3);
            if (prevent == false) return;
            preventSqlInjfromcombobox(comboBox4);
            if (prevent == false) return;
            preventSqlInjfromcombobox(comboBox5);
            if (prevent == false) return;
        }

        //---------------------------
        public void remplirgrid()
        {
            try
            {
                if (activeDataObject.dataTable.Rows != null)
                {
                    activeDataObject.dataTable.Clear();
                }
                activeDataObject.sQLiteCommand.CommandText = "select client_code Code,client_nom Nom, client_prenom Prenom, client_tel Telephone, client_date_entree as dateDentree, client_fidele Fidélité, client_type Type,client_Place_de_travail Job,client_Etat Etat, client_Commentaire commentaire, Client_image Image from Clients order by client_code desc";
                activeDataObject.sQLiteCommand.Connection = activeDataObject.sqliteConnection;
                activeDataObject.sqliteDataReader = activeDataObject.sQLiteCommand.ExecuteReader();
                activeDataObject.dataTable.Load(activeDataObject.sqliteDataReader);
                dataGridView1.DataSource = activeDataObject.dataTable;
                activeDataObject.sqliteDataReader.Close();
            }
            catch (Exception e)
            {
                
            }
        }

        //Declaration de la methode qui va nous dire si le matricule existe qui retourne(1) un entier 
        public int nombre()
        {
            int compteur; // compteur
            activeDataObject.sQLiteCommand.CommandText = "select count(client_code) from clients where client_nom = @client_nom and client_prenom = '" + textBox3.Text + "' and client_tel = '" + textBox4.Text + "'";
            activeDataObject.sQLiteCommand.Connection = activeDataObject.sqliteConnection;
            activeDataObject.sQLiteCommand.Parameters.AddWithValue("@client_nom",textBox2.Text);
            compteur = Convert.ToInt32(activeDataObject.sQLiteCommand.ExecuteScalar());
            return compteur;
        }
        
        //declaration de la methode ajouter
        public bool ajouter()
        {
            if (nombre() == 0)
            {
                //",Client_image = '" + ?? +
                //darori les collones lli fihom des character ydar wsthom 'txtnom.Text' matalan

                activeDataObject.sQLiteCommand.CommandText = "insert into clients(client_nom,client_prenom ,client_tel,client_date_entree ,client_fidele ,client_type,client_Place_de_travail,client_Etat,client_Commentaire,Client_image) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox5.Text + "', @Client_image  )";
                MemoryStream memstr = new MemoryStream();
                pictureBox2.Image.Save(memstr, pictureBox2.Image.RawFormat);
                activeDataObject.sQLiteCommand.Parameters.AddWithValue("Client_image",memstr.ToArray());
                activeDataObject.sQLiteCommand.Connection = activeDataObject.sqliteConnection;
                activeDataObject.sQLiteCommand.ExecuteNonQuery();
                
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

                activeDataObject.sQLiteCommand.CommandText = "delete from clients where client_code = '" + textBox1.Text + "'";
                activeDataObject.sQLiteCommand.Connection = activeDataObject.sqliteConnection;
                activeDataObject.sQLiteCommand.ExecuteNonQuery();
        }
        public bool modifier()
        {

                //",Client_image = '" + ?? +
                //darori les collones lli fihom des character ydar wsthom 'txtnom.Text' matalan
                activeDataObject.sQLiteCommand.CommandText = "update clients set client_nom = '" + textBox2.Text + "',client_prenom ='" + textBox3.Text + "',client_tel ='" + textBox4.Text + "',client_date_entree ='" + dateTimePicker1.Value.ToShortDateString() + "',client_fidele ='" + comboBox2.Text + "',client_type ='" + comboBox3.Text + "',client_Place_de_travail ='" + comboBox4.Text + "',client_Etat ='" + comboBox5.Text + "' ,client_Commentaire = '" + textBox5.Text + "' ,client_image = @C_image where client_code = '" + Convert.ToInt32(textBox1.Text) + "'";
                MemoryStream memstr = new MemoryStream();
                pictureBox2.Image.Save(memstr, pictureBox2.Image.RawFormat);
                activeDataObject.sQLiteCommand.Parameters.AddWithValue("C_image", memstr.ToArray());
                activeDataObject.sQLiteCommand.Connection = activeDataObject.sqliteConnection;
                activeDataObject.sQLiteCommand.ExecuteNonQuery();
                //d.cmd.Parameters.Clear();
                return true;// important tdir return true et false lfcode dyalek

        }
        public void vider()
        {
            //if (MessageBox.Show("Vouler vous vider tous les champs? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                dateTimePicker1.Value = DateTime.Now;

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static int H;

        public void heighCode(int a)
        {
            try
            {
                H = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) > H)
                        H = Convert.ToInt32(row.Cells[0].Value);
                }
                LabelLastcode.Text = (H + a).ToString();
            }
            catch { }
        }
        private void Clients_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;
            
            textBox2.Focus();

            activeDataObject.connecter();
            remplirgrid();
            dataGridView1.ReadOnly = true;
            labelTotalResult.Text = dataGridView1.RowCount.ToString();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Text = comboBox1.Items[1].ToString();

            textBox4.Text  = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox5.Text  = "";


            dataGridView1.RowTemplate.Height = 80;

            dataGridView2.RowTemplate.Height = 50;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }

            heighCode(0);
            //heighCode(dataGridView1,0) ;


            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            remplirgrid();
        }

        private void btnVider_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Clients_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAfficher_Click_1(object sender, EventArgs e)
        {
            //remplirgrid();

            //int count = dataGridView1.RowCount - 1;
            //labelTotalResult.Text = count.ToString();
            // with allowUsersToAddRows proprety set to false
            //textBox1.Focus();

            //labelTotalResult.Text = dataGridView1.RowCount.ToString();
        }


        private void AddARow(DataTable table)
        {
            // Use the NewRow method to create a DataRow with 
            // the table's schema.
            // Add the row to the rows collection.
            int firstColum = Convert.ToInt32(LabelLastcode.Text ) ;
            //Convert.ToInt32(LabelLastcode.Text = LabelLastcode.Text + 1);
            string secondColum = textBox2.Text;
            string thirdColum = textBox3.Text;
            string fourthColum = textBox4.Text;
            string dateColum = dateTimePicker1.Value.ToShortDateString();
            string fifthColum = comboBox2.Text;
            string sixthColum = comboBox3.Text;
            string seventhColumn = comboBox4.Text;
            string eighthColumn = comboBox5.Text;
            string ninethcolumn = textBox5.Text;
            //string tenthcolumn = pictureBox2.Image;

            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms,pictureBox2.Image.RawFormat);
            byte[] tenthcolumn = ms.ToArray();


            //string[] row = { firstColum, secondColum, thirdColum, fourthColum, dateColum, fifthColum, sixthColum, seventhColumn, eighthColumn, ninethcolumn};

            table.Rows.Add(firstColum, secondColum, thirdColum, fourthColum, dateColum, fifthColum, sixthColum, seventhColumn, eighthColumn, ninethcolumn, tenthcolumn);
        }
        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            //if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||  textBox6.Text == "")
            if (textBox2.Text == "" )
            {
                MessageBox.Show("Merci de remplir au moin le nom et le prenom ");
                textBox2.Focus();
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
                        activeDataObject.sQLiteCommand.Parameters.Clear();
                        int a = Convert.ToInt32(LabelLastcode.Text) + 1;
                        LabelLastcode.Text = a.ToString();

                        AddARow(activeDataObject.dataTable);

                        vider();
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
                        //int rowIndex = -1;
                        //foreach (DataGridViewRow row in dataGridView1.Rows)
                        //{
                        //    if (row.Cells["Code"].Value != null) // Need to check for null if new row is exposed
                        //    {
                        //        if (row.Cells["code"].Value.ToString().Equals(textBox1.Text))
                        //        {
                        //            rowIndex = row.Index;
                        //            //dataGridView1.Rows[rowIndex].Selected = true;
                        //            break;
                        //        }
                        //    }
                        //}
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
                        pictureBox2.Image = CRUDapp.Properties.Resources.uknown;
                        textBox2.Focus();

                        //cas 3adi dataGridView1.Rows.Add(textBox1.Text, textBox1.Text, textBox3.Text, textBox4, dateTimePicker1.Value, textBox5, textBox6);  
                    }
                    else
                    {
                        MessageBox.Show("Cette Cliente exist deja");
                    }
                }
                catch
                { MessageBox.Show("verifier les informations"); }
            }
            //this.ActiveControl = textBox1;

        }


        //private void btnRechercher_Click_1(object sender, EventArgs e)
        //{
        //    d.connecter();
        //    if (textboxrecherche.Text == "")
        //    {
        //        MessageBox.Show("veuillez entrer la cliente a recherche");
        //        return;
        //    }
        //    preventsqlInjFromAlltextboxes();
        //    if (prevent == true)
        //    {
        //        trouverCode(textboxrecherche,comboBox1);
        //    }
        //}



        private void dataGridView1_MouseClick_1(object sender, MouseEventArgs e)
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

                comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();


                textBox5.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[10].Value);
                pictureBox2.Image = Image.FromStream(ms);

            }
            catch { }
        }

        public void updatefromgridview(DataGridView DGV, TextBox TB,DataTable table )
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(TB.Text))
                {
                    row.Cells[1].Value = textBox2.Text;
                    row.Cells[2].Value = textBox3.Text;
                    row.Cells[3].Value = textBox4.Text;
                    row.Cells[4].Value = dateTimePicker1.Value.ToShortDateString();
                    row.Cells[5].Value = comboBox2.Text;
                    row.Cells[6].Value = comboBox3.Text;
                    row.Cells[7].Value = comboBox4.Text;
                    row.Cells[8].Value = comboBox5.Text;
                    row.Cells[9].Value = textBox5.Text;
                    row.Cells[10].Value = pictureBox2.Image;
                    
                    //// Use the NewRow method to create a DataRow with 
                    //// the table's schema.
                    //// Add the row to the rows collection.

                    //dataGridView1.CurrentRow.Cells[0] = textBox1.Text;
                    //textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    //textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                    //DateTime dateSelectionne = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                    //dateTimePicker1.Value = dateSelectionne.Date;

                    //textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    //textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                    //dgv_AgendaAfspraken.Rows[selectedRow].SetValues(textBox2.Text, textBox3.Text, textBox4.Text,dateTimePicker1.Value.ToShortDateString(), textBox5.Text, textBox6.Text);

                    //string firstColum = textBox1.Text;
                    //string secondColum = textBox2.Text;
                    //string thirdColum = textBox3.Text;
                    //string fourthColum = textBox4.Text;
                    //string dateColum = dateTimePicker1.Value.ToShortDateString();
                    //string fifthColum = textBox5.Text;
                    //string sixthColum = textBox6.Text;
                    //string[] r = {secondColum, thirdColum, fourthColum, dateColum, fifthColum,sixthColum};

                    //table.Rows.CopyTo(dataGridView1.Cells[0].Text);
                    //        //DGV.Rows.Remove(row);
                    //        //dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Code"].Value.ToString() == textBox1.Text).Select(s => s.Index).FirstOrDefault());
                }
            }
        }

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                MessageBox.Show("Merci de selectionner la cliente a modifier");
                textBox2.Focus();
                return; //break if the program enters this if
            }
            //securite
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                //ila drti methode fbutton f if rah katkhdm
                if (modifier() == true)
                {
                    activeDataObject.sQLiteCommand.Parameters.Clear();
                    MessageBox.Show("Cette cliente est modifie avec succes");

                    updatefromgridview(dataGridView1, textBox1, activeDataObject.dataTable);
                    updatefromgridview(dataGridView2, textBox1, activeDataObject.dataTable2);
                    textBox2.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Cette cliente n'exist pas");
                }
            }
        }

        private void btnVider_Click_1(object sender, EventArgs e)
        {
            vider();
            textBox1.Focus();
            pictureBox2.Image = CRUDapp.Properties.Resources.uknown;
        }

        public void deleteRowFromDgv(DataGridView DGV,TextBox TB)
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

        private void btnSupprimer_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Merci de selectionner la cliente a supprimer");
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
                 DialogResult dialogResult = MessageBox.Show("voulez vous vraiment supprimer cette cliente", "Alert", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {          
                    supprimer();

                    deleteRowFromDgv(dataGridView1, textBox1);
                    deleteRowFromDgv(dataGridView2, textBox1);

                    labelTotalResult.Text = dataGridView1.RowCount.ToString();
                    pictureBox2.Image = CRUDapp.Properties.Resources.uknown;                    
                    //on vide les champs
                    vider();
                }
                 else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Operation annulee");
                    }
             }
             else if(nombre() == 0)
                {
                    MessageBox.Show("Cette cliente n'exist pas");
                }
            }
        }
        //---------------------------
        private bool textBoxJustEntered = false;
        public void firstselect(TextBox TB)
        {
            TB.SelectAll();
            textBoxJustEntered = true;
        }
        public void afterselect(TextBox TB)
        {
            if (textBoxJustEntered)
            {
                TB.SelectAll();
            }
            textBoxJustEntered = false;
        }

        //evenements clicks :

        private void textBox1_Click(object sender, EventArgs e)
        {
            afterselect(textBox1);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            afterselect(textBox2);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            afterselect(textBox3);
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            afterselect(textBox4);
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            afterselect(textBox5);
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
        }
        //evenements enter :




        private void textBox1_Enter(object sender, EventArgs e)
        {
            firstselect(textBox1);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            firstselect(textBox2);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            firstselect(textBox3);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            firstselect(textBox4);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            firstselect(textBox5);
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
        }


        //public void trouverCode(TextBox TB, ComboBox CB)
        //{
        //    if (CB.SelectedItem != null)
        //    {
        //        // Determine the selected field from the ComboBox
        //        string selectedField = CB.SelectedItem.ToString();

        //        // Define the query template
        //        string queryTemplate = "SELECT client_code Code, client_nom Nom, client_prenom Prenom, client_tel Telephone, client_date_entree DateEntree, client_fidele Fidélité, client_type Type, client_Place_de_travail Job, client_Etat Etat, client_Commentaire commentaire, Client_image Image FROM Clients WHERE {0} LIKE @SearchText";

        //        // Define the column name based on the selected field
        //        string columnName = "";
        //        switch (selectedField)
        //        {
        //            case "Code":
        //                columnName = "client_code";
        //                break;
        //            case "Nom":
        //                columnName = "client_nom";
        //                break;
        //            case "Prenom":
        //                columnName = "client_prenom";
        //                break;
        //            case "Tel":
        //                columnName = "client_tel";
        //                break;
        //            default:
        //                // Handle any other cases or provide a default query
        //                break;
        //        }

        //        if (!string.IsNullOrEmpty(columnName))
        //        {
        //            // Construct the final query using the selected column name
        //            string finalQuery = string.Format(queryTemplate, columnName);

        //            // Clear parameters and set the query text
        //            activeDataObject.sQLiteCommand.Parameters.Clear();
        //            activeDataObject.sQLiteCommand.CommandText = finalQuery;
        //            activeDataObject.sQLiteCommand.Parameters.AddWithValue("@SearchText", "%" + TB.Text + "%");
        //        }
        //    }

        //    // Execute the query and populate the DataTable
        //    activeDataObject.sQLiteCommand.Connection = activeDataObject.sqliteConnection;
        //    activeDataObject.sqliteDataReader = activeDataObject.sQLiteCommand.ExecuteReader();
        //    activeDataObject.dataTable2.Load(activeDataObject.sqliteDataReader);
        //    dataGridView2.DataSource = activeDataObject.dataTable2;
        //    activeDataObject.sqliteDataReader.Close();
        //}


        public void trouverCode(TextBox TB, ComboBox CB)
        {
            //activeDataObject.closeDataReader();

            if (CB.SelectedItem != null)
            {
                string selectedField = CB.SelectedItem.ToString();
                //string queryTemplate = "SELECT client_code Code, client_nom Nom, client_prenom Prenom, client_tel Telephone, client_date_entree AS 'Date d''entrée', client_fidele Fidélité, client_type Type, client_Place_de_travail Job, client_Etat Etat, client_Commentaire commentaire, Client_image Image FROM Clients WHERE {0} LIKE @SearchText";

                string queryTemplate = "SELECT client_code Code, client_nom Nom, client_prenom Prenom, client_tel Telephone, client_date_entree DateEntree, client_fidele Fidélité, client_type Type, client_Place_de_travail Job, client_Etat Etat, client_Commentaire commentaire, Client_image Image FROM Clients WHERE {0} LIKE @SearchText";

                switch (selectedField)
                {
                    case "Code":
                        activeDataObject.sQLiteCommand.CommandText = string.Format(queryTemplate, "client_code");
                        break;
                    case "Nom":
                        activeDataObject.sQLiteCommand.CommandText = string.Format(queryTemplate, "client_nom");
                        break;
                    case "Prenom":
                        activeDataObject.sQLiteCommand.CommandText = string.Format(queryTemplate, "client_prenom");
                        break;
                    case "Tel":
                        activeDataObject.sQLiteCommand.CommandText = string.Format(queryTemplate, "client_tel");
                        break;
                    default:
                        // Handle any other cases or provide a default query
                        break;
                }
                //dsad
                activeDataObject.sQLiteCommand.Parameters.Clear();
                activeDataObject.sQLiteCommand.Parameters.AddWithValue("@SearchText", "%" + TB.Text + "%");
            }



            //activeDataObject.sQLiteCommand.CommandText = "select client_code Code, client_nom Nom, client_prenom Prenom, client_tel Telephone, client_date_entree as 'Date d''entrée', client_fidele Fidélité, client_type Type from Clients where " + CB.SelectedItem.ToString() + " like '%" + TB.Text + "%'";

            activeDataObject.sQLiteCommand.Connection = activeDataObject.sqliteConnection;
            activeDataObject.sqliteDataReader = activeDataObject.sQLiteCommand.ExecuteReader();
            activeDataObject.dataTable2.Load(activeDataObject.sqliteDataReader);
            dataGridView2.DataSource = activeDataObject.dataTable2;
            activeDataObject.sqliteDataReader.Close();
        }

        private void textboxrecherche_TextChanged(object sender, EventArgs e)
        {
            activeDataObject.connecter();
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                trouverCode(textboxrecherche, comboBox1);
            }
            dataGridView1.RowTemplate.Height = 30;

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView2.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                var ind = dataGridView2.CurrentRow.Index;
                textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();

                DateTime dateSelectionne = DateTime.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                dateTimePicker1.Value = dateSelectionne.Date;

                comboBox2.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                comboBox3.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                comboBox4.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                comboBox5.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();


                textBox5.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();

                MemoryStream ms = new MemoryStream((byte[])dataGridView2.CurrentRow.Cells[10].Value);
                pictureBox2.Image = Image.FromStream(ms);
            }
            catch { }
        }

        private void textboxrecherche_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "Select image(*.jpeg; *.jpg; *.png; *.gif) | *.jpeg; *.jpg; *.png; *.gif";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            //}
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.jpeg; *.jpg; *.png; *.gif) | *.jpeg; *.jpg; *.png; *.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void AllcontrolsKeyPressEvent(object sender, KeyPressEventArgs e)
        {
            //restrict user from entring special characters
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
              Char.IsSeparator(e.KeyChar) ||
              Char.IsSymbol(e.KeyChar);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeDataObject.connecter();
            preventsqlInjFromAlltextboxes();
            if (prevent == true)
            {
                trouverCode(textboxrecherche, comboBox1);
            }
            dataGridView1.RowTemplate.Height = 30;

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView2.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




    }
}
