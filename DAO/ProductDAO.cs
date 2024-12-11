using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CuaHangDaQuy.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null) instance = new ProductDAO();
                return ProductDAO.instance;
            }
            private set { ProductDAO.instance = value; }
        }
        private ProductDAO() { }
        public List<LoaiSP> GetListSanPham()
        {
            List<LoaiSP> listSP = new List<LoaiSP>();
            string query = "select * from LoaiSanPham";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                LoaiSP sp = new LoaiSP(row);
                listSP.Add(sp);
            }

            return listSP;
        }
        public List<SanPham> GetSanPhamByIDLoai(int idloai)
        {
            List<SanPham> listSP = new List<SanPham>();
            string query = "USP_GetSanPhamByIDLoai @idloai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { idloai });

            foreach (DataRow row in data.Rows)
            {
                SanPham sp = new SanPham(row);
                listSP.Add(sp);
            }

            return listSP;
        }
        public bool AddSanPham(string TenSanPham, string TenLoai, int SoLuong, float Dongia)
        {
            string query = "USP_AddSanPham @TenSanPham , @TenLoai , @SoLuong , @Dongia";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenSanPham, TenLoai, SoLuong, Dongia });
            return result > 0;
        }
        public List<SanPham> GetSanPhamByTenSP(string TenSanPham)
        {
            List<SanPham> listsp = new List<SanPham>();
            string query = "USP_GetSanPhamByTenSP @TenSanPham ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new Object[] { TenSanPham });
            foreach (DataRow row in data.Rows)
            {
                SanPham sp = new SanPham(row);
                listsp.Add(sp);
            }
            return listsp;
        }
        public bool DeleteSanPhamByTenSp(string TenSanPham)
        {
            string query = "USP_DeleteSanPhamByTenSp @TenSanPham";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenSanPham });
            return result > 0;
        }
        public bool UpdateSanPham(int SoLuong, bool TrangThai)
        {
            string query = "USP_UpdateSanPham @TenSanPham, @SoLuong, @TrangThai";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { SoLuong, TrangThai });
            return result > 0;
        }

    }
}