using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonDAO();
                }
                return HoaDonDAO.instance;
            }
            private set { instance = value; }
        }

        private HoaDonDAO() { }

        public bool AddHDBanHang (int idkhach, int idsp,int soluong, int idnhanvien, string ngayban)
        {
            string query = "USP_AddHDBanHang @idkhach , @idsp , @soluong , @idnhanvien , @ngayban ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { idkhach , idsp , soluong , idnhanvien , ngayban });
            return result > 0;
        }
    }
}
