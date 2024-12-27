using System;
using System.Data;

namespace CNPM.DTO
{
    public class BaoCaoTonKhodto
    {
        private int idsanpham;
        public int IDSanPham
        { get => idsanpham; set => idsanpham = value; }


        private string tensanpham;
        public string TenSanPham
        { get => tensanpham; set => tensanpham = value; }

        private int tondau;
        public int TonDau
        { get => tondau; set => tondau = value; }

        private int sl_mua;
        public int SL_Mua
        { get => sl_mua; set => sl_mua = value; }

        private int sl_ban;
        public int SL_Ban
        { get => sl_ban; set => sl_ban = value; }

        private int toncuoi;
        public int TonCuoi
        { get => toncuoi; set => toncuoi = value; }

        private string dvt;
        public string DVT { get => dvt; set => dvt = value; }

        public BaoCaoTonKhodto(int iD, string tensanpham, int tondau, int sl_mua, int sl_ban, int toncuoi, string dvt)
        {
            this.IDSanPham = idsanpham;

            this.TenSanPham = tensanpham;
            this.TonDau = tondau;
            this.SL_Mua = sl_mua;
            this.SL_Ban = sl_ban;
            this.TonCuoi = toncuoi;
            this.DVT = dvt;
        }
        public BaoCaoTonKhodto(DataRow row)
        {
            this.IDSanPham = (int)row["IDSanPham"];
            this.TenSanPham = row["TenSanPham"].ToString();
            this.TonDau = (int)row["TonDau"];
            this.SL_Ban = (int)row["SL_Ban"];  // Kiểm tra null và giá trị mặc định
            this.SL_Mua = (int)row["SL_Mua"];
            this.TonCuoi = (int)row["TonCuoi"];
            this.DVT = row["DonViTinh"].ToString();
        }


    }
}
