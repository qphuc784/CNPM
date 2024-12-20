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
            string query = "USP_AddSanPham @TenSanPham , @TenLoai , @SoLuong , @Dongia ";
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
            string query = "USP_DeleteSanPhamByTenSp @TenSanPham ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenSanPham });
            return result > 0;
        }
        public bool UpdateSanPham(int ID, string TenSanPham, int SoLuong)
        {
            string query = "USP_UpdateSanPham @ID , @TenSanPham , @SoLuong ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { ID, TenSanPham, SoLuong, });
            return result > 0;
        }


        public List<SanPham> GetSanPhamByTenLoai(string TenLoai)
        {
            List<SanPham> listSP = new List<SanPham>();
            string query = "USP_HienThiTonkho @TenLoai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { TenLoai });

            foreach (DataRow row in data.Rows)
            {
                SanPham sp = new SanPham(row);
                listSP.Add(sp);
            }
            return listSP;
        }
        public List<SanPham> USP_GetAllSanPhamByTenLoai(string TenLoai, DateTime TuNgay, DateTime DenNgay)
        {
            List<SanPham> listSP = new List<SanPham>();
            string query = "USP_GetAllSanPhamByTenLoai @TenLoai , @TuNgay , @DenNgay";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { TenLoai, TuNgay, DenNgay });

            foreach (DataRow row in data.Rows)
            {
                SanPham sp = new SanPham(row);
                listSP.Add(sp);
            }
            return listSP;
        }

        public int GetSoLuongByID(string idSanPham)
        {
            string query = "SELECT SoLuong FROM SanPham WHERE ID = @idSanPham ";
            object result = DataProvider.Instance.ExcuteScalar(query, new object[] { idSanPham });

            if (result != null && int.TryParse(result.ToString(), out int soLuong))
            {
                return soLuong;
            }

            return 0; // Trả về 0 nếu không tìm thấy hoặc không có dữ liệu
        }

    }
}