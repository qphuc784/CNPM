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
using System.Xml.Linq;

namespace CNPM
{
    public partial class DoiMatKhau : Form
    {
        private NhanVien matkhauNhanVien;
        public NhanVien MatKhauNhanVien
        {
            get => matkhauNhanVien;
            set { matkhauNhanVien = value; }
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
            string currentPassword = TextBox_DoiMatKhau_MatKhauhientai.Text.Trim();
            string newPassword = TextBox_DoiMatKhau_matkhaumoi.Text.Trim();
            string confirmPassword = TextBox_DoiMatKhau_xacnhanmk.Text.Trim();

            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (string.CompareOrdinal(matkhauNhanVien.MatKhau, currentPassword) != 0)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.");
                return;
            }

            if (!string.Equals(newPassword, confirmPassword))
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            int id = matkhauNhanVien.ID;
            bool result = NhanVienDAO.Instance.changePassWord(id, newPassword);

            if (!result)
            {
                MessageBox.Show("Đổi mật khẩu không thành công. Vui lòng thử lại.");
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thành công.");
                this.Close();
            }
        }
    }
}
