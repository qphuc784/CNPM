using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class LoaiSP
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private string ten;
        public string Ten { get => ten; set => ten = value; }

        private string dvt;
        public string DVT { get => dvt; set => dvt = value; }


        public LoaiSP(int id, string ten, int loinhuan, string dvt)
        {
            this.ID = id;
            this.Ten = ten;
            this.DVT = dvt;
        }

        public LoaiSP(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Ten = row["Ten"].ToString();
            this.DVT = row["DonViTinh"].ToString();
        }
    }
}
