using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class CTPhieuBanHang
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int iDPhieuBanHang;
        public int IDPhieuBanHang { get => iDPhieuBanHang; set => iDPhieuBanHang = value; }

        private int idsanpham;
        public int IDSanPham { get => idsanpham; set => idsanpham = value; }

        private int soluong;
        public int SoLuong { get => soluong; set => soluong = value; }

        public CTPhieuBanHang(int id, int idphieubanhang, int idsp, int soluong)
        {
            this.ID = id;
            this.IDPhieuBanHang = idphieubanhang;
            this.IDSanPham = idsp;
            this.SoLuong = soluong;
        }

        public CTPhieuBanHang(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDPhieuBanHang = (int)row["IDPhieuBanHang"];
            this.IDSanPham = (int)row["IDSanPham"];
            this.SoLuong = (int)row["SoLuong"];
        }
    }
}
