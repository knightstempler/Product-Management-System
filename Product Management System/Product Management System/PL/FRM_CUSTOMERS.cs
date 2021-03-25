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
    public partial class FRM_CUSTOMERS : Form
    {
        BL.CLS_COSTOMERS cust = new BL.CLS_COSTOMERS();
        int ID,Position; // Varible to save value id customer
        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERES();
            // HIDE COLUMN id_CUSTOMER FROM DATAGRIDVIEW
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void FRM_CUSTOMERS_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "")
            {
                MessageBox.Show("رجاء ادخل اسم الاول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return;
            }
            if (txtLastName.Text == "")
            {
                MessageBox.Show("رجاء ادخل الاسم العائلة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return;
            }
            if (txtTel.Text == "")
            {
                MessageBox.Show("رجاء ادخل رقم تليفون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTel.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("رجاء ادخل بريد اليكتروني", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            MemoryStream ms = new MemoryStream();
            pbox.Image.Save(ms, pbox.Image.RawFormat);
            byte[] Pictures = ms.ToArray(); 
            cust.ADD_COSTOMERS(txtFirstName.Text,txtLastName.Text,txtTel.Text,txtEmail.Text, Pictures);
            MessageBox.Show("تم اظافة عميل بنجاح", "اظافة عميل", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // reload datagridview afer add 
            this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERES();

            txtFirstName.Clear();
            txtLastName.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtFirstName.Focus();
           // pbox.Image = null;
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Filter = "Images File | *.JPG; *.PNG; *.JPEG; *.GIF; *.BMP";

            if (op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(op.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtFirstName.Focus();
            //pbox.Image = null;
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLastName.Focus();
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTel.Focus();
            }
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ID =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            byte[] Pictures = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(Pictures);
            pbox.Image = Image.FromStream(ms);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "")
            {
                MessageBox.Show("رجاء ادخل اسم الاول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return;
            }
            if (txtLastName.Text == "")
            {
                MessageBox.Show("رجاء ادخل الاسم العائلة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return;
            }
            if (txtTel.Text == "")
            {
                MessageBox.Show("رجاء ادخل رقم تليفون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTel.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("رجاء ادخل بريد اليكتروني", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            MemoryStream ms = new MemoryStream();
            pbox.Image.Save(ms, pbox.Image.RawFormat);
            byte[] Pictures = ms.ToArray();
            cust.EDIT_COSTOMERS(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Pictures,ID);
            MessageBox.Show("تم تعديل عميل بنجاح", "تعديل عميل", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // reload datagridview afer add 
            this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERES();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل تريد  فعلا حذف العميل ؟", "حذف عميل", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.DELETE_CUSTOMER(ID);

                MessageBox.Show("تم حذف عميل بنجاح", "حذف عميل", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERES();

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = cust.SEARCH_CUSTOMER(textBox5.Text);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button9_Click(sender, e);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = cust.SEARCH_CUSTOMER(textBox5.Text);

            if (cust.SEARCH_CUSTOMER(textBox5.Text).Rows.Count == 0)
            {
                MessageBox.Show("العمیل غير موجود رجاء اكتب اسم عمیل اخر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                textBox5.SelectionStart = 0;
                textBox5.SelectionLength = textBox5.TextLength;
            }

        }

        void Navigate(int index)
        {
            pbox.Image = null;
            DataRowCollection DRC = cust.GET_ALL_CUSTOMERES().Rows;
            ID = Convert.ToInt32(DRC[index][0]);
            txtFirstName.Text = DRC[index][1].ToString();
            txtLastName.Text = DRC[index][2].ToString();
            txtTel.Text = DRC[index][3].ToString();
            txtEmail.Text = DRC[index][4].ToString();
            byte[] Pictures = (byte[])DRC[index][5];
            MemoryStream ms = new MemoryStream(Pictures);
            pbox.Image = Image.FromStream(ms);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Position = cust.GET_ALL_CUSTOMERES().Rows.Count - 1;
            Navigate(Position);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(Position == 0)
            {
                MessageBox.Show("هذا هو اول عميل");
                return;
            }
            Position -= 1;
            Navigate(Position);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Position == cust.GET_ALL_CUSTOMERES().Rows.Count -1 )
            {
                MessageBox.Show("هذا هو اخر عميل");
                return;
            }
            Position += 1;
            Navigate(Position);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Navigate(0);
        }
    }
}
