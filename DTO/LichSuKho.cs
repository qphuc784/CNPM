using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class LichSuKho
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int idsanpham;
        public int IDSanPham { get => idsanpham; set => idsanpham = value; }

        private int sl_truoc;
        public int SL_Truoc { get => sl_truoc; set => sl_truoc = value; }

        private string loai_gd;
        public string Loai_GD { get => loai_gd; set => loai_gd = value; }

        private DateTime ngay;
        public DateTime Ngay { get => ngay; set => ngay = value; }

        private int sl_sau;
        public int SL_Sau { get => sl_sau; set => sl_sau = value; }

        public LichSuKho(int id, int idsanpham, int sl_truoc, string loai_gd, DateTime ngay, int sl_sau)
        {
            this.ID = id;
            this.IDSanPham = idsanpham;
            this.SL_Truoc = sl_truoc;
            this.Loai_GD = loai_gd;
            this.Ngay = ngay;
            this.SL_Sau = sl_sau;
        }
    }
}
