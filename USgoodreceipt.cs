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
            LoadTenLoaispToComboBox(); 
            LoadListSdt();
        }

        private void Button_UCgoodreceipt_OK_Click(object sender, EventArgs e)
        {
            string TenLoai = ComboBox_UCgoodreceipt_LoaiDV.Text;
            string SDT = ComboBox_UCgoodreceipt_SDT.Text;
            string Thangtext = TextBox_UCgoodreceipt_thang.Text;
            string Ngaytext = TextBox_UCgoodreceipt_ngay.Text;
            int Thang, Ngay;

            // Kiểm tra xem các giá trị nhập vào có phải là số không
            if (!int.TryParse(Thangtext, out Thang) || !int.TryParse(Ngaytext, out Ngay))
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin Và Hợp Lệ!");
                return;
            }
            if (string.IsNullOrWhiteSpace(Ngaytext) || string.IsNullOrWhiteSpace(Thangtext))
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            List<GoodReceipt> gr = GoodReceiptDAO.Instance.GetPhieuNhapHang(TenLoai,SDT,Thang,Ngay);
            if(gr.Count >0)
            {
                DataGridView_UCgoodreceipt.DataSource = gr;
                DataGridView_UCgoodreceipt.Columns["ID"].HeaderText = "STT";
                DataGridView_UCgoodreceipt.Columns["TenLoaiSanPham"].HeaderText = "Tên Loại Sản Phẩm";
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

        private void ComboBox_UCgoodreceipt_LoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy ComboBox từ sender
            ComboBox cbbox = sender as ComboBox;

            if (cbbox.SelectedItem is DataRowView rowView)
            {
                int selectedIDLoai = (int)rowView["Ten"];
            }

        }
        private void LoadTenLoaispToComboBox()
        {
            List<LoaiSP> listIDLoai = ProductDAO.Instance.GetListSanPham();
            ComboBox_UCgoodreceipt_LoaiDV.DataSource = listIDLoai;
            ComboBox_UCgoodreceipt_LoaiDV.DisplayMember = "Ten";
        }

        private void ComboBox_UCgoodreceipt_SDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbbox = sender as ComboBox;

            if (cbbox.SelectedItem is DataRowView rowView)
            {
                int selectedSdt = (int)rowView["sodienthoai"];
            }
        }
        private void LoadListSdt()
        {
            List<NhaCungCap> listSdt = NhaCungCapDAO.Instance.GetListSdt();
            ComboBox_UCgoodreceipt_SDT.DataSource = listSdt;
            ComboBox_UCgoodreceipt_SDT.DisplayMember = "sodienthoai";
        }

        private void Button_UCgoodreceipt_Sua_Click(object sender, EventArgs e)
        {
            if (DataGridView_UCgoodreceipt.Rows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm Để Cập Nhật!");
                return;
            }
            foreach (DataGridViewRow row in DataGridView_UCgoodreceipt.Rows)
            {
                string TenLoai = row.Cells["TenLoaiSanPham"].Value.ToString();
                int SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                float DonGia = Convert.ToSingle(row.Cells["DonGia"].Value);
                DataGridView_UCgoodreceipt.ReadOnly = false;
                DataGridView_UCgoodreceipt.Columns["ID"].ReadOnly = true;
                bool isUpdate = GoodReceiptDAO.Instance.UpdatePhieuNhapHang( TenLoai,SoLuong, DonGia);
                if (!isUpdate)
                {
                    MessageBox.Show("Cập Nhật Sản Phẩm Thất Bại! Vui Lòng Thử Lại!");
                    return;
                }
                else
                {
                    MessageBox.Show("Cập Nhật Sản Phẩm Thành Công!");
                    return;
                }
            }
        }
    }
}
