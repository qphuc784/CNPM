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
    public class LoaiDichVuDAO
    {
        private static LoaiDichVuDAO instance;
        public static LoaiDichVuDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiDichVuDAO();
                }
                return LoaiDichVuDAO.instance;
            }
            private set { instance = value; }
        }

        private LoaiDichVuDAO() { }

        public List<LoaiDichVu> GetListLoaiDV()
        {
            List<LoaiDichVu> listDV = new List<LoaiDichVu>();
            string query = "select * from LoaiDichVu";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                LoaiDichVu dv = new LoaiDichVu(row);
                listDV.Add(dv);
            }

            return listDV;
        }

        public List<string> GetDonGiaDichVu(int iddichvu)
        {
            List<string> listdonGiaDichVu = new List<string>();
            string query = "USP_GetDonGiaDichVu  @id ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { iddichvu });

            foreach (DataRow row in data.Rows)
            {
                string donGiaBan = row["DonGia"].ToString();
                listdonGiaDichVu.Add(donGiaBan);
            }

            return listdonGiaDichVu;
        }
    }
}
