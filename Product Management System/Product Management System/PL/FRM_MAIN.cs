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
    public partial class FRM_MAIN : Form
    {
        // code to pudate in another form
        private static FRM_MAIN frm;
        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_MAIN getMainForm
        {
            get
            {
                if(frm == null)
                {
                    frm = new FRM_MAIN();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }

        public FRM_MAIN()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;

            this.المنتوجاتToolStripMenuItem.Enabled = false;
            this.المستخدمونToolStripMenuItem.Enabled = false;
            this.العملاءToolStripMenuItem.Enabled = false;
        }

        private void انشاءالنسخةالاحطياتيةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void استادةنسخةالمحفوظةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void اظافةصنفالجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void main_form_Load(object sender, EventArgs e)
        {

        }

        private void تسجیلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login_Form loginuser = new Login_Form();
            loginuser.Show();
        }

        private void الخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void المستخدمونToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void اظافةالمنتوجالجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm_add = new FRM_ADD_PRODUCT();
            frm_add.ShowDialog();
        }

        private void اظافةمستخدامجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_USERS frm = new FRM_ADD_USERS();
            frm.ShowDialog();
        }

        private void ادارةالمنتوجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PRODUCT frm = new FRM_PRODUCT();
            frm.ShowDialog();
        }

        private void ادارةالاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frm = new FRM_CATEGORIES();
            frm.ShowDialog();
        }

        private void ادارةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.FRM_CUSTOMERS frm = new FRM_CUSTOMERS();
            frm.ShowDialog();
        }

        private void ادارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.FRM_ORDER_LIST frm = new FRM_ORDER_LIST();
            frm.ShowDialog();
        }

        private void اظافةبيعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDER frm = new FRM_ORDER();
            frm.ShowDialog();
        }

        private void ادارةالمستخدمونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USER_LIST frm = new FRM_USER_LIST();
            frm.ShowDialog();
        }

        private void انشاءالنسخةالاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_BACKUP frm = new FRM_BACKUP();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
