using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Management_System.PL
{
    public partial class FRM_USER_LIST : Form
    {
        BL.login users = new BL.login();
        public FRM_USER_LIST()
        {
            InitializeComponent();
            this.dvgusers.DataSource = users.SEARCH_USERS("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_USERS frm = new FRM_ADD_USERS();
            frm.btnSave.Text = "حفظ المستخدم";
            frm.ShowDialog();
            dvgusers.DataSource = users.SEARCH_USERS("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_ADD_USERS frm = new FRM_ADD_USERS();
            frm.txtID.Text = dvgusers.CurrentRow.Cells[0].Value.ToString();
            frm.txtFullName.Text = dvgusers.CurrentRow.Cells[1].Value.ToString();
            frm.txtPWD.Text = dvgusers.CurrentRow.Cells[2].Value.ToString();
            frm.txtPWDConfirm.Text = dvgusers.CurrentRow.Cells[2].Value.ToString();
            frm.comType.Text = dvgusers.CurrentRow.Cells[3].Value.ToString();
            frm.btnSave.Text = "تعديل المستخدم";
            frm.ShowDialog();
            dvgusers.DataSource = users.SEARCH_USERS("");
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            this.dvgusers.DataSource = users.SEARCH_USERS(txtsearch.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد فعلا حذف المستخدم", "تنبيه هام", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                users.DELETE_USER(dvgusers.CurrentRow.Cells[0].Value.ToString());

                MessageBox.Show("تم الحذف المستخدم بالنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dvgusers.DataSource = users.SEARCH_USERS("");
            }
            else
            {
                return;
            }
        }
    }
}
