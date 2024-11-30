using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class SanPham
    {
        private int iD;
        public int ID
        { get => iD; set => iD = value; }

        private string tensanpham;
        public string TenSanPham
        { get => tensanpham; set => tensanpham = value; }

        private int idloai;
        public int IDLoai
        { get => idloai; set => idloai = value; }

        private int soluong;
        public int SoLuong
        { get => soluong; set => soluong = value; }

        private Boolean trangthai;
        public Boolean TrangThai
        { get => trangthai; set => trangthai = value; }

        private DateTime ngaythaydoisl;
        public DateTime NgayThayDoiSL
        { get => ngaythaydoisl; set => ngaythaydoisl = value; }

        private int sl_truoc;
        public int Sl_Truoc
        { get => sl_truoc; set => sl_truoc = value; }

        public SanPham(int id, string tensanpham, int idloai, int soluong, Boolean trangthai, DateTime ngaythaydoisl, int sltruoc)
        {
            this.ID = id;
            this.TenSanPham = tensanpham;
            this.IDLoai = idloai;
            this.SoLuong = soluong;
            this.TrangThai = trangthai;
            this.NgayThayDoiSL = ngaythaydoisl;
            this.Sl_Truoc = sltruoc;
        }
        public SanPham(DataRow row)
        {
            this.ID = (int)row["id"];
            this.TenSanPham = row["tensanpham"].ToString();
            this.IDLoai = (int)row["idloai"];
            this.SoLuong = (int)row["soluong"];
            this.TrangThai = (bool)row["trangthai"];
            this.NgayThayDoiSL = (DateTime)row["NgayThayDoiSoLuong"];
            this.Sl_Truoc = (int)row["SoLuongTruoc"];
        }
    }
}