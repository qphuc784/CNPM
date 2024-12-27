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
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_Load(object sender, EventArgs e)
        {

        }

        private UserControl currentUC = null;
        private void ShowUserControl(UserControl uc)
        {
            if (currentUC != null)
            {
                Panel_Interface_showUC.Controls.Remove(currentUC);
                currentUC.Dispose();
            }
            uc.Size = Panel_Interface_showUC.Size;
            uc.Location = new Point(260, 0); // Điều chỉnh để căn chỉnh với panel
            Panel_Interface_showUC.Controls.Add(uc); // Thêm UserControl mới vào panel

            // Cập nhật UserControl hiện tại
            currentUC = uc;
        }

        private void Button_Interface_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label_Username_interface_Click(object sender, EventArgs e)
        {

        }

        private void Button_Interface_product_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCproduct());
        }

        private void Button_Interface_service_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCservice());
        }

        private void Button_Interface_accounting_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCaccounting());
        }

        private void Button_Interface_account_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCaccount());
        }

        private void Button_Interface_productbill_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCProductType());
        }

        private void Button_Interface_servicebill_Click(object sender, EventArgs e)
        {
            ShowUserControl(new USservicebill());
        }

        private void Button_Interface_goodreceipt_Click(object sender, EventArgs e)
        {
            ShowUserControl(new USgoodreceipt());
        }
    }
}
