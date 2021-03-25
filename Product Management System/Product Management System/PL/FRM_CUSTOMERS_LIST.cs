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
    public partial class FRM_CUSTOMERS_LIST : Form
    {
        BL.CLS_COSTOMERS cust = new BL.CLS_COSTOMERS();
        public FRM_CUSTOMERS_LIST()
        {
            InitializeComponent();

            DGView.DataSource = cust.GET_ALL_CUSTOMERES();
            DGView.Columns[0].Visible = false;
            DGView.Columns[5].Visible = false;
        }

        private void DGView_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGView_Click(object sender, EventArgs e)
        {
            
        }
    }
}
