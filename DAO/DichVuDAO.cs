using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;
        public static DichVuDAO Instance
        {
            get
            {
                if (instance == null) instance = new DichVuDAO();
                return DichVuDAO.instance;
            }
            private set { DichVuDAO.instance = value; }
        }
        private DichVuDAO() { }

        public List<PhieuDichVu> GetDichVuByIDLoai(int idloai)
        {
            List<PhieuDichVu> listDV = new List<PhieuDichVu>();
            string query = "USP_GetDichVuByIDLoai @idloai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { idloai });

            foreach (DataRow row in data.Rows)
            {
                PhieuDichVu dv = new PhieuDichVu(row);
                listDV.Add(dv);
            }

            return listDV;
        }
        public bool Add_Service(string TenLoai, float DonGia)
        {
            string query = "USP_AddService @TenLoai , @DonGia ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenLoai, DonGia });
            return result > 0;

        }
        public bool checkTenLoaiDV(string TenLoai)
        {
            string query = "select TenLoai from LoaiDichVu\r\n";

            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            bool result2 = false;
            foreach (DataRow row in result.Rows)
            {
                if (string.CompareOrdinal(row["TenLoai"].ToString(), TenLoai) == 0)
                {
                    result2 = true;
                }
            }
            return result2;
        }
        public List<LoaiDichVu> GetDichVuByTenLoai(string TenLoai)
        {
            List<LoaiDichVu> listdv = new List<LoaiDichVu>();
            string query = "USP_GetDichVuByTenLoai @TenLoai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new Object[] { TenLoai });
            foreach (DataRow row in data.Rows)
            {
                LoaiDichVu dv = new LoaiDichVu(row);
                listdv.Add(dv);
            }
            return listdv;
        }
        public bool DeleteDichVuByTenLoai(string TenLoai)
        {
            string query = "USP_DeleteDichVuByTenLoai @TenLoai";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenLoai });
            return result > 0;
        }
        public bool UpdateDichVu(string TenLoai, float DonGia, int ID)
        {
            string query = " USP_UpdateDichVu @TenLoai , @DonGia , @ID";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { TenLoai, DonGia, ID });
            return result > 0;
        }
    }
}
