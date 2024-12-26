using CNPM;
using CNPM.DTO;
using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DAO
{
    public class GoodReceiptDAO
    {
        private static GoodReceiptDAO instance;
        public static GoodReceiptDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GoodReceiptDAO();
                }
                return GoodReceiptDAO.instance;
            }
            private set { instance = value; }
        }

        private GoodReceiptDAO() { }

        public List<GoodReceipt> GetPhieuNhapHang(string TenLoai, string SDT, int Thang, int Ngay)
        {
            List<GoodReceipt> listpnh = new List<GoodReceipt>();
            string query = "USP_GetPhieuNhapHang @TenLoaiSanPham , @SoDienThoai , @ThangMua , @NgayMua";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { TenLoai, SDT, Thang, Ngay });

            foreach (DataRow row in data.Rows)
            {
                GoodReceipt pnh = new GoodReceipt(row);
                listpnh.Add(pnh);
            }

            return listpnh;
        }
        public bool UpdatePhieuNhapHang(string TenLoai, int SoLuong, float DonGia)
        {
            string query = "USP_UpdatePhieuNhapHang @TenSanPham , @SoLuong , @DonGia";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenLoai, SoLuong, DonGia });
            return result > 0;
        }

    }
}