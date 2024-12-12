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

        private int iddichvu;
        public int IDDichVu { get => iddichvu; set => iddichvu = value; }

        private int soluong;
        public int SoLuong { get => soluong; set => soluong = value; }

        private string tinhtrang;
        public string TinhTrang { get => tinhtrang; set => tinhtrang = value; }

        private float tratruoc;
        public float TraTruoc { get => tratruoc; set => tratruoc = value; }

        private DateTime ngayban;
        public DateTime NgayBan { get => ngayban; set => ngayban = value; }

        private int idnhanvien;
        public int IDNhanVien { get => idnhanvien; set => idnhanvien = value; }


        public PhieuDichVu(int id, int idkhach, int iddichvu, int soluong, string tinhtrang, float tratruoc, DateTime ngayban, int idnhanvien)
        {
            this.ID = id;
            this.IDKhach = idkhach;
            this.IDDichVu = iddichvu;
            this.SoLuong = soluong;
            this.TinhTrang = tinhtrang;
            this.TraTruoc = tratruoc;
            this.NgayBan = ngayban;
            this.IDNhanVien = idnhanvien;
        }

        public PhieuDichVu(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDKhach = (int)row["IDKhach"];
            this.IDDichVu = (int)row["IDDichVu"];
            this.SoLuong = (int)row["SoLuong"];
            this.TinhTrang = row["TinhTrang"].ToString();
            this.TraTruoc = (float)row["TraTruoc"];
            this.NgayBan = (DateTime)row["NgayBan"];
            this.IDNhanVien = (int)row["IDNhanVien"];
        }
    }
}
