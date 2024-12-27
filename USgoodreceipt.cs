using CNPM.DTO;
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
    public partial class USgoodreceipt : UserControl
    {
        public USgoodreceipt()
        {
            InitializeComponent();


        }

        private void Button_UCgoodreceipt_OK_Click(object sender, EventArgs e)
        {
            string IDtext = textBox_UCgoodreceipt_idphieu.Text;
            string IDcttext = textBox_UCgoodreceipt_idctphieu.Text;
            if (string.IsNullOrEmpty(IDtext))
            {
                MessageBox.Show("vui Lòng Nhập Mã Phiếu Nhập Hàng!");
                return;
            }
            if (string.IsNullOrEmpty(IDcttext))
            {
                List<GoodReceipt> gr = GoodReceiptDAO.Instance.GetPhieuNhapHang(IDtext);
                if (gr.Count > 0)
                {
                    DataGridView_UCgoodreceipt.DataSource = gr;
                    DataGridView_UCgoodreceipt.Columns["ID"].HeaderText = "STT";
                    DataGridView_UCgoodreceipt.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                    DataGridView_UCgoodreceipt.Columns["SoLuong"].HeaderText = "Số Lượng";
                    DataGridView_UCgoodreceipt.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại Nhà Cung Cấp";
                    DataGridView_UCgoodreceipt.Columns["DonGia"].HeaderText = "Đơn Giá";
                    DataGridView_UCgoodreceipt.Columns["NgayMua"].HeaderText = "Ngày Mua";
                    DataGridView_UCgoodreceipt.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                }
                else
                {
                    MessageBox.Show("Không Tìm Thấy Kết Quả, Vui Lòng Thử Lại!");
                }
            }
            else
            {
                List<GoodReceipt> gr = GoodReceiptDAO.Instance.GetPhieuNhapHangBy2ID(IDtext, IDcttext);
                if (gr.Count > 0)
                {
                    DataGridView_UCgoodreceipt.DataSource = gr;
                    DataGridView_UCgoodreceipt.Columns["ID"].HeaderText = "STT";
                    DataGridView_UCgoodreceipt.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                    DataGridView_UCgoodreceipt.Columns["SoLuong"].HeaderText = "Số Lượng";
                    DataGridView_UCgoodreceipt.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại Nhà Cung Cấp";
                    DataGridView_UCgoodreceipt.Columns["DonGia"].HeaderText = "Đơn Giá";
                    DataGridView_UCgoodreceipt.Columns["NgayMua"].HeaderText = "Ngày Mua";
                    DataGridView_UCgoodreceipt.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                }
                else
                {
                    MessageBox.Show("Không Tìm Thấy Kết Quả, Vui Lòng Thử Lại!");
                }
            }


        }

        private void ComboBox_UCgoodreceipt_LoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy ComboBox từ sender
            ComboBox cbbox = sender as ComboBox;

            if (cbbox.SelectedItem is DataRowView rowView)
            {
                int selectedIDLoai = (int)rowView["ID"];
            }

        }


        private void Button_UCgoodreceipt_Sua_Click(object sender, EventArgs e)
        {
            if (DataGridView_UCgoodreceipt.Rows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Phiếu Mua Hàng Để Cập Nhật!");
                return;
            }

            bool allSuccess = true; // Theo dõi trạng thái cập nhật tổng quát
            foreach (DataGridViewRow row in DataGridView_UCgoodreceipt.Rows)
            {
                // Kiểm tra dữ liệu trong từng hàng
                if (row.Cells["TenSanPham"].Value == null || row.Cells["SoLuong"].Value == null || row.Cells["DonGia"].Value == null)
                {
                    MessageBox.Show($"Hàng {row.Index + 1} có dữ liệu trống, bỏ qua.");
                    allSuccess = false;
                    continue; // Bỏ qua hàng lỗi
                }

                // Lấy dữ liệu từ từng ô
                string TenLoai = row.Cells["TenSanPham"].Value.ToString();
                if (!int.TryParse(row.Cells["SoLuong"].Value.ToString(), out int SoLuong))
                {
                    MessageBox.Show($"Hàng {row.Index + 1}: Số lượng không hợp lệ, bỏ qua.");
                    allSuccess = false;
                    continue; // Bỏ qua hàng lỗi
                }

                if (!float.TryParse(row.Cells["DonGia"].Value.ToString(), out float DonGia))
                {
                    MessageBox.Show("Cập Nhật Thất Bại");
                    allSuccess = false;
                    continue; // Bỏ qua hàng lỗi
                }

                // Cập nhật cơ sở dữ liệu
                bool isUpdate = GoodReceiptDAO.Instance.UpdatePhieuNhapHang(TenLoai, SoLuong, DonGia);
                if (!isUpdate)
                {
                    MessageBox.Show("Cập Nhật Thất Bại.");
                    allSuccess = false; // Đánh dấu lỗi
                }
            }

            // Thông báo kết quả tổng hợp sau khi xử lý tất cả hàng
            if (allSuccess)
            {
                MessageBox.Show("Cập Nhật Thành Công!");
            }
            else
            {
                MessageBox.Show("Vui Lòng Thử Lại!");
            }
        }

       
        

        private void Button_UCgoodreceipt_Xoa_Click_1(object sender, EventArgs e)
        {
            string IDtext = textBox_UCgoodreceipt_idphieu.Text;
            if (string.IsNullOrEmpty(IDtext))
            {
                MessageBox.Show("Vui lòng nhập ID phiếu nhập hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ID = Convert.ToInt32(IDtext);
            string IDcttext = textBox_UCgoodreceipt_idctphieu.Text;
            int? IDct = string.IsNullOrEmpty(IDcttext) ? (int?)null : Convert.ToInt32(IDcttext);

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool isDeleted = false;

                if (IDct.HasValue)
                {
                    // Xóa chi tiết phiếu nhập hàng khi có ID chi tiết phiếu nhập hàng
                    isDeleted = GoodReceiptDAO.Instance.DeletePhieuNhapHangBy2(ID, IDct.Value);
                }
                else
                {
                    // Xóa tất cả các chi tiết phiếu nhập hàng và phiếu nhập hàng khi chỉ có ID phiếu nhập hàng
                    isDeleted = GoodReceiptDAO.Instance.DeletePhieuNhapHang(ID);
                }

                if (isDeleted)
                {
                    MessageBox.Show("Đã Xóa Thành Công!");
                    DataGridView_UCgoodreceipt.DataSource = null; // Cập nhật lại DataGridView
                    textBox_UCgoodreceipt_idphieu.Clear();
                    textBox_UCgoodreceipt_idctphieu.Clear();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

