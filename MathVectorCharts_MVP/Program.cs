using MathVectorCharts_MVP.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathVectorCharts_MVP
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /// MVP BINDING ///
            //var view = new View();
            //var service = new Service();
            //var presenter = new Presenter(view, service);
            /// MVP BINDING ///


            Application.Run(new View());
        }
    }
}
