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
            // Lấy danh sách loại sản phẩm từ DAO
            List<LoaiSP> listLoaiSP = ProductDAO.Instance.GetListSanPham();

            if (listLoaiSP != null && listLoaiSP.Count > 0)
            {
                // Gán danh sách vào ComboBox loại sản phẩm
                cb_Manager_HDban_ProductType.DataSource = listLoaiSP;
                cb_Manager_HDban_ProductType.DisplayMember = "Ten";  // Hiển thị tên loại sản phẩm
                cb_Manager_HDban_ProductType.ValueMember = "ID";     // Lưu trữ ID loại sản phẩm
                cb_Manager_HDban_ProductType.SelectedIndex = -1;     // Đặt mục ban đầu là trống
            }
            else
            {
                cb_Manager_HDban_ProductType.DataSource = null; // Không hiển thị gì nếu không có loại sản phẩm
            }
        }

        private void cb_Manager_HDban_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xóa danh sách sản phẩm trước đó
            cb_Manager_HDban_ProductName.DataSource = null;
            tb_Manager_HDban_IdProduct.Text = ""; // Xóa thông tin mã sản phẩm

            if (cb_Manager_HDban_ProductType.SelectedIndex != -1)
            {
                // Lấy ID loại sản phẩm được chọn
                object selectedLoaiSPID = cb_Manager_HDban_ProductType.SelectedValue;
                if (selectedLoaiSPID != null && int.TryParse(selectedLoaiSPID.ToString(), out int selectedIDSanPham))
                {
                    LoadTenSPToComboBox(selectedIDSanPham);
                }
                else
                {
                    LoadTenSPToComboBox('0');
                }
            }
        }

        private void LoadTenSPToComboBox(int selectedLoaiSPID)
        {
            // Lấy danh sách sản phẩm theo loại sản phẩm từ DAO
            List<SanPham> listSanPham = ProductDAO.Instance.GetSanPhamByIDLoai(selectedLoaiSPID);

            if (listSanPham != null && listSanPham.Count > 0)
            {
                // Gán danh sách sản phẩm vào ComboBox tên sản phẩm
                cb_Manager_HDban_ProductName.DataSource = listSanPham;
                cb_Manager_HDban_ProductName.DisplayMember = "TenSanPham"; // Hiển thị tên sản phẩm
                cb_Manager_HDban_ProductName.ValueMember = "ID";           // Lưu trữ ID sản phẩm
                cb_Manager_HDban_ProductName.SelectedIndex = -1;           // Đặt mục ban đầu là trống
            }
            else
            {
                cb_Manager_HDban_ProductName.DataSource = null; // Không hiển thị gì nếu không có sản phẩm
                tb_Manager_HDban_IdProduct.Text = "";
            }
        }


        private void cb_Manager_HDban_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Manager_HDban_ProductName.SelectedIndex != -1)
            {
                // Lấy ID sản phẩm được chọn
                object selectedValue = cb_Manager_HDban_ProductName.SelectedValue;

                if (selectedValue != null && int.TryParse(selectedValue.ToString(), out int selectedIDSanPham))
                {
                    tb_Manager_HDban_IdProduct.Text = selectedIDSanPham.ToString();
                }
                else
                {
                    tb_Manager_HDban_IdProduct.Text = ""; // Xóa thông tin nếu không thể chuyển đổi
                }
            }
            else
            {
                tb_Manager_HDban_IdProduct.Text = ""; // Xóa thông tin nếu không có sản phẩm được chọn
            }
        }





    }
}
