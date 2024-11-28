using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class NhanVien
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private string tennv;
        public string TenNhanVien { get => tennv; set => tennv = value; }

        private string taikhoan;
        public string TaiKhoan { get => taikhoan; set => taikhoan = value; }

        private string matkhau;
        public string MatKhau { get => matkhau; set => matkhau = value; }

        private string chucvu;
        public string ChucVu { get => chucvu; set => chucvu = value; }

        private string email;
        public string Email { get => email; set => email = value; }


        public NhanVien(int iD, string tennv, string taikhoan, string matkhau, string chucvu, string email)
        {
            this.ID = iD;
            this.TenNhanVien = tennv;
            this.TaiKhoan = taikhoan;
            this.MatKhau = matkhau;
            this.ChucVu = chucvu;
            this.Email = email;
        }
        public NhanVien(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.TenNhanVien = row["TenNhanVien"].ToString();
            this.TaiKhoan = row["TaiKhoan"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.ChucVu = row["ChucVu"].ToString();
            this.Email = row["Email"].ToString();
        }
    }
}
