using CuaHangDaQuy.DTO;
using QuanLyCuaHangDaQuy.DAO;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void ControlBox_loginForm_X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("U Want To Quit?", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void Button_loginForm_LOGIN_Click(object sender, EventArgs e)
        {
            string userName = TextBox_loginForm_Username.Text;
            string passWord = TextBox_loginForm_Password.Text;
            if (Login_Admin(userName, passWord))
            {
                NhanVien loginNhanVien = NhanVienDAO.Instance.GetNhanVienByUserName(userName);
                Manager f = new Manager(loginNhanVien);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Login Error");
            }
        }
        bool Login_Admin(string username, string password)
        {
            return NhanVienDAO.Instance.Login_Admin(username, password);
        }

        private void Button_loginForm_SIGNUP_Click(object sender, EventArgs e)
        {

            Signup_form i = new Signup_form();
            this.Hide();
            i.ShowDialog();
            this.Show();
        }
    }
}
