using CuaHangDaQuy.DTO;
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

        public List<string> GetDonGiaBan(int idsp)
        {
            List<string> listdonGiaBan = new List<string>();
            string query = "USP_GetDonGiaBan @idsp ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { idsp });

            foreach (DataRow row in data.Rows)
            {
                string donGiaBan = row["DonGiaBan"].ToString();
                listdonGiaBan.Add(donGiaBan);
            }

            return listdonGiaBan;
        }
        public List<string> GetDonGiaMua(int idsp)
        {
            List<string> listdonGiaMua = new List<string>();
            string query = "USP_GetDonGiaMua @idsp ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { idsp });

            foreach (DataRow row in data.Rows)
            {
                string donGiaMua = row["DonGiaMua"].ToString();
                listdonGiaMua.Add(donGiaMua);
            }

            return listdonGiaMua;
        }

        public bool AddLoaiSanPham(string Tenloai, int LoiNhuan, string DonViTinh)
        {
            string query = "USP_AddProductType @TenLoai , @LoiNhuan , @DonViTinh";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { Tenloai, LoiNhuan, DonViTinh });
            return result > 0;
        }
        public bool UpdateLoaiSanPham(int ID, string TenLoai, int LoiNhuan)
        {
            string query = "USP_UpdateLoaiSanPham @ID , @TenLoai , @LoiNhuan";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { ID, TenLoai, LoiNhuan, });
            return result > 0;
        }

        public bool AddLoaiSanPham(string TenLoai, string DonViTinh)
        {
            string query = "USP_AddProductType @TenLoai , @DonViTinh";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenLoai, DonViTinh });
            return result > 0;
        }
        public List<LoaiSP> GetLoaiSPByTenLoai(string TenLoai)
        {
            List<LoaiSP> listlsp = new List<LoaiSP>();
            string query = "USP_GetLoaiSanPhamByTenLoai @TenLoai";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new Object[] { TenLoai });
            foreach (DataRow row in data.Rows)
            {
                LoaiSP lsp = new LoaiSP(row);
                listlsp.Add(lsp);
            }
            return listlsp;
        }
        public bool DeleteLoaiSanPhamByTen(string TenLoai)
        {
            string query = "USP_DeleteLoaiSanPhamByTenLoai @TenLoai ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenLoai });
            return result > 0;
        }
        public bool UpdateLoaiSanPham(int ID, string TenLoai, string DonViTinh)
        {
            string query = "USP_UpdateLoaiSanPham @ID , @TenLoai , @DonViTinh";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { ID, TenLoai, DonViTinh });
            return result > 0;
        }

    }
}
