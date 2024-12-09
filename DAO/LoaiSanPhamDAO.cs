using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CuaHangDaQuy.DAO
{
    public class LoaiSanPhamDAO
    {
        private static LoaiSanPhamDAO instance;
        public static LoaiSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiSanPhamDAO();
                }
                return LoaiSanPhamDAO.instance;
            }
            private set { instance = value; }
        }

        private LoaiSanPhamDAO() { }

        public List<string> GetListLoaiSanPham()
        {
            List<string> listTenLoai = new List<string>();
            string query = "select distinct Ten from LoaiSanPham";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                if (row["Ten"] != DBNull.Value)
                {
                    listTenLoai.Add(row["Ten"].ToString());
                }
            }

            return listTenLoai;
        }

        //public string GetTenLoaiByID(string idSanPham)
        //{
        //    // Gọi stored procedure và truyền tham số
        //    string query = "USP_GetTenLoaiByID @idsanpham";
        //    DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { idSanPham });

        //    if (result.Rows.Count > 0)
        //    {
        //        return result.Rows[0]["Ten"].ToString();
        //    }
        //    return null;
        //}


        //public LoaiSP GetIDbyTen(string ten)
        //{
        //    string query = "Select ID from LoaiSanPham where Ten = " + ten;
        //    DataTable data = DataProvider.Instance.ExcuteQuery(query);
        //    foreach (DataRow item in data.Rows)
        //    {
        //        return new LoaiSP(item);
        //    }
        //    return null;
        //}
    }
}
