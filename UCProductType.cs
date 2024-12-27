
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
    public partial class UCProductType : UserControl
    {
        public UCProductType()
        {
            InitializeComponent();
        }

        private void Button_UCproductType_Them_Click(object sender, EventArgs e)
        {
            AddProductType newproduct = new AddProductType();
            newproduct.ShowDialog();
        }

        private void Button_UCproductType_OK_Click(object sender, EventArgs e)
        {
            string TenLoai = TextBox_UCproductType_timkiem.Text;
            List<LoaiSP> loaisp = LoaiSanPhamDAO.Instance.GetLoaiSPByTenLoai(TenLoai);
            if (loaisp.Count > 0)
            {
                DataGridView_UCproducttype.DataSource = loaisp;

                DataGridView_UCproducttype.Columns["ID"].HeaderText = "Mã Loại Sản Phẩm";
                DataGridView_UCproducttype.Columns["Ten"].HeaderText = "Tên Loại Sản Phẩm";
                DataGridView_UCproducttype.Columns["DVT"].HeaderText = "Đơn Vị Tính";
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Loại Sản Phẩm Này, Vui Lòng Thử Lại!");

            }


        }

        private void Button_UCproductType_Xoa_Click(object sender, EventArgs e)
        {
            string TenLoai = TextBox_UCproductType_timkiem.Text;
            DialogResult result = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool isdeleted = LoaiSanPhamDAO.Instance.DeleteLoaiSanPhamByTen(TenLoai);
                if (isdeleted)
                {
                    MessageBox.Show("Đã Xóa Thành Công!");
                    DataGridView_UCproducttype.DataSource = null;
                    TextBox_UCproductType_timkiem.Clear();
                }
            }
        }

        private void Button_UCproductType_Sua_Click(object sender, EventArgs e)
        {
            if (DataGridView_UCproducttype.Rows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Loại Sản Phẩm Để Cập Nhật!");
                return;
            }

            // Cho phép chỉnh sửa DataGridView
            DataGridView_UCproducttype.ReadOnly = false;
            DataGridView_UCproducttype.Columns["ID"].ReadOnly = true; // Khóa cột ID

            // Biến đếm kết quả cập nhật
            int successCount = 0;
            int failCount = 0;

            foreach (DataGridViewRow row in DataGridView_UCproducttype.Rows)
            {
                if (row.IsNewRow || row.Cells["Ten"].Value == null || row.Cells["DVT"].Value == null)
                    continue; // Bỏ qua dòng mới hoặc dòng thiếu dữ liệu

                // Lấy giá trị từ các cột
                string TenLoai = row.Cells["Ten"].Value.ToString();
                string DonViTinh = row.Cells["DVT"].Value.ToString();
                int ID = Convert.ToInt32(row.Cells["ID"].Value);

                // Gọi DAO để cập nhật loại sản phẩm
                bool isUpdate = LoaiSanPhamDAO.Instance.UpdateLoaiSanPham(ID, TenLoai, DonViTinh);
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
                MessageBox.Show($"Cập Nhật Thành Công!");
            }
            if (failCount > 0)
            {
                MessageBox.Show($"Cập Nhật Thất Bại! Vui Lòng Thử Lại.");
            }

            // Tùy chọn: Làm mới lại dữ liệu nếu cần
            Button_UCproductType_OK_Click(sender, e);

        }
    }
}