﻿using CuaHangDaQuy.DTO;
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
           
            string LoiNhuanText = TextBox_AddProduct_loi_nhuan.Text;
            int SoLuong = 0;
            float DonGia = 0;
            int LoiNhuan = Convert.ToInt32(LoiNhuanText);
            if (string.IsNullOrWhiteSpace(TenSanpham) ||
                
                string.IsNullOrEmpty(LoiNhuanText)
               )
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            if (add_Product(TenSanpham, TenLoai, SoLuong, DonGia, LoiNhuan))
            {
                MessageBox.Show("Thêm Sản Phẩm Thành Công!");
                this.Close();
            }
        }
        bool add_Product(string TenSanpham, string TenLoai, int SoLuong, float DonGia, int LoiNhuan)
        {
            return ProductDAO.Instance.AddSanPham(TenSanpham, TenLoai, SoLuong, DonGia, LoiNhuan);
        }

        private void Button_AddProduct_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
