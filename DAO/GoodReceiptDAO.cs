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

        public List<GoodReceipt> GetPhieuNhapHang(string ID)
        {
            List<GoodReceipt> listpnh = new List<GoodReceipt>();
            string query = "USP_GetPhieuNhapHangByID @ID";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { ID });

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
        public List<GoodReceipt> GetListID()
        {
            List<GoodReceipt> listID = new List<GoodReceipt>();
            string query = "select * from PhieuNhapHang";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                GoodReceipt idphieu = new GoodReceipt(row);
                listID.Add(idphieu);
            }
            return listID;
        }
        public bool DeletePhieuNhapHang(int ID)
        {
            string query = "USP_DeletePhieuNhapHangByID @ID";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { ID });
            return result > 0;
        }
        public bool DeletePhieuNhapHangBy2(int ID, int IDct)
        {
            string query = "USP_DeletePhieuNhapHangAndCTByID @ID , @IDCT";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { ID, IDct });
            return result > 0;
        }
        public List<GoodReceipt> GetPhieuNhapHangBy2ID(string ID, string IDCT)
        {
            List<GoodReceipt> listpnh = new List<GoodReceipt>();
            string query = "USP_GetPhieuNhapHangByIDAndIDCT @ID , @IDCT";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { ID, IDCT });

            foreach (DataRow row in data.Rows)
            {
                GoodReceipt pnh = new GoodReceipt(row);
                listpnh.Add(pnh);
            }

            return listpnh;
        }
    }
}
