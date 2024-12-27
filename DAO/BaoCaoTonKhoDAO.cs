using CNPM;
using CNPM.DTO;
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
    public class BaoCaoTonKhoDAO
    {
        private static BaoCaoTonKhoDAO instance;
        public static BaoCaoTonKhoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoTonKhoDAO();
                return BaoCaoTonKhoDAO.instance;
            }
            private set { BaoCaoTonKhoDAO.instance = value; }
        }
        private BaoCaoTonKhoDAO() { }

        public List<BaoCaoTonKhodto> GetTonKho(int thang, int nam)
        {
            List<BaoCaoTonKhodto> listTk = new List<BaoCaoTonKhodto>();
            string query = "USP_GetTonKhoByMonthYear @month , @year";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { thang, nam });

            foreach (DataRow row in data.Rows)
            {
                BaoCaoTonKhodto tk = new BaoCaoTonKhodto(row);
                listTk.Add(tk);
            }
            return listTk;
        }

    }
}
