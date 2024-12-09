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
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Sản Phẩm Vui Lòng Thử Lại!");
            }

        }

        private void Button_UCproduct_Xoa_Click(object sender, EventArgs e)
        {
            string TenSanPham = TextBox_UCproduct_timkiem.Text;
            DialogResult result = MessageBox.Show(
        $"Bạn có chắc chắn muốn xóa không?",
        "Xác nhận xóa",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
        );
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
    }
}
