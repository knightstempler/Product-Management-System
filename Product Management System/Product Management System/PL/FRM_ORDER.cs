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
using System.Globalization;
using System.Windows.Forms.VisualStyles;

namespace Product_Management_System.PL
{
    public partial class FRM_ORDER : Form
    {
        BL.CLS_ORDER order = new BL.CLS_ORDER();
        DataTable Dt = new DataTable();


        void CalculateAmount()
        {

              //          المبلغ = الكمية * الثمن
             


            if (txtQty.Text != string.Empty && txtPrice.Text != string.Empty)
            {
                double Amount = Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQty.Text);

                txtAmouns.Text = Amount.ToString();

            }
        }


            void CalculateTotalAmount()
        {
            //المبلغ الاجمالي = المبلغ - (المبلع * (نسبة الخصم / 100 ))
            if (txtDescount.Text != string.Empty && txtAmouns.Text != string.Empty)
            {

                double Descount = Convert.ToDouble(txtDescount.Text);
                double Amount = Convert.ToDouble(txtAmouns.Text);
                double TotalAmount = Amount - (Amount * Descount / 100);

                txtTotalAmount.Text = TotalAmount.ToString();
            }

        }



        void SumTotal()
        {
            // حساب المجموع المجاميع كلی  للبیع

            txtSumTotal.Text =
            (
            from DataGridViewRow row in dgvProducts.Rows
            where row.Cells[6].FormattedValue.ToString() != string.Empty
            select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
        }


        void ClearBox()
        {
            txtIDproduct.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtAmouns.Clear();
            txtDescount.Clear();
            txtTotalAmount.Clear();
            btnBrowse.Focus();
        }

        void ClearData()
        {
            txtCustmersID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtDescOrder.Clear();
            dtOrder.ResetText();
            txtOrderID.Clear();
            txtSumTotal.Clear();
            ClearBox();
            Dt.Clear();
            dgvProducts.DataSource = null;
            pbox.Image = null;
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnPrint.Enabled = true;
        }

        void CreateDataTable()
        {
            Dt.Columns.Add("معرف");
            Dt.Columns.Add("اسم ");
            Dt.Columns.Add("الثمن ");
            Dt.Columns.Add("الكمية");
            Dt.Columns.Add("المبلغ");
            Dt.Columns.Add("الخصم(%)");
            Dt.Columns.Add("الاجمالي");
            dgvProducts.DataSource = Dt;
        }

        void ResizeDGV()
        {

            this.dgvProducts.RowHeadersWidth = 42;
            this.dgvProducts.Columns[0].Width = 74;
            this.dgvProducts.Columns[1].Width = 156;
            this.dgvProducts.Columns[2].Width = 82;
            this.dgvProducts.Columns[3].Width = 74;
            this.dgvProducts.Columns[4].Width = 111;
            this.dgvProducts.Columns[5].Width = 100;
            this.dgvProducts.Columns[6].Width = 115;
        }

        public FRM_ORDER()
        {
            
            InitializeComponent();
            CreateDataTable();
            ResizeDGV();
            txtSalesMan.Text = Program.SalesMan;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.txtOrderID.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();

            btnAdd.Enabled = true;
            btnNew.Enabled = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS_LIST frm = new FRM_CUSTOMERS_LIST();

            frm.ShowDialog();

            txtCustmersID.Text = frm.DGView.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = frm.DGView.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = frm.DGView.CurrentRow.Cells[2].Value.ToString();
            txtTel.Text = frm.DGView.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = frm.DGView.CurrentRow.Cells[4].Value.ToString();
            byte[] custPicture = (byte[])frm.DGView.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(custPicture);
            pbox.Image = Image.FromStream(ms);

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            ClearBox();

            FRM_PRODUCT_LIST frm = new FRM_PRODUCT_LIST();
            frm.ShowDialog();

            txtIDproduct.Text = frm.dgvProductList.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = frm.dgvProductList.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = frm.dgvProductList.CurrentRow.Cells[3].Value.ToString();
            txtQty.Focus();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar !=8)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != DecimalSeparator)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && txtPrice.Text != string.Empty)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtQty.Text != string.Empty)
            {
                txtDescount.Focus();
            }
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtDescount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtDescount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotalAmount();
        }

        private void txtDescount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                // تحقیق من كمیه‌ موجوده‌ من مخزن
                if (order.VERIFY_QTY(txtIDproduct.Text, Convert.ToInt32(txtQty.Text)).Rows.Count < 1)
                {
                    MessageBox.Show("الكمية غير متوفرة فى مخزن لهذا المنتج", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                // لوب لمنع تكرار منتج اكثر من مرة
                for (int i = 0; i < dgvProducts.Rows.Count -1; i++)
                {
                    if(dgvProducts.Rows[i].Cells[0].Value.ToString() == txtIDproduct.Text)
                    {
                        MessageBox.Show("هذا المنتج تم ادخاله مسبقا", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ClearBox();
                        return;
                    }

                }

                DataRow Dr = Dt.NewRow();
                Dr[0] = txtIDproduct.Text;
                Dr[1] = txtName.Text;
                Dr[2] = txtPrice.Text;
                Dr[3] = txtQty.Text;
                Dr[4] = txtAmouns.Text;
                Dr[5] = txtDescount.Text;
                Dr[6] = txtTotalAmount.Text;

                Dt.Rows.Add(Dr);

                dgvProducts.DataSource = Dt;

                ClearBox();
                // حساب المجموع المجاميع كلی  للبیع
                SumTotal();


            }
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {

            try { 

                txtIDproduct.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
                txtQty.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
                txtAmouns.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
                txtDescount.Text = dgvProducts.CurrentRow.Cells[5].Value.ToString();
                txtTotalAmount.Text = dgvProducts.CurrentRow.Cells[6].Value.ToString();

                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
                txtQty.Focus();
            }
            catch
            {
                return;
            }
        }

        private void dgvProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SumTotal();
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvProducts_DoubleClick(sender, e);
        }

        private void حذفالسطرالحاليToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            { 
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);

            }
            catch
            {
                return;
            }
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Dt.Clear();
            dgvProducts.Refresh();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtCustmersID.Text == string.Empty )
            {
                MessageBox.Show("رجاء قم باختيار عميل اولا", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustmersID.Focus();
                return;
            }if(txtDescOrder.Text == string.Empty)
            {
                MessageBox.Show("رجاء قم بكتابة تفاصيل فاتورة", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescOrder.Focus();
                return;
            }

            if (dgvProducts.Rows.Count < 1)
            {
                MessageBox.Show("رجاء قم بادخال  معلومات بیع", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescOrder.Focus();
                return;
            }

            else 
            {
                // اظافة معلومات الفاتورة
                order.ADD_ORDER(Convert.ToInt32(txtOrderID.Text), dtOrder.Value, Convert.ToInt32(txtCustmersID.Text), txtDescOrder.Text, txtSalesMan.Text);

                // اظافة معلومات المنتجات
                for(int i =0; i < dgvProducts.Rows.Count -1; i++)
                {

                    order.ADD_RRDER_DETAILS(dgvProducts.Rows[i].Cells[0].Value.ToString(),
                        Convert.ToInt32(txtOrderID.Text),
                        Convert.ToInt32(dgvProducts.Rows[i].Cells[3].Value),
                        dgvProducts.Rows[i].Cells[2].Value.ToString(),
                        Convert.ToInt32(dgvProducts.Rows[i].Cells[5].Value),
                        dgvProducts.Rows[i].Cells[4].Value.ToString(),
                        dgvProducts.Rows[i].Cells[6].Value.ToString()
                        );
                }

                MessageBox.Show("تم العملية الحفظ بنجاح", "العملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int OrderID = Convert.ToInt32( order.GET_LAST_ORDER_ID_FOR_PRINT().Rows[0][0]);

            RPT.RTP_ORDER reoprt_order = new RPT.RTP_ORDER();

            RPT.FRM_RPR_PRODUCT frm = new RPT.FRM_RPR_PRODUCT();

            reoprt_order.SetDataSource(order.GET_ORDER_DETAILS(OrderID));

            frm.crystalReportViewer1.ReportSource = reoprt_order;

            frm.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
