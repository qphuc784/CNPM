using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;
using Guna.UI.WinForms;
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
    public partial class Manager : Form
    {
        private NhanVien loginNhanVien;
        public NhanVien LoginNhanVien
        {
            get => loginNhanVien;
            set { loginNhanVien = value; changeAccount(loginNhanVien.ChucVu); }
        }

        public Manager(NhanVien loginnv)
        {
            InitializeComponent();
            this.LoginNhanVien = loginnv;

            LoadListLoaiSP();
            cb_Manager_HDban_ProductType.SelectedIndexChanged += cb_Manager_HDban_ProductType_SelectedIndexChanged;
            cb_Manager_HDban_ProductName.SelectedIndexChanged += cb_Manager_HDban_ProductName_SelectedIndexChanged;
        }

        void changeAccount(string cv)
        {
            adminToolStripMenuItem.Enabled = (cv == "admin") ? true : false;
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            tb_Manager_HDban_IdProductBill.Text = "Phuc";
            tb_Manager_HDban_IdStaff.Text = loginNhanVien.ID.ToString();
            tb_Manager_HDban_StaffName.Text = loginNhanVien.TenNhanVien;
            tb_Manager_HDDV_IdStaff.Text = loginNhanVien.ID.ToString();
            tb_Manager_HDDV_StaffName.Text = loginNhanVien.TenNhanVien;
            tb_Manager_HDmua_IdStaff.Text = loginNhanVien.ID.ToString();
            tb_Manager_HDmua_StaffName.Text = loginNhanVien.TenNhanVien;

        }

        // Hiển thị form admin
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Interface newitf = new Interface();
            newitf.ShowDialog();
            this.Show();
        }
        // Hiển thị form thông tin cá nhân
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinTaiKhoan TTKT = new ThongTinTaiKhoan();
            TTKT.ShowDialog();
            this.Show();
        }
        // Cảnh báo đăng xuất
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Thật Sự Muốn Thoát Khỏi Ứng Dụng?", "Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
        //Hiển thị form báo cáo tồn kho
        private void báoCáoTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoTonKho bc = new BaoCaoTonKho();
            this.Hide();
            bc.ShowDialog();
            this.Show();
        }
        //Hiển thị form tim kiếm hóa đơn 
        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemHoaDon hd = new TimKiemHoaDon();
            this.Hide();
            hd.ShowDialog();
            this.Show();
        }

        // Hiển thị form add khách hàng 
        private void btn_Manager_HDban_AddGuest_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.ShowDialog();
        }
        private void btn_Manager_HDDV_AddGuest_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.ShowDialog();
        }


        // Hiển thị khách hàng theo sdt
        private void btn_Manager_HDban_ShowGuest_Click(object sender, EventArgs e)
        {
            string sdt = tb_Manager_HDban_GuestPN.Text;
            if (string.IsNullOrWhiteSpace(tb_Manager_HDban_GuestPN.Text))
            {
                MessageBox.Show("Nhap so dien thoai khach hang");
                return;
            }
            KhachHang f = KhachHangDAO.Instance.GetKhachHangBySdt(sdt);
            if (f != null)
            {
                tb_Manager_HDban_IDGuest.Text = f.ID.ToString();
                tb_Manager_HDban_GuestName.Text = f.Tenkhachhang;
            }
            else
            {
                MessageBox.Show("Khach hang khong ton tai");
            }

        }     
        private void tb_Manager_HDban_IdProduct_TextChanged(object sender, EventArgs e)
        {


        }

        private void LoadListLoaiSP()
        {
            List<string> listTenLoai = LoaiSanPhamDAO.Instance.GetListLoaiSanPham();
            //listTenLoai.Insert(0, ""); // Thêm mục trống vào đầu danh sách
            cb_Manager_HDban_ProductType.DataSource = listTenLoai;
            cb_Manager_HDban_ProductType.DisplayMember = "Ten";
            cb_Manager_HDban_ProductType.SelectedIndex = -1; // Đặt mục ban đầu là trống
        }

        private void cb_Manager_HDban_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GunaComboBox cbbox = sender as GunaComboBox;

            if (cbbox != null && cbbox.SelectedItem != null)
            {
                string selectedTenLoai = cbbox.SelectedItem.ToString();
                LoadTenSPToComboBox(selectedTenLoai);
            }
        }
        private void LoadTenSPToComboBox(string selectedLoaiSP)
        {
            // Lấy danh sách sản phẩm theo loại sản phẩm đã chọn
            List<string> listTenSP = ProductDAO.Instance.GetTenSanPhamByLoai(selectedLoaiSP);

            // Cập nhật dữ liệu cho ComboBox
            cb_Manager_HDban_ProductName.DataSource = listTenSP;
            cb_Manager_HDban_ProductName.DisplayMember = "TenSanPham";
            cb_Manager_HDban_ProductName.SelectedIndex = -1; // Đặt mục ban đầu là trống
        }


        private void cb_Manager_HDban_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy ComboBox từ sender
            GunaComboBox cbbox = sender as GunaComboBox;

            if (cbbox != null && cbbox.SelectedItem != null)
            {
                // Lấy IDLoai đã chọn từ ComboBox
                int selectedIDLoai = (int)cbbox.SelectedItem; // Chuyển đổi sang int

            }
        }

    }
}
