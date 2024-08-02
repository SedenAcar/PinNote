using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pinnotedeskup
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new giris());


        }
        public static class user_data
        {
            public static int Id { get; set; }
            public static string Name { get; set; }
            public static string Surname { get; set; }
            public static string Email { get; set; }
            public static string Password { get; set; }
            public static string PhoneNumber { get; set; }
            public static DateTime BirthDate { get; set; }
        }

       
    }
}
