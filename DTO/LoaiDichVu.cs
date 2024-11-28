using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class LoaiDichVu
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private string tenloai;
        public string TenLoai { get => tenloai; set => tenloai = value; }

        private float dongia;
        public float DonGia { get => dongia; set => dongia = value; }

        public LoaiDichVu(int id, string tenloai, float dongia)
        {
            this.ID = id;
            this.TenLoai = tenloai;
            this.DonGia = dongia;
        }
    }
}
