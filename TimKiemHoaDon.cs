using CuaHangDaQuy.DAO;
using CuaHangDaQuy.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CNPM
{
    public partial class TimKiemHoaDon : Form
    {
        BindingSource hddvlist = new BindingSource();

        public TimKiemHoaDon()
        {
            InitializeComponent();
            DataGridView_TKHD_HDDV.DataSource = hddvlist;
            LoadDateTimePicker();
            LoadComboboxMaKH();
            AddhddvBinding();
            LoadListHDDV(1, DateTimePicker_TKHD_HDDV_Tungay.Value, DateTimePicker_TKHD_HDDV_Denngay.Value);
        }

        #region Methods

        void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            DateTimePicker_TKHD_HDDV_Tungay.Value = new DateTime(today.Year, today.Month, 1);
            DateTimePicker_TKHD_HDDV_Denngay.Value = today;
        }

        void LoadComboboxMaKH()
        {
            var customerList = KhachHangDAO.Instance.LoadListKH();
            if (customerList != null && customerList.Count > 0)
            {
                ComboBox_TKHD_HDDV_maKH.DataSource = customerList;
                ComboBox_TKHD_HDDV_maKH.DisplayMember = "ID"; // Ensure "ID" exists in the data source
                ComboBox_TKHD_HDDV_maKH.ValueMember = "ID";
            }
            else
            {
                MessageBox.Show("No customers found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ComboBox_TKHD_HDDV_maKH.DataSource = null;
            }
        }

        void LoadListHDDV(int idKH, DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
            {
                MessageBox.Show("The 'From Date' cannot be greater than the 'To Date'.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<PhieuDichVu> serviceInvoiceList = HoaDonDichVuDAO.Instance.LoadListPhieuDichVu(idKH, fromDate, toDate);
            if (serviceInvoiceList != null && serviceInvoiceList.Count > 0)
            {
                hddvlist.DataSource = serviceInvoiceList;
            }
            else
            {
                MessageBox.Show("No data found for the selected criteria.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hddvlist.DataSource = new List<PhieuDichVu>();
            }
        }

        void AddhddvBinding()
        {
            TextBox_TKHD_HDDV_maHDDV.DataBindings.Add(new Binding("Text", DataGridView_TKHD_HDDV.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }

        private void Button_TKHD_HDDV_Ok_Click(object sender, EventArgs e)
        {
            if (ComboBox_TKHD_HDDV_maKH.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid customer.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(ComboBox_TKHD_HDDV_maKH.SelectedValue.ToString(), out int selectedIDSanPham))
            {
                LoadListHDDV(selectedIDSanPham, DateTimePicker_TKHD_HDDV_Tungay.Value, DateTimePicker_TKHD_HDDV_Denngay.Value);
            }
            else
            {
                MessageBox.Show("Invalid customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_TKHD_HDDV_Show_CTHDDV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_TKHD_HDDV_maHDDV.Text))
            {
                MessageBox.Show("Xin hãy chọn mã hóa đơn!", "Có lỗi khi chọn mã hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(TextBox_TKHD_HDDV_maHDDV.Text.ToString(), out int selectedIDHDDV))
            {
                PhieuDichVu pdv = HoaDonDichVuDAO.Instance.GetPhieuDichVu(selectedIDHDDV);
                if (pdv != null)
                {
                    CTHDDV f = new CTHDDV(pdv);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No service invoice found with the selected ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid invoice ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
