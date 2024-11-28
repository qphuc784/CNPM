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
    }
}
