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
        public List<SanPham> GetListSanPham()
        {
            List<SanPham> listSP = new List<SanPham>();
            string query = "select * from SanPham";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                SanPham sp = new SanPham(row);
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

        public List<string> GetTenSanPhamByLoai(string loaiSanPham)
        {
            List<string> listTenSP = new List<string>();
            string query = "USP_GetTenSPByLoai @tenloai";

            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { loaiSanPham });

            foreach (DataRow row in data.Rows)
            {
                listTenSP.Add(row["TenSanPham"].ToString());
            }

            return listTenSP;
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
    }
}