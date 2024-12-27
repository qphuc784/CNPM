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
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;
        public static NhaCungCapDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhaCungCapDAO();
                }
                return NhaCungCapDAO.instance;
            }
            private set { instance = value; }
        }

        private NhaCungCapDAO() { }

        public NhaCungCap GetNhaCungCapBySdt(string sodienthoai)
        {
            string query = "USP_GetNhaCungCapBySdt @sodienthoai ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { sodienthoai });
            foreach (DataRow item in data.Rows)
            {
                return new NhaCungCap(item);
            }
            return null;
        }

        public bool checkSdtNhaCungCap(string sdt)
        {
            string query = "select SoDienThoai from NhaCungCap";

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

        public bool AddNhaCungCap(string diachi, string sodienthoai)
        {
            string query = "USP_AddNhaCungCap @diachi , @sodienthoai ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { diachi, sodienthoai });

            return result > 0;
        }
        public List<NhaCungCap> GetListSdt()
        {
            List<NhaCungCap> listSdt = new List<NhaCungCap>();
            string query = "select * from NhaCungCap";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NhaCungCap sdt = new NhaCungCap(row);
                listSdt.Add(sdt);
            }
            return listSdt;
        }
    }
}