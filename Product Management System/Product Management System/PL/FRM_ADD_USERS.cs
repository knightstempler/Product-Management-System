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
    public partial class FRM_ADD_USERS : Form
    {
        BL.login user = new BL.login();
        public FRM_ADD_USERS()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtID.Text == string.Empty)
            {
                MessageBox.Show("رجاء ادخل اسم المستخدم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
                return;
            }
            if (txtFullName.Text == string.Empty)
            {
                MessageBox.Show("رجاء ادخل اسم كامل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return;
            }
            if (txtPWD.Text == string.Empty)
            {
                MessageBox.Show("رجاء ادخل كلمة سر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPWD.Focus();
                return;
            }
            if (txtPWDConfirm.Text == string.Empty)
            {
                MessageBox.Show("رجاء ادخل كلمة سر تأكيد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPWDConfirm.Focus();
                return;
            }
            if(comType.SelectedItem == null)
            {
                MessageBox.Show("رجاء اختار نوع المستخدم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comType.Focus();
                return;
            }

            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show("كلمات السر غير المتطابقة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPWDConfirm.Focus();
                return;
            }

            if (btnSave.Text == "اضافة المستخدم")
            {
                user.ADD_USER(txtID.Text, txtPWD.Text, comType.Text, txtFullName.Text);
                MessageBox.Show("تم اضافة المستخدم بالنجاح", "تم اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (btnSave.Text == "حفظ المستخدم")
            {
                user.ADD_USER(txtID.Text, txtPWD.Text, comType.Text, txtFullName.Text);
                MessageBox.Show("تم الحفظ المستخدم بالنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (btnSave.Text == "تعديل المستخدم")
            {
                txtID.Enabled = false;
                user.EDIT_USER(txtID.Text, txtPWD.Text, comType.Text, txtFullName.Text);
                MessageBox.Show("تم تعدیل المستخدم بالنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtID.Clear();
            txtFullName.Clear();
            txtPWD.Clear();
            txtPWDConfirm.Clear();
            comType.SelectedItem = null;
            txtID.Focus();
        }

        private void comType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPWDConfirm_Validated(object sender, EventArgs e)
        {
            if(txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show("كلمات السر غير المتطابقة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
