using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class PhieuDichVu
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int idkhach;
        public int IDKhach { get => idkhach; set => idkhach = value; }

        private int idnhanvien;
        public int IDNhanVien { get => idnhanvien; set => idnhanvien = value; }

        private int soluong;
        public int SoLuong { get => soluong; set => soluong = value; }

        private float tratruoc;
        public float TraTruoc { get => tratruoc; set => tratruoc = value; }

        private DateTime ngayban;
        public DateTime NgayBan { get => ngayban; set => ngayban = value; }


        public PhieuDichVu(int id, int idkhach, int idnhanvien, int soluong, float tratruoc, DateTime ngayban)
        {
            this.ID = id;
            this.IDKhach = idkhach;
            this.IDNhanVien = idnhanvien;
            this.SoLuong = soluong;
            this.TraTruoc = tratruoc;
            this.NgayBan = ngayban;
        }

        public PhieuDichVu(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDKhach = (int)row["IDKhach"];
            this.IDNhanVien = (int)row["IDNhanVien"];
            this.SoLuong = (int)row["SoLuong"];
            this.TraTruoc = (float)row["TraTruoc"];
            this.NgayBan = (DateTime)row["NgayBan"];
        }
    }
}
