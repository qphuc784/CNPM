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
using System.Data.SqlClient;
using CuaHangDaQuy.DAO;

namespace CNPM
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
            LoadIDLoaiToComboBox();

            // Gán sự kiện SelectedIndexChanged cho ComboBox
            gunaComboBox_AddProduct_loai_san_pham.SelectedIndexChanged += gunaComboBox_AddProduct_loai_san_pham_SelectedIndexChanged_1;

        }


        private void LoadIDLoaiToComboBox()
        {
            List<LoaiSP> listIDLoai = ProductDAO.Instance.GetListSanPham();
            gunaComboBox_AddProduct_loai_san_pham.DataSource = listIDLoai;
            gunaComboBox_AddProduct_loai_san_pham.DisplayMember = "Ten";
        }

        private void gunaComboBox_AddProduct_loai_san_pham_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Lấy ComboBox từ sender
            GunaComboBox cbbox = sender as GunaComboBox;

            if (cbbox.SelectedItem is DataRowView rowView)
            {
                int selectedIDLoai = (int)rowView["Ten"];
            }

        }

        private void Button_AddProduct_Ok_Click(object sender, EventArgs e)
        {
            string TenSanpham = TextBox_AddProduct_ten_san_pham.Text;
            string TenLoai = gunaComboBox_AddProduct_loai_san_pham.Text;
            string SoLuongText = TextBox_AddProduct_So_luong.Text;
            string DonGiaText = TextBox_AddProduct_Don_gia.Text;
            int SoLuong = Convert.ToInt32(SoLuongText);
            float DonGia = Convert.ToSingle(DonGiaText);
            if (string.IsNullOrWhiteSpace(TenSanpham) ||
                string.IsNullOrEmpty(SoLuongText) ||
                string.IsNullOrEmpty(DonGiaText)
               )
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            if (add_Product(TenSanpham, TenLoai, SoLuong, DonGia))
            {
                MessageBox.Show("Thêm Sản Phẩm Thành Công!");
                this.Close();
            }
        }
        bool add_Product(string TenSanpham, string TenLoai, int SoLuong, float DonGia)
        {
            return ProductDAO.Instance.AddSanPham(TenSanpham, TenLoai, SoLuong, DonGia);
        }

        private void Button_AddProduct_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaComboBox_AddProduct_loai_san_pham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}