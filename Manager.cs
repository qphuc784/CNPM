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

            LoadListLoaiSP_mua();
            cb_Manager_HDmua_ProductType.SelectedIndexChanged += cb_Manager_HDmua_ProductType_SelectedIndexChanged;
            cb_Manager_HDmua_ProductName.SelectedIndexChanged += cb_Manager_HDmua_ProductName_SelectedIndexChanged;
        }

        void changeAccount(string cv)
        {
            adminToolStripMenuItem.Enabled = (cv == "admin") ? true : false;
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            UpdateIDBIll();
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
            string staff_id = tb_Manager_HDban_IdStaff.Text;
            NhanVien nv = NhanVienDAO.Instance.GetNhanVienByID(staff_id);
            ThongTinTaiKhoan f = new ThongTinTaiKhoan(nv);
            this.Hide();
            f.ShowDialog();
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
        private void btn_Manager_HDmua_AddGuest_Click(object sender, EventArgs e)
        {
            AddNewSupplier addNewSupplier = new AddNewSupplier();
            addNewSupplier.ShowDialog();
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
                cb_Manager_HDban_ProductType.DisplayMember = "Ten";  
                cb_Manager_HDban_ProductType.ValueMember = "ID";    
                cb_Manager_HDban_ProductType.SelectedIndex = -1;    
            }
            else
            {
                cb_Manager_HDban_ProductType.DataSource = null; 
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
                        tb_Manager_HDban_Donvitinh.Text = string.Join(", ", donViTinhs);
                    }
                    else
                    {
                        tb_Manager_HDban_Donvitinh.Text = " ";
                    }

                    List<string> dongiaban = LoaiSanPhamDAO.Instance.GetDonGiaBan(selectedIDSanPham);
                    if (dongiaban != null && dongiaban.Count > 0)
                    {
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
            List<SanPham> listSanPham = ProductDAO.Instance.GetSanPhamByIDLoai(selectedLoaiSPID);

            if (listSanPham != null && listSanPham.Count > 0)
            {
                cb_Manager_HDban_ProductName.DataSource = listSanPham;
                cb_Manager_HDban_ProductName.DisplayMember = "TenSanPham";
                cb_Manager_HDban_ProductName.ValueMember = "ID";      
                cb_Manager_HDban_ProductName.SelectedIndex = -1;  
            }
            else
            {
                cb_Manager_HDban_ProductName.DataSource = null; 
                tb_Manager_HDban_IdProduct.Text = "";
            }
        }

        private void cb_Manager_HDban_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Manager_HDban_ProductName.SelectedIndex != -1)
            {
                object selectedValue = cb_Manager_HDban_ProductName.SelectedValue;

                if (selectedValue != null && int.TryParse(selectedValue.ToString(), out int selectedIDSanPham))
                {
                    tb_Manager_HDban_IdProduct.Text = selectedIDSanPham.ToString();
                }
                else
                {
                    tb_Manager_HDban_IdProduct.Text = ""; 
                }
            }
            else
            {
                tb_Manager_HDban_IdProduct.Text = ""; 
            }
        }

        private void txb_Manager_HDban_Quantity_TextChanged(object sender, EventArgs e)
        {
            string id = tb_Manager_HDban_IdProduct.Text.ToString();
            int soLuongConLai = ProductDAO.Instance.GetSoLuongByID(id);

            if (decimal.TryParse(tb_Manager_HDban_UnitPrice.Text, out decimal donGiaBan) &&
                int.TryParse(txb_Manager_HDban_Quantity.Text, out int soLuong))
            {
                if (soLuong >= soLuongConLai)
                {
                    txb_Manager_HDban_Quantity.Text = soLuongConLai.ToString();
                    decimal tongTien = (donGiaBan * soLuongConLai);
                    tb_Manager_HDban_Cash.Text = tongTien.ToString("N2");
                } else
                {
                    decimal tongTien = (donGiaBan * soLuong);
                    tb_Manager_HDban_Cash.Text = tongTien.ToString("N2");
                }
            }
            else
            {
                tb_Manager_HDban_Cash.Text = "0";
            }
        }

        private void btn_Manager_HDban_AddProductbill_Click(object sender, EventArgs e)
        {
            string maSP = tb_Manager_HDban_IdProduct.Text;
            string loaiSP = cb_Manager_HDban_ProductType.Text;
            string tenSP = cb_Manager_HDban_ProductName.Text;
            string donViTinh = tb_Manager_HDban_Donvitinh.Text;
            int soLuong = 0;
            decimal donGia = 0;

            if (!int.TryParse(txb_Manager_HDban_Quantity.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tb_Manager_HDban_UnitPrice.Text, out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal thanhTien = (donGia * soLuong);

            ListViewItem item = new ListViewItem(maSP);
            item.SubItems.Add(loaiSP);
            item.SubItems.Add(tenSP);
            item.SubItems.Add(soLuong.ToString());
            item.SubItems.Add(donViTinh);
            item.SubItems.Add(donGia.ToString()); 
            item.SubItems.Add(thanhTien.ToString()); 

            lsv_Manager_HDban.Items.Add(item);

            tb_Manager_HDban_IdProduct.Text = string.Empty;
            cb_Manager_HDban_ProductType.SelectedIndex = -1;
            cb_Manager_HDban_ProductName.DataSource = null;
            txb_Manager_HDban_Quantity.Text = string.Empty;
            tb_Manager_HDban_Donvitinh.Text = string.Empty;
            tb_Manager_HDban_UnitPrice.Text = string.Empty;
            tb_Manager_HDban_Cash.Text = "0";

            CalculateTotal();
        }
        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (ListViewItem item in lsv_Manager_HDban.Items)
            {
                if (decimal.TryParse(item.SubItems[6].Text, out decimal thanhTien))
                {
                    total += thanhTien;
                }
            }

            tb_Manager_HDban_Total.Text = total.ToString();
        }
        private void btn_Manager_HDban_ThemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                string ngayban = DateTimePicker_Manager_HDban_date_time.Value.ToString("yyyy-MM-dd");

                if (!int.TryParse(tb_Manager_HDban_IdProductBill.Text, out int id))
                {
                    MessageBox.Show("ID khách hàng không hợp lệ.");
                    return;
                }
                if (!int.TryParse(tb_Manager_HDban_IDGuest.Text, out int idkhach))
                {
                    MessageBox.Show("ID khách hàng không hợp lệ.");
                    return;
                }

                if (!int.TryParse(tb_Manager_HDban_IdStaff.Text, out int idnv))
                {
                    MessageBox.Show("ID nhân viên không hợp lệ.");
                    return;
                }

                bool isInvoiceSaved = HoaDonDAO.Instance.AddHDBanHang(id, idkhach, idnv, ngayban);

                if (!isInvoiceSaved)
                {
                    MessageBox.Show("Thêm hóa đơn thất bại.");
                    return;
                }

                foreach (ListViewItem item in lsv_Manager_HDban.Items)
                {
                    if (!int.TryParse(item.SubItems[0].Text, out int idsp))
                    {
                        MessageBox.Show("Mã sản phẩm không hợp lệ.");
                        return;
                    }

                    if (!int.TryParse(item.SubItems[3].Text, out int soLuong))
                    {
                        MessageBox.Show("Số lượng sản phẩm không hợp lệ.");
                        return;
                    }

                    bool isDetailSaved = HoaDonDAO.Instance.AddCTHDBanHang(id, idsp, soLuong);

                    if (!isDetailSaved)
                    {
                        MessageBox.Show("Thêm chi tiết hóa đơn thất bại.");
                        return;
                    }
                }

                MessageBox.Show("Thêm hóa đơn thành công.");
                UpdateIDBIll();
                ResetFormAfterAddingBill();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
        private void ResetFormAfterAddingBill()
        {
            tb_Manager_HDban_Total.Text = "0";
            lsv_Manager_HDban.Items.Clear();
        }
        private void UpdateIDBIll()
        {
            tb_Manager_HDban_IdProductBill.Text = HoaDonDAO.Instance.GetIDHoaDon().ToString();
            tb_Manager_HDDV_IdProductBill.Text = HoaDonDichVuDAO.Instance.GetIDHoaDon().ToString();
            tb_Manager_HDmua_IdProductBill.Text = HoaDonMuaHangDAO.Instance.GetIDHoaDon().ToString();
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

        // Thông tin dịch vụ //
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
            tb_Manager_HDDV_IdService.Text = "";
            tb_Manager_HDDV_UnitPrice.Text = "";

            if (cb_Manager_HDDV_ServiceType.SelectedIndex != -1)
            {
                object selectedLoaiDVID = cb_Manager_HDDV_ServiceType.SelectedValue;
                if (selectedLoaiDVID != null && int.TryParse(selectedLoaiDVID.ToString(), out int selectedIDDichVu))
                {
                    tb_Manager_HDDV_IdService.Text = selectedIDDichVu.ToString();

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
                    tb_Manager_HDDV_UnitPrice.Text = "";
                }
            }
        }

        private void txb_Manager_HDDV_Quantity_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_Manager_HDDV_UnitPrice.Text, out decimal donGiaBan) &&
                int.TryParse(txb_Manager_HDDV_Quantity.Text, out int soLuong))
            {
                decimal tongTien = (donGiaBan * soLuong);

                tb_Manager_HDDV_Cash.Text = tongTien.ToString("N2");
            }
            else
            {
                tb_Manager_HDDV_Cash.Text = "0";
            }
        }
        private void btn_Manager_HDDV_AddServicebill_Click(object sender, EventArgs e)
        {
            string maDV = tb_Manager_HDDV_IdService.Text;
            string loaiDV = cb_Manager_HDDV_ServiceType.Text;
            int soLuong = 0;
            decimal donGia = 0;

            if (!int.TryParse(txb_Manager_HDDV_Quantity.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tb_Manager_HDDV_UnitPrice.Text, out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal thanhTien = (donGia * soLuong);

            ListViewItem item = new ListViewItem(maDV);
            item.SubItems.Add(loaiDV);
            item.SubItems.Add(soLuong.ToString());
            item.SubItems.Add(donGia.ToString("N2"));
            item.SubItems.Add(thanhTien.ToString("N2"));

            lsv_Manager_HDDV.Items.Add(item);

            tb_Manager_HDDV_IdService.Text = string.Empty;
            cb_Manager_HDDV_ServiceType.SelectedIndex = -1;
            txb_Manager_HDDV_Quantity.Text = string.Empty;
            tb_Manager_HDDV_UnitPrice.Text = string.Empty;
            tb_Manager_HDDV_Cash.Text = "0";

            CalculateTotal_DV();
        }
        private void CalculateTotal_DV()
        {
            decimal total = 0;

            foreach (ListViewItem item in lsv_Manager_HDDV.Items)
            {
                if (decimal.TryParse(item.SubItems[4].Text, out decimal thanhTien))
                {
                    total += thanhTien;
                }
            }

            txb_Manager_HDDV_TongTien.Text = total.ToString("N2");
        }

        private void txb_Manager_HDDV_TraTruoc_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txb_Manager_HDDV_TraTruoc.Text, out decimal traTruoc) &&
                decimal.TryParse(txb_Manager_HDDV_TongTien.Text, out decimal tongTien))
            {
                if (traTruoc < tongTien)
                {
                    decimal conLai = tongTien - traTruoc;
                    txb_Manager_HDDV_Conlai.Text = conLai.ToString("N2");
                }
                else
                {
                    decimal conLai = 0;
                    txb_Manager_HDDV_TraTruoc.Text = txb_Manager_HDDV_TongTien.Text;
                    txb_Manager_HDDV_Conlai.Text = conLai.ToString("N2");
                }
            }
            else
            {
                txb_Manager_HDDV_Conlai.Text = "0";
            }
        }
        private void btn_Manager_HDDV_ThemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                string ngayban = DateTimePicker_Manager_HDDV_date_time.Value.ToString("yyyy-MM-dd");

                if (!int.TryParse(tb_Manager_HDDV_IdProductBill.Text, out int id))
                {
                    MessageBox.Show("ID hóa đơn không hợp lệ.");
                    return;
                }

                if (!int.TryParse(tb_Manager_HDDV_IDGuest.Text, out int idkhach))
                {
                    MessageBox.Show("ID khách hàng không hợp lệ.");
                    return;
                }

                if (!int.TryParse(tb_Manager_HDDV_IdStaff.Text, out int idnv))
                {
                    MessageBox.Show("ID nhân viên không hợp lệ.");
                    return;
                }

                if (!int.TryParse(txb_Manager_HDDV_TraTruoc.Text, out int tratruoc))
                {
                    MessageBox.Show("Số tiền trả trước không hợp lệ.");
                    return;
                }

                bool isInvoiceSaved = HoaDonDichVuDAO.Instance.AddHDDichVu(id , idkhach, idnv, tratruoc, ngayban);

                if (!isInvoiceSaved)
                {   
                    MessageBox.Show("Thêm hóa đơn thất bại.");
                    return;
                }

                foreach (ListViewItem item in lsv_Manager_HDDV.Items)
                {
                    if (!int.TryParse(item.SubItems[0].Text, out int iddv))
                    {
                        MessageBox.Show("Mã dịch vụ không hợp lệ.");
                        return;
                    }

                    if (!int.TryParse(item.SubItems[2].Text, out int soLuong))
                    {
                        MessageBox.Show("Số lượng dịch vụ không hợp lệ.");
                        return;
                    }

                    bool isDetailSaved = HoaDonDichVuDAO.Instance.AddCTHDDichVu(id , iddv , soLuong);

                    if (!isDetailSaved)
                    {
                        MessageBox.Show("Thêm chi tiết hóa đơn thất bại.");
                        return;
                    }
                }

                MessageBox.Show("Thêm hóa đơn thành công.");
                UpdateIDBIll();
                ResetFormAfterAddingBill_Service();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void ResetFormAfterAddingBill_Service()
        {
            txb_Manager_HDDV_TongTien.Text = "0";
            txb_Manager_HDDV_TraTruoc.Text = "0";
            txb_Manager_HDDV_Conlai.Text = "0";
            lsv_Manager_HDDV.Items.Clear();
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        // HÓA ĐƠN MUA HÀNG //
        // Thông tin chung //
        //Hiển thị khách hàng 
        private void btn_Manager_HDmua_ShowNCC_Click(object sender, EventArgs e)
        {
            string sdt = tb_Manager_HDmua_GuestPN.Text;
            if (string.IsNullOrWhiteSpace(tb_Manager_HDmua_GuestPN.Text))
            {
                MessageBox.Show("Nhap so dien thoai nha cung cap");
                return;
            }
            NhaCungCap f = NhaCungCapDAO.Instance.GetNhaCungCapBySdt(sdt);
            if (f != null)
            {
                tb_Manager_HDmua_IDncc.Text = f.ID.ToString();
                tb_Manager_HDmua_DiaChi.Text = f.DiaChi;
            }
            else
            {
                MessageBox.Show("Nha cung cap khong ton tai");
            }
        }


// Thông tin sản phẩm //
        private void LoadListLoaiSP_mua()
        {
            List<LoaiSP> listLoaiSP = ProductDAO.Instance.GetListSanPham();

            if (listLoaiSP != null && listLoaiSP.Count > 0)
            {
                cb_Manager_HDmua_ProductType.DataSource = listLoaiSP;
                cb_Manager_HDmua_ProductType.DisplayMember = "Ten"; 
                cb_Manager_HDmua_ProductType.ValueMember = "ID";    
                cb_Manager_HDmua_ProductType.SelectedIndex = -1;   
            }
            else
            {
                cb_Manager_HDmua_ProductType.DataSource = null; 
            }
        }
        private void cb_Manager_HDmua_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Manager_HDmua_ProductName.DataSource = null;
            tb_Manager_HDmua_IdProduct.Text = "";
            tb_Manager_HDmua_UnitPrice.Text = "";

            if (cb_Manager_HDmua_ProductType.SelectedIndex != -1)
            {
                object selectedLoaiSPID = cb_Manager_HDmua_ProductType.SelectedValue;
                if (selectedLoaiSPID != null && int.TryParse(selectedLoaiSPID.ToString(), out int selectedIDSanPham))
                {
                    LoadTenSPToComboBox_mua(selectedIDSanPham);

                    List<string> dongiaban = LoaiSanPhamDAO.Instance.GetDonGiaMua(selectedIDSanPham);
                    if (dongiaban != null && dongiaban.Count > 0)
                    {
                        tb_Manager_HDmua_UnitPrice.Text = string.Join(", ", dongiaban);
                    }
                    else
                    {
                        tb_Manager_HDmua_UnitPrice.Text = " ";
                    }

                }
                else
                {
                    LoadTenSPToComboBox_mua(0);
                    tb_Manager_HDmua_UnitPrice.Text = "";
                }
            }
        }

        private void LoadTenSPToComboBox_mua(int selectedLoaiSPID)
        {
            List<SanPham> listSanPham = ProductDAO.Instance.GetSanPhamByIDLoai(selectedLoaiSPID);

            if (listSanPham != null && listSanPham.Count > 0)
            {
                cb_Manager_HDmua_ProductName.DataSource = listSanPham;
                cb_Manager_HDmua_ProductName.DisplayMember = "TenSanPham"; 
                cb_Manager_HDmua_ProductName.ValueMember = "ID";           
                cb_Manager_HDmua_ProductName.SelectedIndex = -1;           
            }
            else
            {
                cb_Manager_HDmua_ProductName.DataSource = null;
                tb_Manager_HDmua_IdProduct.Text = "";
            }
        }

        private void cb_Manager_HDmua_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Manager_HDmua_ProductName.SelectedIndex != -1)
            {
                object selectedValue = cb_Manager_HDmua_ProductName.SelectedValue;

                if (selectedValue != null && int.TryParse(selectedValue.ToString(), out int selectedIDSanPham))
                {
                    tb_Manager_HDmua_IdProduct.Text = selectedIDSanPham.ToString();
                }
                else
                {
                    tb_Manager_HDmua_IdProduct.Text = "";
                }
            }
            else
            {
                tb_Manager_HDmua_IdProduct.Text = "";
            }
        }
        private void tb_Manager_HDmua_UnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_Manager_HDmua_UnitPrice.Text, out decimal donGiaBan) &&
                int.TryParse(txb_Manager_HDmua_Quantity.Text, out int soLuong))
            {
                decimal tongTien = (donGiaBan * soLuong);

                tb_Manager_HDmua_Cash.Text = tongTien.ToString("N2");
            }
            else
            {
                tb_Manager_HDmua_Cash.Text = "0";
            }
        }

        private void txb_Manager_HDmua_Quantity_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_Manager_HDmua_UnitPrice.Text, out decimal donGiaBan) &&
                int.TryParse(txb_Manager_HDmua_Quantity.Text, out int soLuong))
            {
                decimal tongTien = (donGiaBan * soLuong);

                tb_Manager_HDmua_Cash.Text = tongTien.ToString("N2");
            }
            else
            {
                tb_Manager_HDmua_Cash.Text = "0";
            }
        }

        private void btn_Manager_HDmua_AddProductbill_Click(object sender, EventArgs e)
        {
            string maSP = tb_Manager_HDmua_IdProduct.Text;
            string loaiSP = cb_Manager_HDmua_ProductType.Text;
            string tenSP = cb_Manager_HDmua_ProductName.Text;
            int soLuong = 0;
            decimal donGia = 0;

            if (!int.TryParse(txb_Manager_HDmua_Quantity.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tb_Manager_HDmua_UnitPrice.Text, out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal thanhTien = (donGia * soLuong);

            ListViewItem item = new ListViewItem(maSP);
            item.SubItems.Add(loaiSP);
            item.SubItems.Add(tenSP);
            item.SubItems.Add(soLuong.ToString());
            item.SubItems.Add(donGia.ToString());
            item.SubItems.Add(thanhTien.ToString("N2")); 

            lsv_Manager_HDmua.Items.Add(item);

            tb_Manager_HDmua_IdProduct.Text = string.Empty;
            cb_Manager_HDmua_ProductType.SelectedIndex = -1;
            cb_Manager_HDmua_ProductName.DataSource = null;
            txb_Manager_HDmua_Quantity.Text = string.Empty;
            tb_Manager_HDmua_UnitPrice.Text = string.Empty;
            tb_Manager_HDmua_Cash.Text = "0";

            CalculateTotal_mua();
        }
        private void CalculateTotal_mua()
        {
            decimal total = 0;

            foreach (ListViewItem item in lsv_Manager_HDmua.Items)
            {
                if (decimal.TryParse(item.SubItems[5].Text, out decimal thanhTien))
                {
                    total += thanhTien;
                }
            }
            tb_Manager_HDmua_Total.Text = total.ToString("N2");
        }

        private void btn_Manager_HDmua_ThemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                string ngaymua = DateTimePicker_Manager_HDmua_date_time.Value.ToString("yyyy-MM-dd");

                if (!int.TryParse(tb_Manager_HDmua_IdProductBill.Text, out int id))
                {
                    MessageBox.Show("ID hóa đơn không hợp lệ.");
                    return;
                }
                if (!int.TryParse(tb_Manager_HDmua_IDncc.Text, out int idncc))
                {
                    MessageBox.Show("ID nhà cung cấp không hợp lệ.");
                    return;
                }

                if (!int.TryParse(tb_Manager_HDmua_IdStaff.Text, out int idnv))
                {
                    MessageBox.Show("ID nhân viên không hợp lệ.");
                    return;
                }
                bool isInvoiceSaved = HoaDonMuaHangDAO.Instance.AddHDMuaHang(id,  idnv, ngaymua);

                if (!isInvoiceSaved)
                {
                    MessageBox.Show("Thêm hóa đơn thất bại.");
                    return;
                }

                foreach (ListViewItem item in lsv_Manager_HDmua.Items)
                {
                    if (!int.TryParse(item.SubItems[0].Text, out int idsp))
                    {
                        MessageBox.Show("Mã sản phẩm không hợp lệ.");
                        return;
                    }

                    if (!int.TryParse(item.SubItems[3].Text, out int soLuong))
                    {
                        MessageBox.Show("Số lượng sản phẩm không hợp lệ.");
                        return;
                    }

                    if (!int.TryParse(item.SubItems[4].Text, out int dongia))
                    {
                        MessageBox.Show("Đơn giá sản phẩm không hợp lệ.");
                        return;
                    }

                    bool isDetailSaved = HoaDonMuaHangDAO.Instance.AddCTHDMuaHang(id, idncc, idsp, soLuong, dongia );

                    if (!isDetailSaved)
                    {
                        MessageBox.Show("Thêm chi tiết hóa đơn thất bại.");
                        return;
                    }
                }

                MessageBox.Show("Thêm hóa đơn thành công.");
                UpdateIDBIll();
                ResetFormAfterAddingBill_mua();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
        private void ResetFormAfterAddingBill_mua()
        {
            tb_Manager_HDmua_Total.Text = "0";
            lsv_Manager_HDmua.Items.Clear();
        }
    }
}








