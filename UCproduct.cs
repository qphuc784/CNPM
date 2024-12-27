using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;
using Guna.UI.WinForms;
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

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button_UCproduct_Them_Click(object sender, EventArgs e)
        {
            AddProduct newproduct = new AddProduct();
            newproduct.ShowDialog();
        }

        private void Button_UCproduct_OK_Click(object sender, EventArgs e)
        {
            string TenSanPham = TextBox_UCproduct_timkiem.Text;
            List<SanPham> sanPhams = ProductDAO.Instance.GetSanPhamByTenSP(TenSanPham);
            if (sanPhams.Count > 0)
            {
                // Gán dữ liệu vào DataGridView
                DataGridView_UCproduct.DataSource = sanPhams;

                // Tùy chỉnh cột nếu cần
                DataGridView_UCproduct.Columns["ID"].HeaderText = "Mã Sản Phẩm";
                DataGridView_UCproduct.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                DataGridView_UCproduct.Columns["IDLoai"].HeaderText = "Mã Loại SP";
                DataGridView_UCproduct.Columns["SoLuong"].HeaderText = "Số Lượng";
                DataGridView_UCproduct.Columns["TrangThai"].HeaderText = "Trạng Thái";
                DataGridView_UCproduct.Columns["NgayThayDoiSL"].HeaderText = "Ngày Thay Đổi Số Lượng";
                DataGridView_UCproduct.Columns["SL_Truoc"].HeaderText = "Số Lượng Trước";
                DataGridView_UCproduct.Columns["LoiNhuan"].HeaderText = "Lợi Nhuận";

            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Sản Phẩm Này, Vui Lòng Thử Lại!");
            }

        }

        private void Button_UCproduct_Xoa_Click(object sender, EventArgs e)
        {
            string TenSanPham = TextBox_UCproduct_timkiem.Text;
            DialogResult result = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool isdeleted = ProductDAO.Instance.DeleteSanPhamByTenSp(TenSanPham);
                if (isdeleted)
                {
                    MessageBox.Show("Đã Xóa Thành Công!");
                    DataGridView_UCproduct.DataSource = null;
                    TextBox_UCproduct_timkiem.Clear();
                }
            }
        }

        private void Button_UCproduct_Sua_Click(object sender, EventArgs e)
        {
            if (DataGridView_UCproduct.Rows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm Để Cập Nhật!");
                return;
            }

            // Cho phép chỉnh sửa DataGridView
            DataGridView_UCproduct.ReadOnly = false;
            DataGridView_UCproduct.Columns["ID"].ReadOnly = true;

            // Biến đếm kết quả cập nhật
            int successCount = 0;
            int failCount = 0;

            foreach (DataGridViewRow row in DataGridView_UCproduct.Rows)
            {
                // Bỏ qua các dòng không có dữ liệu hoặc không sửa đổi
                if (row.IsNewRow || row.Cells["TenSanPham"].Value == null) continue;

                string TenSanPham = row.Cells["TenSanPham"].Value.ToString();
                int SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                int LoiNhuan = Convert.ToInt32(row.Cells["LoiNhuan"].Value);

                // Gọi DAO để cập nhật
                bool isUpdate = ProductDAO.Instance.UpdateSanPham(ID, TenSanPham, SoLuong, LoiNhuan);
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
                MessageBox.Show($"Cập Nhật Thành Công  Sản Phẩm!");
            }
            if (failCount > 0)
            {
                MessageBox.Show($"Cập Nhật Thất Bại Sản Phẩm! Vui Lòng Thử Lại.");
            }

            // Gọi lại nút OK để refresh dữ liệu nếu cần
            Button_UCproduct_OK_Click(sender, e);
        }

        private void Button_UCproduct_Sua_Click_1(object sender, EventArgs e)
        {
            if (DataGridView_UCproduct.Rows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm Để Cập Nhật!");
                return;
            }

            // Cho phép chỉnh sửa DataGridView
            DataGridView_UCproduct.ReadOnly = false;
            DataGridView_UCproduct.Columns["ID"].ReadOnly = true;

            // Biến đếm kết quả cập nhật
            int successCount = 0;
            int failCount = 0;

            foreach (DataGridViewRow row in DataGridView_UCproduct.Rows)
            {
                // Bỏ qua các dòng không có dữ liệu hoặc không sửa đổi
                if (row.IsNewRow || row.Cells["TenSanPham"].Value == null) continue;

                string TenSanPham = row.Cells["TenSanPham"].Value.ToString();
                int SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                int LoiNhuan = Convert.ToInt32(row.Cells["LoiNhuan"].Value);

                // Gọi DAO để cập nhật
                bool isUpdate = ProductDAO.Instance.UpdateSanPham(ID, TenSanPham, SoLuong, LoiNhuan);
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
                MessageBox.Show($"Cập Nhật Thành Công  Sản Phẩm!");
            }
            if (failCount > 0)
            {
                MessageBox.Show($"Cập Nhật Thất Bại Sản Phẩm! Vui Lòng Thử Lại.");
            }

            // Gọi lại nút OK để refresh dữ liệu nếu cần
            Button_UCproduct_OK_Click(sender, e);
        }
    }
}