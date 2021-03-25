using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Product_Management_System.PL
{
    public partial class FRM_ADD_PRODUCT : Form
    {

        public string states = "add";

        BL.CLS_PRODCUT prd = new BL.CLS_PRODCUT();
        public FRM_ADD_PRODUCT()
        {
            InitializeComponent();

            comCategores.DataSource = prd.GET_ALL_CATEGORES();
            comCategores.DisplayMember = "DESCRIPTION_CAT";
            comCategores.ValueMember = "ID_CAT";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images File | *.JPG; *.PNG; *.JPEG; *.GIF; *.BMP";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FRM_ADD_PRODUCT_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(states == "add") { 

                if (txtRef.Text == "")
                {
                    MessageBox.Show("رجاء ادخل معرف المنتوج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRef.Focus();
                    return;
                }if(txtDes.Text == "")
                {
                    MessageBox.Show("رجاء ادخل وصف المنتوج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDes.Focus();
                    return;
                }
                if (txtQte.Value == 0)
                {
                    MessageBox.Show("رجاء ادخل الكمية المخزنة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQte.Focus();
                    return;
                }
                if (txtPrice.Text == "")
                {
                    MessageBox.Show("رجاء ادخل ثمن المنتوج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrice.Focus();
                    return;
                }

                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                prd.ADD_PRODUCT(Convert.ToInt32(comCategores.SelectedValue), txtRef.Text , txtDes.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text,byteImage);

                MessageBox.Show("تم اضافة بنجاح", "عملية الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtDes.Clear();
                txtPrice.Clear();
                txtQte.Text = "0";
                txtRef.Clear();
            }

            else
            {

                if (txtDes.Text == "")
                {
                    MessageBox.Show("رجاء ادخل وصف المنتوج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDes.Focus();
                    return;
                }
                if (txtQte.Value == 0)
                {
                    MessageBox.Show("رجاء ادخل الكمية المخزنة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQte.Focus();
                    return;
                }
                if (txtPrice.Text == "")
                {
                    MessageBox.Show("رجاء ادخل ثمن المنتوج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrice.Focus();
                    return;
                }

                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                prd.UPDATE_PRODUCT(Convert.ToInt32(comCategores.SelectedValue), txtRef.Text, txtDes.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);

                MessageBox.Show("تم تحدیث بنجاح", "عملية التحديث", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }

            FRM_PRODUCT.getMainForm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();

        }

        private void txtQte_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtRef_Validated(object sender, EventArgs e)
        {

            if (states == "add")
            {
                DataTable Dt = new DataTable();
                Dt = prd.VerifyProductID(txtRef.Text);
                if (Dt.Rows.Count > 0)
                {
                    MessageBox.Show("معرف منتج موجود رجاء اكتب اسم منتوج اخر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRef.Focus();
                    txtRef.SelectionStart = 0;
                    txtRef.SelectionLength = txtRef.TextLength;
                }
            }
        }

        private void txtRef_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
