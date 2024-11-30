using CNPM;
using CuaHangDaQuy.DTO;
using CuaHangDaQuy.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CNPM
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void Button_AddCustomer_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_AddCustomer_Ok_Click(object sender, EventArgs e)
        {
            string ten = TextBox_AddCustomer_Ten_khach_hang.Text;
            string sdt = TextBox_AddCustomer_sdt.Text;

            if (string.IsNullOrWhiteSpace(TextBox_AddCustomer_Ten_khach_hang.Text) ||
                string.IsNullOrWhiteSpace(TextBox_AddCustomer_sdt.Text)) 
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            if(checkSdtKhachHang(sdt))
            {
                MessageBox.Show("So dien thoai da duoc su dung");
                return;
            }
           
            if (Add_customer(ten,sdt))
            {
                MessageBox.Show("Thanh Cong!");
                this.Close();
            }else
            {
                MessageBox.Show("That Bai!");
            }
        }
        bool checkSdtKhachHang(string sdt)
        {
            return KhachHangDAO.Instance.checkSdtKhachHang(sdt);
        }
        bool Add_customer(string ten, string sdt)
        {
            return KhachHangDAO.Instance.AddKhachHang(ten, sdt);
        }

        private void TextBox_AddCustomer_Ten_khach_hang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
