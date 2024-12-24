using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class PhieuMuaHang
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int iDNhanVien;
        public int IDNhanVien { get => iDNhanVien; set => iDNhanVien = value; }

        private DateTime ngaymua;
        public DateTime NgayMua { get => ngaymua; set => ngaymua = value; }

        public PhieuMuaHang(int iD, int iDNhanVien, DateTime ngaymua)
        {
            this.ID = iD;
            this.IDNhanVien = iDNhanVien;
            this.NgayMua = ngaymua;
        }

        public PhieuMuaHang(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDNhanVien = (int)row["IDNhanVien"];
            this.NgayMua = (DateTime)row["NgayMua"];
        }
    }
}
