using CuaHangDaQuy.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CNPM
{
    public partial class Signup_form : Form
    {
        public Signup_form()
        {
            InitializeComponent();
        }

        private void Signup_form_Load(object sender, EventArgs e)
        {

        }

        private void ControlBox_SignupForm_X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_SignupForm_SIGNUP_Click(object sender, EventArgs e)
        {
            string userName = TextBox_SignupForm_Username.Text;
            string passWord = TextBox_SignupForm_Password.Text;
            string email = TextBox_SignupForm_Email.Text;
            string cf_password = TextBox_SignupForm_cf_password.Text;
            string name = TextBox_SignupForm_Name.Text;

            if (string.IsNullOrWhiteSpace(TextBox_SignupForm_Username.Text) ||
                string.IsNullOrWhiteSpace(TextBox_SignupForm_Email.Text) ||
                string.IsNullOrWhiteSpace(TextBox_SignupForm_Password.Text) ||
                string.IsNullOrWhiteSpace(TextBox_SignupForm_cf_password.Text) ||
                string.IsNullOrWhiteSpace(TextBox_SignupForm_Name.Text))
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            
            if (checkNhanVien(userName))
            {
                MessageBox.Show("Username đã được sử dụng ");
                return;
            }

            if (string.CompareOrdinal(passWord, cf_password) != 0)
            {
                MessageBox.Show("Password không khớp");
                return;
            }

            bool result = NhanVienDAO.Instance.InsertNhanVien(userName, passWord, name, email);
            if (!result)
            {
                MessageBox.Show("Đăng ký không thành công");
            }  
            else
            {

                MessageBox.Show("Thành công");
                this.Close();
            }

        }

        bool checkNhanVien(string username)
        {
            return NhanVienDAO.Instance.checkNhanVien(username);
        }
    }
}