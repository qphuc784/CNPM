using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class KhachHang
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private string sdt;
        public string SDT { get => sdt; set => sdt = value; }

        private string tenkhachhang;
        public string Tenkhachhang { get => tenkhachhang; set => tenkhachhang = value; }

        public KhachHang(int id, string sdt, int diem, string tenkhachhang)
        {
            this.ID = id;
            this.SDT = sdt;
            this.Tenkhachhang = tenkhachhang;
        }

        public KhachHang(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.SDT = row["SoDienThoai"].ToString();
            this.Tenkhachhang = row["TenKhachHang"].ToString();
        }
    }
}
