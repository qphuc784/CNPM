using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM
{
    public partial class UCproduct : UserControl
    {
        public UCproduct()
        {
            InitializeComponent();
        }
        private void Button_UCproduct_Them_Click(object sender, EventArgs e)
        {
            AddProduct newproduct = new AddProduct();
            newproduct.ShowDialog();
        }
    }
}
