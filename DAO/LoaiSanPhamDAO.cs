﻿using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CuaHangDaQuy.DAO
{
    public class LoaiSanPhamDAO
    {
        private static LoaiSanPhamDAO instance;
        public static LoaiSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiSanPhamDAO();
                }
                return LoaiSanPhamDAO.instance;
            }
            private set { instance = value; }
        }

        private LoaiSanPhamDAO() { }

        public List<string> GetDVTByIDLoai(int idloai)
        {
            List<string> listDonViTinh = new List<string>();
            string query = "USP_GetDVTByIDLoai @idloai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { idloai });

            foreach (DataRow row in data.Rows)
            {
                string donViTinh = row["DonViTinh"].ToString();
                listDonViTinh.Add(donViTinh);
            }

            return listDonViTinh;
        }

        public List<string> GetDonGiaBan(int idloai)
        {
            List<string> listdonGiaBan = new List<string>();
            string query = "USP_GetDonGiaBan @idloai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { idloai });

            foreach (DataRow row in data.Rows)
            {
                string donGiaBan = row["DonGiaBan"].ToString();
                listdonGiaBan.Add(donGiaBan);
            }

            return listdonGiaBan;
        }
    }
}
