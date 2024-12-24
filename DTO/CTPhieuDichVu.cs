using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class CTPhieuDichVu
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int idphieudichvu;
        public int IDPhieuDichVu { get => idphieudichvu; set => idphieudichvu = value; }

        private int iddichvu;
        public int IDDichVu { get => iddichvu; set => iddichvu = value; }

        private bool tinhtrang; 
        public bool TinhTrang { get => tinhtrang; set => tinhtrang = value; }

        public CTPhieuDichVu(int id, int idphieudichvu, bool tinhtrang)
        {
            this.ID = id;
            this.IDPhieuDichVu = idphieudichvu;
            this.IDDichVu = iddichvu;
            this.TinhTrang = tinhtrang;
        }

        public CTPhieuDichVu(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDPhieuDichVu = (int)row["IDHoaDonDichVu"];
            this.IDDichVu = (int)row["IDDichVu"];
            this.tinhtrang = (bool)row["TinhTrang"];
        }
    }
}
