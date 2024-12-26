using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonDAO();
                }
                return HoaDonDAO.instance;
            }
            private set { instance = value; }
        }

        private HoaDonDAO() { }

        public int GetIDHoaDon ()
        {
            string query = "SELECT ISNULL(MAX(ID), 0) + 1 AS NextID FROM HoaDonBanHang";
            try
            {
                object result = DataProvider.Instance.ExcuteScalar(query);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching next Product Bill ID: {ex.Message}");
            }

            return 0;
        }

        public bool AddHDBanHang (int id, int idkhach, int idnhanvien, string ngayban)
        {
            string query = "USP_InsertHoaDon @id , @idkhach , @idnhanvien , @ngayban ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, idkhach , idnhanvien , ngayban });
            return result > 0;
        }

        public bool AddCTHDBanHang (int idhoadon, int idsanpham, int soluong)
        {
            string query = "USP_InsertCTHoaDon @idhoadon , @idsanpham , @soluong ";
            int result = DataProvider.Instance.ExcuteNonQuery (query, new object[] { idhoadon , idsanpham , soluong });
            return result > 0;
        }
    }
}
