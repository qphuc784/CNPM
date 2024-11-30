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
            List<string> listIDLoai = LoaiSanPhamDAO.Instance.GetListLoaiSanPham();
            gunaComboBox_AddProduct_loai_san_pham.DataSource = listIDLoai;
            gunaComboBox_AddProduct_loai_san_pham.DisplayMember = "Ten";
        }

        private void gunaComboBox_AddProduct_loai_san_pham_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Lấy ComboBox từ sender
            GunaComboBox cbbox = sender as GunaComboBox;

            if (cbbox.SelectedItem is DataRowView rowView)
            {
                //int selectedIDLoai = (int)rowView["Ten"];
                string selectedtenloai = (string)rowView["Ten"];
            }

        }

        private void Button_AddProduct_Ok_Click(object sender, EventArgs e)
        {
            string tensanpham = TextBox_AddProduct_ten_san_pham.Text;
            string tenloaisp = gunaComboBox_AddProduct_loai_san_pham.SelectedText;
            string soluong = TextBox_AddProduct_So_luong.Text;
            string dongia = TextBox_AddProduct_Don_gia.Text; 
            //int soluong1=Convert.ToInt32(soluong);
            //float dongia1=Convert.ToInt32(dongia);

            if (string.IsNullOrWhiteSpace(TextBox_AddProduct_ten_san_pham.Text) ||
                 string.IsNullOrWhiteSpace(TextBox_AddProduct_Don_gia.Text) ||
                 string.IsNullOrWhiteSpace(TextBox_AddProduct_So_luong.Text))
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ!");
                return;
            }
            if (add_product(tensanpham,tenloaisp,soluong,dongia))
            {
                MessageBox.Show("Thanh Cong!");
                this.Close();
            }
            else
            {
                MessageBox.Show("That Bai!");
            }
            
        }
        bool add_product(string tensanpham, string tenloaisp, string soluong,string dongia)
        {
            return ProductDAO.Instance.InsertProduct(tensanpham, tenloaisp, dongia, soluong);
        }

    }
}