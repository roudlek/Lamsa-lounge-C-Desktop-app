using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CRUDapp
{
    class ado
    {
        public SQLiteCommand sQLiteCommand = new SQLiteCommand();
        public SQLiteCommandBuilder sqliteCommandBuilder = new SQLiteCommandBuilder();
        public SQLiteConnection sqliteConnection = new SQLiteConnection();
        public SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter();
        public SQLiteDataReader sqliteDataReader;
        public DataSet dataSet = new DataSet();
        public DataTable dataTable = new DataTable();
        public DataTable dataTable2 = new DataTable();


        public void connecter()
        {
            if (sqliteConnection.State == ConnectionState.Broken || sqliteConnection.State == ConnectionState.Closed)
            {
                //con.ConnectionString = @"Data Source =.;Initial Catalog=gestion_business;User ID=DESKTOP-8TV0JP0;Password=123456;Connection Timeout=300;Trusted_Connection=Yes";
                //con.ConnectionString = @"Data Source=(local);Initial Catalog=gestion_business;Integrated Security=True";
                sqliteConnection.ConnectionString = "Data Source=lamsaloungedatabase.db;Version=3;";
                sqliteConnection.Open();
            }
        }

        public void deconnecter()
        {
            if (sqliteConnection.State == ConnectionState.Open)
            {
                sqliteConnection.Close();
            }
        }
        public void closeDataReader()
        {
            // Close any active DataReader
            if (sqliteDataReader != null && !sqliteDataReader.IsClosed)
            {
                sqliteDataReader.Close();
            }
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
    }
}
