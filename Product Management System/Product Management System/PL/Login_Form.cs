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
    public partial class Login_Form : Form
    {

        BL.login log = new BL.login();

        public Login_Form()
        {
            
            InitializeComponent();

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textID.Text == "")
            {
                MessageBox.Show("رجاء ادخل اسم المستخدام‌", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textID.Focus();
                return;
            }
            if (textPWD.Text == "")
            {
                MessageBox.Show("رجاء ادخل كلمة المرور", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPWD.Focus();
                return;
            }

            DataTable Dt = log.LOGIN(textID.Text, textPWD.Text);

            if (Dt.Rows.Count > 0)
            {
                if(Dt.Rows[0][2].ToString() == "admin") {
                    FRM_MAIN.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.المستخدمونToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.المستخدمونToolStripMenuItem.Visible = true;
                    FRM_MAIN.getMainForm.المنتوجاتToolStripMenuItem.Enabled = true;
                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();
                    this.Close();
                }else if (Dt.Rows[0][2].ToString() == "user")
                {
                    FRM_MAIN.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.المستخدمونToolStripMenuItem.Visible = false;
                    FRM_MAIN.getMainForm.المنتوجاتToolStripMenuItem.Enabled = true;
                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("دخول غير ناجح", "خطأ ‌", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textID.Clear();
            textPWD.Clear();
            textID.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
