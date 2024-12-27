using CNPM.DTO;
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

        }


        private void Button_BaoCaoTonKho_HienThi_Click(object sender, EventArgs e)
        {

            // Lấy ngày từ TextBox
            DateTime Ngaytext = DateTimePicker_TonKho.Value;
            int thang = Ngaytext.Month;
            int nam = Ngaytext.Year;



            // Lấy danh sách báo cáo tồn kho từ DAO
            List<BaoCaoTonKhodto> dstonkho = BaoCaoTonKhoDAO.Instance.GetTonKho(thang, nam);

            // Kiểm tra nếu danh sách tồn kho không rỗng
            if (dstonkho.Count > 0)
            {
                // Kiểm tra từng dòng dữ liệu để xem có giá trị null không
                foreach (var item in dstonkho)
                {
                    if (item.TonDau == null || item.SL_Mua == null || item.SL_Ban == null || item.TonCuoi == null)
                    {
                        // Nếu có giá trị null, hiển thị thông báo lỗi và thoát khỏi hàm
                        MessageBox.Show("Dữ liệu không tồn tại trong khoảng thời gian đã chọn!");
                        return;
                    }
                }

                // Đặt DataSource cho DataGridView một lần
                dataGridView_BaoCaoTonKho_Bang.DataSource = dstonkho;

                // Thiết lập tiêu đề cột
                dataGridView_BaoCaoTonKho_Bang.Columns["IDSanPham"].HeaderText = "Mã Sản Phẩm";
                dataGridView_BaoCaoTonKho_Bang.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dataGridView_BaoCaoTonKho_Bang.Columns["TonDau"].HeaderText = "Tồn Đầu";
                dataGridView_BaoCaoTonKho_Bang.Columns["SL_Mua"].HeaderText = "Số Lượng Mua";
                dataGridView_BaoCaoTonKho_Bang.Columns["SL_Ban"].HeaderText = "Số Lượng Bán";
                dataGridView_BaoCaoTonKho_Bang.Columns["TonCuoi"].HeaderText = "Tồn Cuối";
                dataGridView_BaoCaoTonKho_Bang.Columns["DVT"].HeaderText = "Đơn Vị Tính";
            }
            else
            {
                // Xử lý nếu danh sách trống, ví dụ hiển thị thông báo
                MessageBox.Show("Không có dữ liệu tồn kho cho tháng đã chọn.");
            }
        }


    }


}

