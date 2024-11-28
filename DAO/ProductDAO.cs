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
        public List<int> GetListSanPham()
        {
            List<int> listIDLoai = new List<int>();
            string query = "select distinct IDLoai from SanPham";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                if (row["idloai"] != DBNull.Value)
                {
                    listIDLoai.Add(Convert.ToInt32(row["IDLoai"]));
                }
            }

            return listIDLoai;
        }

        public List<string> GetTenSanPham()
        {
            List<string> listIDLoai = new List<string>();
            string query = "select distinct TenSanPham from SanPham";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                if (row["TenSanPham"] != DBNull.Value)
                {
                    listIDLoai.Add(row["TenSanPham"].ToString());
                }
            }

            return listIDLoai;
        }
        public bool InsertProduct(string tenSanPham, int idLoai, float donGia, int soLuong)
        {
            string query = "EXEC ThemSanPham @TenSanPham , @IDLoai , @DonGia , @SoLuong";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { tenSanPham, idLoai, donGia, soLuong });
            return result > 0;
        }


    }
}