using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM.DTO
{
    public class GoodReceipt
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private string tensanpham;
        public string TenSanPham { get => tensanpham; set => tensanpham = value; }

        private int soluong;
        public int SoLuong { get => soluong; set => soluong = value; }

        private float dongia;
        public float DonGia { get => dongia; set => dongia = value; }

        private string sodienthoai;
        public string SoDienThoai { get => sodienthoai; set => sodienthoai = value; }

        private DateTime ngaymua;
        public DateTime NgayMua { get => ngaymua; set => ngaymua = value; }

        public GoodReceipt(int iD, string tensanpham, int soluong, float dongia, string sodienthoai, DateTime ngaymua)
        {
            this.ID = iD;
            this.TenSanPham = tensanpham;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.SoDienThoai = sodienthoai;
            this.NgayMua = ngaymua;
        }
        public GoodReceipt(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.TenSanPham = row["TenSanPham"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.DonGia = Convert.ToSingle(row["DonGia"]);
            this.SoDienThoai = row["sodienthoai"].ToString();
            this.NgayMua = (DateTime)row["NgayMua"];
        }
    }

}
