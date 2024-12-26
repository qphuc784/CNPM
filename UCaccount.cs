
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

namespace CNPM
{
    public partial class UCaccount : UserControl
    {
        public UCaccount()
        {
            InitializeComponent();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {

        }



        private void Button_UCaccount_OK_Click(object sender, EventArgs e)
        {
            string TenNhanVien = TextBox_UCaccount_timkiem.Text;
            List<NhanVien> nhanvien = NhanVienDAO.Instance.GetNhanVienByTenNV(TenNhanVien);

            if (nhanvien.Count > 0)
            {
                DataGridView_UCaccount.DataSource = nhanvien;
                DataGridView_UCaccount.Columns["ID"].HeaderText = "Mã Nhân Viên";
                DataGridView_UCaccount.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
                DataGridView_UCaccount.Columns["TaiKhoan"].HeaderText = "Tài Khoản";
                DataGridView_UCaccount.Columns["MatKhau"].HeaderText = "Mật Khẩu ";
                DataGridView_UCaccount.Columns["ChucVu"].HeaderText = "Chức Vụ";
                DataGridView_UCaccount.Columns["Email"].HeaderText = "Email";


            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Nhân Viên Này, Vui Lòng Thử Lại!");
            }
        }

        private void Button_UCaccount_ResetPassword_Click(object sender, EventArgs e)
        {
            if (DataGridView_UCaccount.Rows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Nhân Viên Để Cập Nhật!");
            }
            foreach (DataGridViewRow row in DataGridView_UCaccount.Rows)
            {
                string TenNhanVien = row.Cells["TenNhanVien"].Value.ToString();
                string ChucVu = row.Cells["ChucVu"].Value.ToString();
                string Email = row.Cells["Email"].Value.ToString();


                bool isUpdate = NhanVienDAO.Instance.UpdateNhanVien(TenNhanVien, ChucVu, Email);
                if (isUpdate)
                {

                    MessageBox.Show("Cập Nhật Thông Tin Nhân Viên Thành Công!");
                }
                else
                {
                    MessageBox.Show("Cập Nhật Thông Tin Nhân Viên Thất Bại! Vui Lòng Thử Lại!");
                    return;

                }
            }
        }

        private void Button_UCaccount_Xoa_Click(object sender, EventArgs e)
        {

        }
    }
}
