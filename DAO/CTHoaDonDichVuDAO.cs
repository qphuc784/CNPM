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
    public class CTHoaDonDichVuDAO
    {
        private static CTHoaDonDichVuDAO instance;
        public static CTHoaDonDichVuDAO Instance
        {
            get
            {
                if (instance == null) instance = new CTHoaDonDichVuDAO();
                return CTHoaDonDichVuDAO.instance;
            }
            private set { CTHoaDonDichVuDAO.instance = value; }
        }
        private CTHoaDonDichVuDAO() { }

        public List <CTPhieuDichVu> GetListCTPDVByIDKhachHang(int idServiceBill)
        {

            List <CTPhieuDichVu> ctpdvList = new List<CTPhieuDichVu> ();

            DataTable data = DataProvider.Instance.ExcuteQuery("EXEC USP_GetListServiceBillInfo @idServiceBill ", new object[] {idServiceBill});

            foreach (DataRow item in data.Rows)
            {
                CTPhieuDichVu ctpdv = new CTPhieuDichVu(item);
                ctpdvList.Add(ctpdv);
            }
            return ctpdvList;

        }
        public bool UpdateTrangThai(bool trangthai, int ID)
        {
            string query = "USP_UpdateCTHDDV @TrangThai , @ID";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { trangthai,ID });
            return result > 0;
        }
    }
}
