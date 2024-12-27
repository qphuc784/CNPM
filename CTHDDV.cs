using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;

namespace CNPM
{
    public partial class CTHDDV : Form
    {
        private PhieuDichVu pdv;

        public PhieuDichVu Pdv { get => pdv; set => pdv = value; }


        public CTHDDV(PhieuDichVu pdv)
        {
            this.Pdv = pdv;
            InitializeComponent();
            LoadListview();
        }

        private void CTHDDV_Load(object sender, EventArgs e)
        {
            //LoadListview();
        }

        private void LoadListview()
        {
            
            List<CTPhieuDichVu> ctPDVs = CTHoaDonDichVuDAO.Instance.GetListCTPDVByIDKhachHang(pdv.ID);
            if(ctPDVs.Count >0)
            {
                dataGridView_CTHDDV.DataSource = ctPDVs;

                dataGridView_CTHDDV.Columns["ID"].HeaderText = "ID";
                dataGridView_CTHDDV.Columns["IDPhieuDichVu"].HeaderText = "Mã Phiếu Đơn Dịch VỤ";
                dataGridView_CTHDDV.Columns["IDDichVu"].HeaderText = "Mã Dịch Vụ";
                dataGridView_CTHDDV.Columns["TinhTrang"].HeaderText = "Tình Trạng";
                dataGridView_CTHDDV.Columns["SoLuong"].HeaderText = "Số Lượng";

            }

            else
            {
                MessageBox.Show("Không Tìm Thấy Hóa Dơn! Vui Lòng Thử Lại");
            } 
                
        }

        private void Button_CTHDDV_XacNhan_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_CTHDDV.Rows) {
                bool tinhTrang = Convert.ToBoolean(row.Cells["TinhTrang"].Value);
                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                bool isupdate = CTHoaDonDichVuDAO.Instance.UpdateTrangThai(tinhTrang, ID);
                if (isupdate)
                {
                    MessageBox.Show("Đã Hoàn Thành!");
                }
                else
                {
                    MessageBox.Show("Vui Lòng Thử Lại!");
                    return;
                }

            }
        }
    }
}
