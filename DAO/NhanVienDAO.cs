using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienDAO();
                }
                return NhanVienDAO.instance;
            }
            private set { instance = value; }
        }

        private NhanVienDAO() { }

        public bool Login_Admin(string username, string password)
        {
            string query = "USP_Login @taikhoan , @matkhau";

            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { username, password });

            return result.Rows.Count > 0;
        }

        //public List<NhanVien> GetNhanVienID(int id)
        //{
        //    List<NhanVien> list = new List<NhanVien>();
        //    string query = "select * from NhanVien where ID = " + id;

        //    DataTable data = DataProvider.Instance.ExcuteQuery(query);

        //    foreach (DataRow item in data.Rows)
        //    {
        //        NhanVien nhanvien = new NhanVien(item);
        //        list.Add(nhanvien);
        //    }
        //    return list;

        //}
        public NhanVien GetNhanVienByID(string id)
        {
            string query = "USP_GetNhanVienByID @id ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                return new NhanVien(item);
            }
            return null;
        }

        public NhanVien GetNhanVienByUserName(string username)
        {
            string query = "USP_GetNhanVienByUsername @username ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] {username});
            foreach (DataRow item in data.Rows)
            {
                return new NhanVien(item);
            }
            return null;
        }

        public bool InsertNhanVien(string taikhoan, string matkhau, string ten, string email)
        {
            string query = "USP_InsertNhanVien @username , @password , @ten , @email ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {taikhoan, matkhau, ten, email});

            return result > 0;
        }

        public bool checkNhanVien(string username)
        {
            string query = "select TaiKhoan from NhanVien";

            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            bool result2 = false;
            foreach (DataRow row in result.Rows)
            {
                if (string.CompareOrdinal(row["TaiKhoan"].ToString(),username) == 0)
                {   
                    result2 = true;
                }
                
            }
            return result2;    
        }

        public bool changePassWord(int id, string password)
        {
            string query = "USP_UpdatePassword @IDNhanVien , @NewPassword ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id , password });
            return result > 0;
        }
    }
}

