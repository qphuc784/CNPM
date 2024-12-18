using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace CNPM
{
    public partial class DoiMatKhau : Form
    {
        private NhanVien matkhauNhanVien;
        public NhanVien MatKhauNhanVien
        {
            get => matkhauNhanVien;
            set { matkhauNhanVien = value;}
        }
        public DoiMatKhau(NhanVien mk)
        {
            InitializeComponent();
            this.MatKhauNhanVien = mk;
        }

        private void Button_DoiMatKhau_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_DoiMatKhau_Ok_Click(object sender, EventArgs e)
        {
            int id = matkhauNhanVien.ID;
            string pass = TextBox_DoiMatKhau_matkhaumoi.Text;
            if (string.IsNullOrWhiteSpace(TextBox_DoiMatKhau_MatKhauhientai.Text) ||
                string.IsNullOrWhiteSpace(TextBox_DoiMatKhau_matkhaumoi.Text) ||
                string.IsNullOrWhiteSpace(TextBox_DoiMatKhau_xacnhanmk.Text))
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }

            if (string.CompareOrdinal(matkhauNhanVien.MatKhau, TextBox_DoiMatKhau_MatKhauhientai.Text) != 0)
            {
                MessageBox.Show("Mat khau hien tai sai");
                return;
            }

            bool result = NhanVienDAO.Instance.changePassWord(id, pass);
            if (!result)
            {
                MessageBox.Show("Đổi mật khẩu không thành công");
            }
            else
            {

                MessageBox.Show("Đổi mật khẩu thành công");
                this.Close();
            }
        }
    }
}
