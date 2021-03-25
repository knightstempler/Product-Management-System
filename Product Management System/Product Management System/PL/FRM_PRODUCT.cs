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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;


namespace Product_Management_System.PL
{
    public partial class FRM_PRODUCT : Form
    {
        // Start code to Update in anther Form (list Product in run time)
        private static FRM_PRODUCT frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_PRODUCT getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_PRODUCT();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }

        // End code

        BL.CLS_PRODCUT prd = new BL.CLS_PRODCUT();
        public FRM_PRODUCT()
        {
            InitializeComponent();

            // code to update for in aanother form
            if (frm == null)
                frm = this;


            this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = prd.SearchProduct(txtsearch.Text);
            this.dataGridView1.DataSource = Dt;

            if (Dt.Rows.Count == 0)
            {
                MessageBox.Show("المنتج غير موجود رجاء اكتب اسم منتوج اخر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsearch.Focus();
                txtsearch.SelectionStart = 0;
                txtsearch.SelectionLength = txtsearch.TextLength;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm_add = new FRM_ADD_PRODUCT();
            frm_add.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if(MessageBox.Show("هل تريد فعلا حذف المنتج ؟","حذف المنتج",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                prd.DeleteProduct(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                MessageBox.Show("تم الحذ المنتج بالنجاح", "تم الحذف المنتج", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
            }
        }

        private void FRM_PRODUCT_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();

            frm.txtRef.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtDes.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtQte.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtPrice.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.comCategores.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

            frm.Text = "تحديث المنتوج : " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            frm.btnOk.Text = "تحديث";
            frm.states = "update";
            frm.txtRef.ReadOnly = true;

            byte[] img = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(img);
            frm.pbox.Image = Image.FromStream(ms);

            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            FRM_PREVIEW frm = new FRM_PREVIEW();

            byte[] img = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(img);
            frm.pbox1.Image = Image.FromStream(ms);

            frm.Text = "صورة منتوج : " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RPT.rpt_product_singl myReport = new RPT.rpt_product_singl();
            myReport.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

            RPT.FRM_RPR_PRODUCT frm = new RPT.FRM_RPR_PRODUCT();

            frm.crystalReportViewer1.ReportSource = myReport;

            frm.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_product myReport = new RPT.rpt_all_product();
            RPT.FRM_RPR_PRODUCT myForm = new RPT.FRM_RPR_PRODUCT();
            myForm.crystalReportViewer1.ReportSource = myReport;

            myForm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            RPT.rpt_all_product myReport = new RPT.rpt_all_product();

            // Create Object For destination for select path Save file
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();

            // Create Export Option
            ExportOptions export = new ExportOptions();
            ExcelFormatOptions excelFormat = new ExcelFormatOptions();
            // Set The path to save
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Save File (*.xls ) |*.xls";

            if (sf.ShowDialog() == DialogResult.OK) { 

                dfoptions.DiskFileName = sf.FileName;

                export = myReport.ExportOptions;

                export.ExportDestinationType = ExportDestinationType.DiskFile;

                export.ExportFormatType = ExportFormatType.Excel;

                export.ExportFormatOptions = excelFormat;

                export.ExportDestinationOptions = dfoptions;

                myReport.Export();

                MessageBox.Show("تم حفظ ملف بالنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
