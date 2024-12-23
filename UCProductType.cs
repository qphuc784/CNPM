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
                DataGridView_UCproducttype.Columns["LoiNhuan"].HeaderText = "Lợi Nhuận";
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
            if(DataGridView_UCproducttype.Rows.Count ==0)
            {
                MessageBox.Show("Vui Lòng Chọn Loại Sản Phẩm Để Cập Nhật!");
            }
            foreach (DataGridViewRow row in DataGridView_UCproducttype.Rows)
            {
                string TenLoai = row.Cells["Ten"].Value.ToString();
                int LN = Convert.ToInt32(row.Cells["LoiNhuan"].Value);

                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                DataGridView_UCproducttype.ReadOnly = false;
                DataGridView_UCproducttype.Columns["ID"].ReadOnly = true;
                bool isUpdate = LoaiSanPhamDAO.Instance.UpdateLoaiSanPham(ID, TenLoai, LN);
                if (!isUpdate)
                {
                    MessageBox.Show("Cập Nhật Loại Sản Phẩm Thất Bại! Vui Lòng Thử Lại!");
                    return;
                }
            }
            MessageBox.Show("Cập Nhật Loại Sản Phẩm Thành Công!");


        }
    }
}
