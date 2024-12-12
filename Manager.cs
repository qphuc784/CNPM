using CNPM.DAO;
using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

            LoadListLoaiDV();
            cb_Manager_HDDV_ServiceType.SelectedIndexChanged += cb_Manager_HDDV_ServiceType_SelectedIndexChanged;
            cb_Manager_HDDV_TrangThai.SelectedIndexChanged += cb_Manager_HDDV_ServiceName_SelectedIndexChanged;
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
///////////////////////////////////////////////////////////////////////////////////////
// HÓA ĐƠN BÁN HÀNG //
// Thông tin chung //
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

// Thông tin sản phẩm 
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
            tb_Manager_HDban_IdProduct.Text = "";
            tb_Manager_HDban_Donvitinh.Text = "";
            tb_Manager_HDban_UnitPrice.Text = "";

            if (cb_Manager_HDban_ProductType.SelectedIndex != -1)
            {
                // Lấy ID loại sản phẩm được chọn
                object selectedLoaiSPID = cb_Manager_HDban_ProductType.SelectedValue;
                if (selectedLoaiSPID != null && int.TryParse(selectedLoaiSPID.ToString(), out int selectedIDSanPham))
                {
                    LoadTenSPToComboBox(selectedIDSanPham);

                    List<string> donViTinhs = LoaiSanPhamDAO.Instance.GetDVTByIDLoai(selectedIDSanPham);
                    if (donViTinhs != null && donViTinhs.Count > 0)
                    {
                        // Nối các đơn vị tính thành một chuỗi, ngăn cách bằng dấu phẩy
                        tb_Manager_HDban_Donvitinh.Text = string.Join(", ", donViTinhs);
                    }
                    else
                    {
                        tb_Manager_HDban_Donvitinh.Text = " ";
                    }

                    List<string> dongiaban = LoaiSanPhamDAO.Instance.GetDonGiaBan(selectedIDSanPham);
                    if (dongiaban != null && dongiaban.Count > 0)
                    {
                        // Nối các đơn vị tính thành một chuỗi, ngăn cách bằng dấu phẩy
                        tb_Manager_HDban_UnitPrice.Text = string.Join(", ", dongiaban);
                    }
                    else
                    {
                        tb_Manager_HDban_UnitPrice.Text = " ";
                    }

                }
                else
                {
                    LoadTenSPToComboBox(0);
                    tb_Manager_HDban_Donvitinh.Text = "";
                    tb_Manager_HDban_UnitPrice.Text = "";
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

        private void txb_Manager_HDban_Quantity_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị đơn giá bán
            if (decimal.TryParse(tb_Manager_HDban_UnitPrice.Text, out decimal donGiaBan) &&
                int.TryParse(txb_Manager_HDban_Quantity.Text, out int soLuong)) 
            {
                decimal tongTien = (donGiaBan * soLuong);

                tb_Manager_HDban_Cash.Text = tongTien.ToString("N2"); 
            }
            else
            {
                tb_Manager_HDban_Cash.Text = "0";
            }
        }

        private void btn_Manager_HDban_AddProductbill_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox hoặc ComboBox
            string maSP = tb_Manager_HDban_IdProduct.Text;
            string loaiSP = cb_Manager_HDban_ProductType.Text;
            string tenSP = cb_Manager_HDban_ProductName.Text;
            string donViTinh = tb_Manager_HDban_Donvitinh.Text;
            int soLuong = 0;
            decimal donGia = 0;
            decimal giamGia = 0; 

            // Chuyển đổi số lượng và đơn giá
            if (!int.TryParse(txb_Manager_HDban_Quantity.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tb_Manager_HDban_UnitPrice.Text, out donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txb_Manager_HDban_GiamGia.Text, out giamGia) || giamGia <= 0)
            {
                MessageBox.Show("Giảm giá phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //var giamgia = Decimal.Parse(giamGia, NumberStyles.AllowThousands| NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol);


            // Tính thành tiền
            decimal thanhTien = (donGia * soLuong) * (1 - giamGia/100);

            // Thêm thông tin vào ListView
            ListViewItem item = new ListViewItem(maSP);
            item.SubItems.Add(loaiSP);
            item.SubItems.Add(tenSP);
            item.SubItems.Add(soLuong.ToString());
            item.SubItems.Add(donViTinh);
            item.SubItems.Add(donGia.ToString("N2")); // Định dạng số thập phân
            item.SubItems.Add(giamGia.ToString()); // Giảm giá
            item.SubItems.Add(thanhTien.ToString("N2")); // Thành tiền

            lsv_Manager_HDban.Items.Add(item);

            // Sau khi thêm, reset các ô nhập liệu
            tb_Manager_HDban_IdProduct.Text = string.Empty;
            cb_Manager_HDban_ProductType.SelectedIndex = -1;
            cb_Manager_HDban_ProductName.DataSource = null;
            txb_Manager_HDban_Quantity.Text = string.Empty;
            tb_Manager_HDban_Donvitinh.Text = string.Empty;
            tb_Manager_HDban_UnitPrice.Text = string.Empty;
            txb_Manager_HDban_GiamGia.Text = string.Empty;
            tb_Manager_HDban_Cash.Text = "0";

            CalculateTotal();
        }
        private void CalculateTotal()
        {
            decimal total = 0;

            // Duyệt qua các dòng trong ListView
            foreach (ListViewItem item in lsv_Manager_HDban.Items)
            {
                // Lấy giá trị cột "Thành tiền" (giả sử cột này nằm ở vị trí thứ 7, index = 6)
                if (decimal.TryParse(item.SubItems[7].Text, out decimal thanhTien))
                {
                    total += thanhTien;
                }
            }

            // Hiển thị tổng tiền trong TextBox
            tb_Manager_HDban_Total.Text = total.ToString("N2"); // Định dạng số thập phân
        }

///////////////////////////////////////////////////////////////////////////////////////
// HÓA ĐƠN DỊCH VỤ //
// Thông tin chung //

        //Hiển thị khách hàng 
        private void btn_Manager_HDDV_ShowGuest_Click(object sender, EventArgs e)
        {
            string sdt = tb_Manager_HDDV_GuestPN.Text;
            if (string.IsNullOrWhiteSpace(tb_Manager_HDDV_GuestPN.Text))
            {
                MessageBox.Show("Nhap so dien thoai khach hang");
                return;
            }
            KhachHang f = KhachHangDAO.Instance.GetKhachHangBySdt(sdt);
            if (f != null)
            {
                tb_Manager_HDDV_IDGuest.Text = f.ID.ToString();
                tb_Manager_HDDV_GuestName.Text = f.Tenkhachhang;
            }
            else
            {
                MessageBox.Show("Khach hang khong ton tai");
            }

        }

        private void LoadListLoaiDV()
        {
            List<LoaiDichVu> listLoaiDichVu = LoaiDichVuDAO.Instance.GetListLoaiDV();

            if (listLoaiDichVu != null && listLoaiDichVu.Count > 0)
            {
                cb_Manager_HDDV_ServiceType.DataSource = listLoaiDichVu;
                cb_Manager_HDDV_ServiceType.DisplayMember = "TenLoai";  
                cb_Manager_HDDV_ServiceType.ValueMember = "ID";    
                cb_Manager_HDDV_ServiceType.SelectedIndex = -1;    
            }
            else
            {
                cb_Manager_HDDV_ServiceType.DataSource = null;
            }
        }
        private void cb_Manager_HDDV_ServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Manager_HDDV_TrangThai.DataSource = null;
            tb_Manager_HDDV_IdService.Text = "";
            tb_Manager_HDDV_UnitPrice.Text = "";

            if (cb_Manager_HDDV_ServiceType.SelectedIndex != -1)
            {
                object selectedLoaiDVID = cb_Manager_HDDV_ServiceType.SelectedValue;
                if (selectedLoaiDVID != null && int.TryParse(selectedLoaiDVID.ToString(), out int selectedIDDichVu))
                {
                    LoadTenDVToComboBox(selectedIDDichVu);

                    List<string> dongiadichvu = LoaiDichVuDAO.Instance.GetDonGiaDichVu(selectedIDDichVu);
                    if (dongiadichvu != null && dongiadichvu.Count > 0)
                    {
                        tb_Manager_HDDV_UnitPrice.Text = string.Join(", ", dongiadichvu);
                    }
                    else
                    {
                        tb_Manager_HDDV_UnitPrice.Text = " ";
                    }

                }
                else
                {
                    LoadTenDVToComboBox(0);
                    tb_Manager_HDDV_UnitPrice.Text = "";
                }
            }
        }

        private void LoadTenDVToComboBox(int selectedLoaiDVID)
        {
            // Lấy danh sách sản phẩm theo loại sản phẩm từ DAO
            List<PhieuDichVu> listDichVu = DichVuDAO.Instance.GetDichVuByIDLoai(selectedLoaiDVID);

            if (listDichVu != null && listDichVu.Count > 0)
            {
                // Gán danh sách sản phẩm vào ComboBox tên sản phẩm
                cb_Manager_HDDV_TrangThai.DataSource = listDichVu;
                cb_Manager_HDDV_TrangThai.DisplayMember = "TinhTrang"; // Hiển thị tên sản phẩm
                cb_Manager_HDDV_TrangThai.ValueMember = "ID";           // Lưu trữ ID sản phẩm
                cb_Manager_HDDV_TrangThai.SelectedIndex = -1;           // Đặt mục ban đầu là trống
            }
            else
            {
                cb_Manager_HDDV_TrangThai.DataSource = null; // Không hiển thị gì nếu không có sản phẩm
                tb_Manager_HDDV_IdService.Text = "";
            }
        }
        private void cb_Manager_HDDV_ServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Manager_HDDV_TrangThai.SelectedIndex != -1)
            {
                // Lấy ID sản phẩm được chọn
                object selectedValue = cb_Manager_HDDV_TrangThai.SelectedValue;

                if (selectedValue != null && int.TryParse(selectedValue.ToString(), out int selectedIDDichVu))
                {
                    tb_Manager_HDDV_IdService.Text = selectedIDDichVu.ToString();
                }
                else
                {
                    tb_Manager_HDDV_IdService.Text = ""; // Xóa thông tin nếu không thể chuyển đổi
                }
            }
            else
            {
                tb_Manager_HDDV_IdService.Text = ""; // Xóa thông tin nếu không có sản phẩm được chọn
            }
        }
    }
}
