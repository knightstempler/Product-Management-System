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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;

namespace Product_Management_System.PL
{
    public partial class FRM_CATEGORIES : Form
    {

        SqlConnection sqlcon = new SqlConnection("Server =.; Database=Product_DB; Integrated Security = True");
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        BindingManagerBase bmp;
        SqlCommandBuilder cmdb;
        public FRM_CATEGORIES()
        {
            InitializeComponent();

            Da = new SqlDataAdapter("SELECT ID_CAT AS 'الرقم' , DESCRIPTION_CAT  AS  'الصنف' FROM categores", sqlcon);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;
            txtID.DataBindings.Add("text", Dt, "الرقم");
            txtDesc.DataBindings.Add("text", Dt, "الصنف");

            bmp = BindingContext[Dt];

            labelposetion.Text = (bmp.Position + 1) + "  /  " + bmp.Count;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmp.Position = 0;
            labelposetion.Text = (bmp.Position + 1) + "  /  " + bmp.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmp.Position = bmp.Count;
            labelposetion.Text = (bmp.Position + 1) + "  /  " + bmp.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmp.Position -= 1;
            labelposetion.Text = (bmp.Position + 1) + "  /  " + bmp.Count;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmp.Position += 1;
            labelposetion.Text = (bmp.Position + 1) + "  /  " + bmp.Count;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bmp.AddNew();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            txtDesc.Focus();

            int id = Convert.ToInt32(Dt.Rows[Dt.Rows.Count - 1]["الرقم"]) + 1;
            txtID.Text = id.ToString();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bmp.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(Da);
            Da.Update(Dt);
            MessageBox.Show("تم اظافة الصنف بالنجاح", "اظافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNew.Enabled = true;
            btnAdd.Enabled = false;

            labelposetion.Text = (bmp.Position + 1) + "  /  " + bmp.Count;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bmp.RemoveAt(bmp.Position);
            bmp.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(Da);
            Da.Update(Dt);
            MessageBox.Show("تم حذف الصنف بالنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

            labelposetion.Text = (bmp.Position + 1) + "  /  " + bmp.Count;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            bmp.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(Da);
            Da.Update(Dt);
            MessageBox.Show("تم تعديل الصنف بالنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

            labelposetion.Text = (bmp.Position + 1) + "  /  " + bmp.Count;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RPT.rtp_all_categorieis rpt = new RPT.rtp_all_categorieis();
            RPT.FRM_RPR_PRODUCT frm = new RPT.FRM_RPR_PRODUCT();
            rpt.Refresh();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RPT.rtp_singl_categoreis rpt = new RPT.rtp_singl_categoreis();
            RPT.FRM_RPR_PRODUCT frm = new RPT.FRM_RPR_PRODUCT();
            rpt.SetParameterValue("@ID", Convert.ToInt32(txtID.Text));
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RPT.rtp_all_categorieis myReport = new RPT.rtp_all_categorieis();

            // Create Object For destination for select path Save file
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();

            // Create Export Option
            ExportOptions export = new ExportOptions();
            PdfFormatOptions PDFformat = new PdfFormatOptions();
            // Set The path to save
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Save File (*.pdf ) |*.pdf";

            if (sf.ShowDialog() == DialogResult.OK)
            {

                dfoptions.DiskFileName = sf.FileName;

                export = myReport.ExportOptions;

                export.ExportDestinationType = ExportDestinationType.DiskFile;

                export.ExportFormatType = ExportFormatType.PortableDocFormat;

                export.ExportFormatOptions = PDFformat;

                export.ExportDestinationOptions = dfoptions;

                myReport.Export();

                myReport.Refresh();

                MessageBox.Show("تم حفظ ملف بالنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RPT.rtp_singl_categoreis myReport = new RPT.rtp_singl_categoreis();

            // Create Object For destination for select path Save file
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();

            // Create Export Option
            ExportOptions export = new ExportOptions();
            PdfFormatOptions PDFformat = new PdfFormatOptions();
            // Set The path to save
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Save File (*.pdf ) |*.pdf";

            if (sf.ShowDialog() == DialogResult.OK)
            {

                dfoptions.DiskFileName = sf.FileName;

                export = myReport.ExportOptions;

                export.ExportDestinationType = ExportDestinationType.DiskFile;

                export.ExportFormatType = ExportFormatType.PortableDocFormat;

                export.ExportFormatOptions = PDFformat;

                export.ExportDestinationOptions = dfoptions;

                myReport.SetParameterValue("@ID", Convert.ToInt32(txtID.Text));

                myReport.Export();

                MessageBox.Show("تم حفظ ملف بالنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}