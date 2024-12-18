using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CNPM
{
    public partial class ThongTinTaiKhoan : Form
    {
        private NhanVien thongtinNhanVien;
        public NhanVien ThongTinNhanVien
        {
            get => thongtinNhanVien;
            set { thongtinNhanVien = value; }
        }

        public ThongTinTaiKhoan(NhanVien nv)
        {
            InitializeComponent();
            this.ThongTinNhanVien = nv;
        }

        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            TextBox_ThongTinTK_ID.Text = thongtinNhanVien.ID.ToString();
            TextBox_ThongTinTK_Username.Text = thongtinNhanVien.TaiKhoan.ToString();
            TextBox_ThongTinTK_Ten.Text = thongtinNhanVien.TenNhanVien.ToString();
            TextBox_ThongTinTK_SDT.Text = thongtinNhanVien.ChucVu.ToString();  
            TextBox_ThongTinTK_Email.Text = thongtinNhanVien.Email.ToString();
        }

    private void Button_ThongTinTK_DoiMK_Click(object sender, EventArgs e)
        {
            string username = TextBox_ThongTinTK_Username.Text;
            NhanVien mk = NhanVienDAO.Instance.GetNhanVienByUserName(username);
            DoiMatKhau f = new DoiMatKhau(mk);
            f.ShowDialog();
        }
    }
}
