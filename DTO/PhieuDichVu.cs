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


        private float tratruoc;
        public float TraTruoc { get => tratruoc; set => tratruoc = value; }

        private DateTime ngayban;
        public DateTime NgayBan { get => ngayban; set => ngayban = value; }

        private bool trangthai;
        public bool TrangThai { get => trangthai; set => trangthai = value; }

        public PhieuDichVu(int id, int idkhach, int idnhanvien, float tratruoc, DateTime ngayban, bool trangthai)
        {
            this.ID = id;
            this.IDKhach = idkhach;
            this.IDNhanVien = idnhanvien;
            this.TraTruoc = tratruoc;
            this.NgayBan = ngayban;
            this.TrangThai = trangthai;
        }

        public PhieuDichVu(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDKhach = (int)row["IDKhach"];
            this.IDNhanVien = (int)row["IDNhanVien"];
            this.TraTruoc = Convert.ToSingle(row["TraTruoc"]);
            this.NgayBan = (DateTime)row["NgayBan"];
            this.TrangThai = (bool)row["TrangThai"];
        }
    }
}
