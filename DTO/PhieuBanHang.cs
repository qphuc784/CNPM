using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class PhieuBanHang
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int iDkhachhang;
        public int IDKhachHang { get => iDkhachhang; set => iDkhachhang = value; }

        private int iDnhanvien;
        public int IDNhanVien { get => iDnhanvien; set => iDnhanvien = value; }

        private DateTime ngayban;
        public DateTime NgayBan { get => ngayban; set => ngayban = value; }

        public PhieuBanHang(int id, int idkhach, int idsp, int soluong, int iDnhanvien, DateTime ngayban)
        {
            this.ID = id;
            this.IDKhachHang = idkhach;
            this.IDNhanVien = iDnhanvien;
            this.NgayBan = ngayban;
        }

        public PhieuBanHang(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDKhachHang = (int)row["IDKhachHang"];
            this.IDNhanVien = (int)row["IDNhanVien"];
            this.NgayBan = (DateTime)row["NgayBan"];
        }
    }
}
