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



namespace Product_Management_System.PL
{
    public partial class FRM_BACKUP : Form
    {
        SqlConnection con = new SqlConnection("Server=DELL-DESKTOP; Database=master; Integrated Security = True ");
        SqlCommand cmd;
        public FRM_BACKUP()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string FileBackupName = txtFileName.Text + "\\Product_DB" + DateTime.Now.ToShortDateString().Replace('/','-') +
                                    " - " + DateTime.Now.ToLongDateString().Replace(':', '-');

            string QueryBackup = "Backup Database Product_DB to Disk= '"+ FileBackupName + ".bak'   ";

            cmd = new SqlCommand(QueryBackup, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحفظ النسخة احتياطية من القاعدة البيانات بنجاح ", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string QueryRestore = "ALTER Database Product_DB  SET OFFLINE WITH ROLLBACK IMMEDIATE ;Restore Database Product_DB From Disk= '" + txtFileNameRestore.Text + "' WITH REPLACE  ";

            cmd = new SqlCommand(QueryRestore, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم استعادة النسخة احتياطية من القاعدة البيانات بنجاح ", "تم استعادة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileNameRestore.Text = openFileDialog1.FileName;
            }
        }
    }
}
