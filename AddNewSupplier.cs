using CNPM.DAO;
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

namespace CNPM
{
    public partial class AddNewSupplier : Form
    {
        public AddNewSupplier()
        {
            InitializeComponent();
        }

        private void ControlBox_AddNewSupplier_X_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button_AddNewSupplier_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_AddNewSupplier_Ok_Click(object sender, EventArgs e)
        {
            string dc = TextBox_AddNewSupplier_Dia_chi.Text;
            string sdt = TextBox_AddNewSupplier_sdt.Text;

            if (string.IsNullOrWhiteSpace(TextBox_AddNewSupplier_Dia_chi.Text) ||
                string.IsNullOrWhiteSpace(TextBox_AddNewSupplier_sdt.Text))
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            if (checkSdtNhaCungCap(sdt))
            {
                MessageBox.Show("So dien thoai da duoc su dung");
                return;
            }

            if (Add_NhaCungCap(dc, sdt))
            {
                MessageBox.Show("Thanh Cong!");
                this.Close();
            }
            else
            {
                MessageBox.Show("That Bai!");
            }
        }
        bool checkSdtNhaCungCap(string sdt)
        {
            return NhaCungCapDAO.Instance.checkSdtNhaCungCap(sdt);
        }
        bool Add_NhaCungCap(string dc, string sdt)
        {
            return NhaCungCapDAO.Instance.AddNhaCungCap(dc, sdt);
        }
    }
}
