using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangDAO();
                }
                return KhachHangDAO.instance;
            }
            private set { instance = value; }
        }

        private KhachHangDAO() { }

        public bool AddKhachHang(string tenkhachhang, string sodienthoai)
        {
            string query = "USP_AddKhachHang @tenkhachhang , @sodienthoai ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { tenkhachhang, sodienthoai });

            return result > 0;
        }

        public bool checkSdtKhachHang(string sdt)
        {
            string query = "select SoDienThoai from KhachHang";

            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            bool result2 = false;
            foreach (DataRow row in result.Rows)
            {
                if (string.CompareOrdinal(row["SoDienThoai"].ToString(), sdt) == 0)
                {
                    result2 = true;
                }

            }
            return result2;
        }

        public KhachHang GetKhachHang(string ten, string sodienthoai)
        {
            string query = "USP_GetKhachHang @tenkhachhang , @sodienthoai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { ten, sodienthoai });
            foreach (DataRow item in data.Rows)
            {
                return new KhachHang(item);
            }
            return null;
        }
        public KhachHang GetKhachHangBySdt(string sodienthoai)
        {
            string query = "USP_GetKhachHangBySdt @sodienthoai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { sodienthoai });
            foreach (DataRow item in data.Rows)
            {
                return new KhachHang(item);
            }
            return null;
        }

        public List<KhachHang> LoadListKH()
        {
            List<KhachHang> khList = new List<KhachHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM KhachHang ");

            foreach (DataRow item in data.Rows)
            {
                KhachHang kh = new KhachHang(item);
                khList.Add(kh);
            }
            return khList;
        }
    }
}
