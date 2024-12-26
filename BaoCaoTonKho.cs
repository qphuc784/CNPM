using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CNPM
{
    public partial class BaoCaoTonKho : Form
    {
        public BaoCaoTonKho()
        {
            InitializeComponent();
            LoadTenLoaiToComboBox();
            ComboBox_BaoCaoTonKho_TypeSP.SelectedIndexChanged += ComboBox_BaoCaoTonKho_TypeSP_SelectedIndexChanged;
        }

        // Tải dữ liệu loại sản phẩm vào ComboBox
        private void LoadTenLoaiToComboBox()
        {
            List<LoaiSP> listTenLoai = ProductDAO.Instance.GetListSanPham();
            ComboBox_BaoCaoTonKho_TypeSP.DataSource = listTenLoai;
            ComboBox_BaoCaoTonKho_TypeSP.DisplayMember = "Ten";
        }

        // Khi chọn loại sản phẩm, cập nhật tên sản phẩm tương ứng
        private void ComboBox_BaoCaoTonKho_TypeSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TenLoai = ComboBox_BaoCaoTonKho_TypeSP.Text;
            List<SanPham> listTensp = ProductDAO.Instance.GetSanPhamByTenLoai(TenLoai);
            SanPham tatCaSanPham = new SanPham { TenSanPham = "Tất Cả" };
            listTensp.Insert(0, tatCaSanPham);

            ComboBox_BaoCaoTonKho_NameSP.DataSource = listTensp;
            ComboBox_BaoCaoTonKho_NameSP.DisplayMember = "TenSanPham"; // Hiển thị tên sản phẩm
        }

        // Xử lý khi nhấn nút "Hiển Thị"
        private void Button_BaoCaoTonKho_HienThi_Click(object sender, EventArgs e)
        {
            string TenLoai = ComboBox_BaoCaoTonKho_TypeSP.Text;
            string TenSanPham = ComboBox_BaoCaoTonKho_NameSP.Text;
            DateTime tuNgay = DateTimePicker_BaoCaoTonKho_Tungay.Value;
            DateTime denNgay = DateTimePicker_BaoCaoTonKho_Denngay.Value;

            // Kiểm tra nếu khoảng thời gian hợp lệ
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày Bắt Đầu Phải Lớn Hơn Ngày Kết Thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị sản phẩm theo tên và loại
            if (TenSanPham == "Tất Cả")
            {
                LoadAllSanPham(TenLoai, tuNgay, denNgay);
            }
            else
            {
                LoadSanPhamByTenLoaiAndName(TenLoai, TenSanPham, tuNgay, denNgay);
            }
            dataGridView_BaoCaoTonKho_Bang.Columns["ID"].HeaderText = "Mã Sản Phẩm";
            dataGridView_BaoCaoTonKho_Bang.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dataGridView_BaoCaoTonKho_Bang.Columns["IDLoai"].HeaderText = "Mã Loại SP";
            dataGridView_BaoCaoTonKho_Bang.Columns["SoLuong"].HeaderText = "Số Lượng";
            dataGridView_BaoCaoTonKho_Bang.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dataGridView_BaoCaoTonKho_Bang.Columns["NgayThayDoiSL"].HeaderText = "Ngày Thay Đổi Số Lượng";
            dataGridView_BaoCaoTonKho_Bang.Columns["SL_Truoc"].HeaderText = "Số Lượng Trước";
            dataGridView_BaoCaoTonKho_Bang.Columns["LoiNhuan"].HeaderText = "Lợi Nhuận";

        }

        // Hàm tải tất cả sản phẩm theo loại và khoảng thời gian
        private void LoadAllSanPham(string TenLoai, DateTime tuNgay, DateTime denNgay)
        {
            List<SanPham> listallsp = ProductDAO.Instance.USP_GetAllSanPhamByTenLoai(TenLoai, tuNgay, denNgay);

            // Kiểm tra nếu không có sản phẩm nào trong khoảng thời gian
            if (listallsp.Count == 0)
            {
                MessageBox.Show("Không Tồn Tại Sản Phẩm Trong Khoảng Thời Gian Này, Vui Lòng Thử Lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView_BaoCaoTonKho_Bang.DataSource = listallsp;
            }
        }

        // Hàm tải sản phẩm theo tên và loại
        private void LoadSanPhamByTenLoaiAndName(string TenLoai, string TenSanPham, DateTime tuNgay, DateTime denNgay)
        {
            List<SanPham> listsp = ProductDAO.Instance.GetSanPhamByTenSP(TenSanPham);
            var filteredList = listsp.Where(sp => sp.NgayThayDoiSL >= tuNgay && sp.NgayThayDoiSL <= denNgay).ToList();

            // Kiểm tra nếu không có sản phẩm nào trong khoảng thời gian
            if (filteredList.Count == 0)
            {
                MessageBox.Show("Không Tồn Tại Sản Phẩm Trong Khoảng Thời Gian Này, Vui Lòng Thử Lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView_BaoCaoTonKho_Bang.DataSource = filteredList;
            }
        }
    }
}
