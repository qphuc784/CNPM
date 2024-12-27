using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DAO
{
    public class HoaDonMuaHangDAO
    {
        private static HoaDonMuaHangDAO instance;
        public static HoaDonMuaHangDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonMuaHangDAO();
                }
                return HoaDonMuaHangDAO.instance;
            }
            private set { instance = value; }
        }

        private HoaDonMuaHangDAO() { }

        public int GetIDHoaDon()
        {
            string query = "SELECT ISNULL(MAX(ID), 0) + 1 AS NextID FROM PhieuNhapHang";
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

        public bool AddHDMuaHang(int id, int idnhanvien, string ngaymua)
        {
            string query = "USP_InsertPhieuNhapHang @id , @idnhanvien , @ngayban ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, idnhanvien, ngaymua });
            return result > 0;
        }

        public bool AddCTHDMuaHang(int idphieunhaphang, int idncc , int idsanpham, int soluong, int dongia)
        {
            string query = "USP_InsertCTPhieuNhapHang @idphieunhaphang , @idncc , @idsanpham , @soluong , @dongia ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { idphieunhaphang, idncc , idsanpham , soluong , dongia });
            return result > 0;
        }
        public List<PhieuMuaHang> GetListID()
        {
            List<PhieuMuaHang> listID = new List<PhieuMuaHang>();
            string query = "select * from PhieuNhapHang";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                PhieuMuaHang idphieu = new PhieuMuaHang(row);
                listID.Add(idphieu);
            }
            return listID;
        }
    }
}
