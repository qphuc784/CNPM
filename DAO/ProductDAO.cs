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

        public bool InsertProduct(string tenSanPham, int idLoai, float donGia, int soLuong)
        {
            string query = "EXEC ThemSanPham @TenSanPham , @IDLoai , @DonGia , @SoLuong";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { tenSanPham, idLoai, donGia, soLuong });
            return result > 0;
        }

        public SanPham GetIDSanPhamByTen(string tensp)
        {
            string query = "USP_GetIDSanPhamByTen @tensanpham ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { tensp });
            foreach (DataRow item in data.Rows)
            {
                return new SanPham(item);
            }
            return null;
        }

        public DataTable GetTenSanPhamByLoai(string loaiSanPham)
        {
            //List<string> listTenSP = new List<string>();
            string query = "USP_GetTenSPByLoai @tenloai";

            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { loaiSanPham });

            //foreach (DataRow row in data.Rows)
            //{
            //    listTenSP.Add(row["TenSanPham"].ToString());
            //}

            return data;
        }
        public List<SanPham> GetSanPhamByLoai(string loai)
        {
            List<SanPham> listSP = new List<SanPham>();
            string query = "USP_GetSanPhamByLoai";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { loai });

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