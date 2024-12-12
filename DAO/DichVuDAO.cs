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
    }
}
