using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            var mensaje = ConfigurationManager.AppSettings["mensaje"];
            Console.WriteLine(mensaje);

           
            var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;


        }
    }
}
