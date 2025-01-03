﻿using CuaHangDaQuy.DAO;
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
    public partial class AddProductType : Form
    {
        public AddProductType()
        {
            InitializeComponent();
        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void Button_AddProduct_Ok_Click(object sender, EventArgs e)
        {
            string TenLoai = TextBox_AddProductType_ten_loai_san_pham.Text;
            string DonViTinh = textbox_DonViTinh.Text;
            if (string.IsNullOrWhiteSpace(TenLoai) ||
                string.IsNullOrEmpty(DonViTinh)
               )
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin!");
                return;
            }
            if (add_ProductType(TenLoai, DonViTinh))
            {
                MessageBox.Show("Thêm Sản Phẩm Thành Công!");
                this.Close();
            }
        }
        bool add_ProductType(string TenLoai, string DonViTinh)
        {
            return LoaiSanPhamDAO.Instance.AddLoaiSanPham(TenLoai, DonViTinh);
        }

    }
}