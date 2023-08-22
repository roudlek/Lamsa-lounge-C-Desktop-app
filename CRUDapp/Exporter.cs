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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;

namespace CRUDapp
{
    public partial class Exporter : Form
    {
        ado d = new ado();
        public Exporter()
        {
            InitializeComponent();
        }


        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //string[] files = Directory.GetFiles(fbd.SelectedPath);
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    txtChemin.Text = fbd.SelectedPath;

                    progressBar1.Value = 0;
                    try
                    {
                        Server dbserver = new Server(new ServerConnection(txtServer.Text));
                        Backup dbBackup = new Backup() { Action = BackupActionType.Database, Database = txtDatabase.Text };
                        dbBackup.Devices.AddDevice(@txtChemin.Text + @"\" + txtFilaname.Text + ".bak", DeviceType.File);
                        //dbBackup.Devices.AddDevice(@"C:\Backups\gestion-business.bak", DeviceType.File);
                        dbBackup.Initialize = true;
                        dbBackup.PercentComplete += dbBackup_PercentComplete;
                        dbBackup.Complete += dbBackup_Complete;
                        dbBackup.SqlBackupAsync(dbserver);
                        MessageBox.Show("done!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message d'erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                labelStatus.Invoke((MethodInvoker)delegate
                {
                    labelStatus.Text = e.Error.Message;
                });
            }
        }

        private void dbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });
            labelPercent.Invoke((MethodInvoker)delegate
            {
                labelPercent.Text = e.Percent.ToString() + "%";
            });
        }


















        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

        private void labelPercent_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exporter_Load(object sender, EventArgs e)
        {
            //pictureBox1.SendToBack();
        }


    }
}
