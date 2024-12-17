using CNPM.DAO;
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
    public partial class UCservice : UserControl
    {
        public UCservice()
        {
            InitializeComponent();
        }

        private void Button_UCservice_Xoa_Click(object sender, EventArgs e)
        {
            string TenLoai = TextBox_UCservice_timkiem.Text;
            DialogResult result = MessageBox.Show(
        $"Bạn có chắc chắn muốn xóa không?",
        "Xác nhận xóa",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
        );
            if (result == DialogResult.Yes)
            {
                bool isdeleted = DichVuDAO.Instance.DeleteDichVuByTenLoai(TenLoai);
                if (isdeleted)
                {
                    MessageBox.Show("Đã Xóa Thành Công!");
                    DataGridView_UCservice.DataSource = null;
                    TextBox_UCservice_timkiem.Clear();
                }
            }
        }
        private void Button_UCservice_OK_Click(object sender, EventArgs e)
        {
            string TenLoai = TextBox_UCservice_timkiem.Text;
            List<LoaiDichVu> loaidichvu = DichVuDAO.Instance.GetDichVuByTenLoai(TenLoai);
            if (loaidichvu.Count > 0)
            {
                // Gán dữ liệu vào DataGridView
                DataGridView_UCservice.DataSource = loaidichvu;
                // Tùy chỉnh cột nếu cần
                DataGridView_UCservice.Columns["ID"].HeaderText = "Mã Dịch Vụ";
                DataGridView_UCservice.Columns["TenLoai"].HeaderText = "Tên Dịch Vụ";
                DataGridView_UCservice.Columns["DonGia"].HeaderText = "Đơn Giá";
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Dịch Vụ này, Vui Lòng Thử Lại!");

            }
        }
        private void Button_UCservice_Sua_Click(object sender, EventArgs e)
        {
            if (DataGridView_UCservice.Rows.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Dịch Vụ Để Cập Nhật");
            }
            foreach (DataGridViewRow row in DataGridView_UCservice.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng mới
                // lấy giá trị từ các cột
                string TenLoai = row.Cells["TenLoai"].Value.ToString();
                float DonGia = Convert.ToSingle(row.Cells["DonGia"].Value);
                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                DataGridView_UCservice.ReadOnly = false;
                DataGridView_UCservice.Columns["ID"].ReadOnly = true; // ID không được chỉnh sửa
                bool isUpdate = DichVuDAO.Instance.UpdateDichVu(TenLoai, DonGia, ID);
                if (!isUpdate)
                {
                    MessageBox.Show("Cập Nhật Thất Bại, Vui Lòng Thử Lại!");
                    return;
                }
            }
            MessageBox.Show("Cập Nhật Thành Công!");
        }

        private void Button_UCservice_Them_Click(object sender, EventArgs e)
        {
            AddService newservice = new AddService();
            newservice.ShowDialog();
        }
    }
}