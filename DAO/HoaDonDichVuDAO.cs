using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DAO
{
    public class HoaDonDichVuDAO
    {
        private static HoaDonDichVuDAO instance;
        public static HoaDonDichVuDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonDichVuDAO();
                }
                return HoaDonDichVuDAO.instance;
            }
            private set { instance = value; }
        }

        private HoaDonDichVuDAO() { }

        public int GetIDHoaDon()
        {
            string query = "SELECT ISNULL(MAX(ID), 0) + 1 AS NextID FROM HoaDonDichVu";
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
                throw new Exception($"Error fetching next Service Bill ID: {ex.Message}");
            }

            return 0;
        }


        public bool AddHDDichVu(int id, int idkhach, int idnhanvien, int tratruoc , string ngayban)
        {
            string query = "USP_InsertHoaDonDichVu @id , @idkhach , @idnhanvien , @tratruoc , @ngayban ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, idkhach , idnhanvien , tratruoc , ngayban });
            return result > 0;
        }

        public bool AddCTHDDichVu(int idhoadon, int iddichvu, int soluong)
        {
            string query = "USP_InsertCTHoaDonDichVu @idhoadon , @idsanpham , @soluong ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { idhoadon , iddichvu , soluong });
            return result > 0;
        }
    }
}
