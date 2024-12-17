using CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM
{
    public partial class AddService : Form
    {
        public AddService()
        {
            InitializeComponent();
        }

        private void Button_AddService_Ok_Click(object sender, EventArgs e)
        {
            string TenLoai = TextBox_AddService_Ten_loai_dich_vu.Text;
            string DonGiaText = TextBox_AddService_Don_gia.Text;
            float DonGia = Convert.ToSingle(DonGiaText);
            if (string.IsNullOrEmpty(TenLoai) || string.IsNullOrEmpty(DonGiaText))
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin!");
                return;
            }
            if (checkTenLoaiDV(TenLoai))
            {
                MessageBox.Show("Dịch Vụ Này Đã Tồn Tại! Vui Lòng Thử Lại");
                return;
            }
            if (add_service(TenLoai, DonGia))
            {
                MessageBox.Show("Thêm Dịch Vụ Thành Công!");
                this.Close();
            }

        }
        bool add_service(string TenLoai, float DonGia)
        {

            return DichVuDAO.Instance.Add_Service(TenLoai, DonGia);
        }
        
        bool checkTenLoaiDV(string TenLoai)
        {
            return DichVuDAO.Instance.checkTenLoaiDV(TenLoai);
        }

        private void Button_AddService_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

