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
            List<int> listIDLoai = ProductDAO.Instance.GetListSanPham();
            gunaComboBox_AddProduct_loai_san_pham.DataSource = listIDLoai;
            gunaComboBox_AddProduct_loai_san_pham.DisplayMember = "IDLoai";
        }

        private void gunaComboBox_AddProduct_loai_san_pham_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Lấy ComboBox từ sender
            GunaComboBox cbbox = sender as GunaComboBox;

            if (cbbox != null && cbbox.SelectedItem != null)
            {
                // Lấy IDLoai đã chọn từ ComboBox
                int selectedIDLoai = (int)cbbox.SelectedItem; // Chuyển đổi sang int

            }

        }
    }
}