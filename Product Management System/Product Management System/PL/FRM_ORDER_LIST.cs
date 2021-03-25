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
    public partial class FRM_ORDER_LIST : Form
    {
        BL.CLS_ORDER order = new BL.CLS_ORDER();
        public FRM_ORDER_LIST()
        {
            InitializeComponent();
            this.dvgorders.DataSource = order.SEARCH_ORDER("");
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dvgorders.DataSource = order.SEARCH_ORDER(txtsearch.Text);
            }
            catch
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int OrderID = Convert.ToInt32(dvgorders.CurrentRow.Cells[0].Value);
            RPT.RTP_ORDER reoprt_order = new RPT.RTP_ORDER();
            RPT.FRM_RPR_PRODUCT frm = new RPT.FRM_RPR_PRODUCT();
            reoprt_order.SetDataSource(order.GET_ORDER_DETAILS(OrderID));
            frm.crystalReportViewer1.ReportSource = reoprt_order;
            frm.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
