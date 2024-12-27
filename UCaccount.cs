
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



      

       

        private void Button_UCaccount_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void Button_UCaccount_ResetPassword_Click(object sender, EventArgs e)
        {
            if (DataGridView_UCaccount.Rows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Nhân Viên Để Cập Nhật!");
                return;
            }

            // Biến đếm kết quả cập nhật
            int successCount = 0;
            int failCount = 0;

            foreach (DataGridViewRow row in DataGridView_UCaccount.Rows)
            {
                if (row.IsNewRow || row.Cells["TenNhanVien"].Value == null || row.Cells["ChucVu"].Value == null || row.Cells["Email"].Value == null)
                    continue; // Bỏ qua dòng mới hoặc dòng thiếu dữ liệu

                // Lấy giá trị từ các cột
                string TenNhanVien = row.Cells["TenNhanVien"].Value.ToString();
                string ChucVu = row.Cells["ChucVu"].Value.ToString();
                string Email = row.Cells["Email"].Value.ToString();

                // Gọi DAO để cập nhật thông tin nhân viên
                bool isUpdate = NhanVienDAO.Instance.UpdateNhanVien(TenNhanVien, ChucVu, Email);
                if (isUpdate)
                {
                    successCount++;
                }
                else
                {
                    failCount++;
                }
            }

            // Hiển thị thông báo kết quả
            if (successCount > 0)
            {
                MessageBox.Show($"Cập Nhật Thành Công Thông Tin Nhân Viên!");
            }
            if (failCount > 0)
            {
                MessageBox.Show($"Cập Nhật Thất Bại Thông Tin Nhân Viên! Vui Lòng Thử Lại.");
            }
        }

        private void Button_UCaccount_OK_Click_1(object sender, EventArgs e)
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

        
    }
}
