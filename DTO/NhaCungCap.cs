using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class NhaCungCap
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private string sdt;
        public string Sdt { get => sdt; set => sdt = value; }

        private string diachi;
        public string DiaChi { get => diachi; set => diachi = value; }

        public NhaCungCap(int iD, string sdt, string diachi)
        {
            this.ID = iD;
            this.Sdt = sdt;
            this.DiaChi = diachi;
        }
    }
}
