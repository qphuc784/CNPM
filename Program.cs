using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new Signup_form());
            //Application.Run(new Interface());
            //Application.Run(new Manager());
            //Application.Run(new BaoCaoTonKho());
            //Application.Run(new AddProduct());
            //Application.Run(new AddService());
            //Application.Run(new Addservicebill());
            //Application.Run(new Addproductbill());
            //Application.Run(new Addgoodreceipt());
            //Application.Run(new TimKiemHoaDon());
            //Application.Run(new AddCustomer());
        }
    }
}
