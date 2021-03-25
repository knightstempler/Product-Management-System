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
    public partial class FRM_PRODUCT_LIST : Form
    {
        BL.CLS_PRODCUT prd = new BL.CLS_PRODCUT();
        public FRM_PRODUCT_LIST()
        {
            InitializeComponent();
            this.dgvProductList.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void dgvProductList_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
