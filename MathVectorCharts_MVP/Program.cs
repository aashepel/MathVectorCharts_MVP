using MathVectorCharts_MVP.Presenters;
using MathVectorCharts_MVP.Services;
using MathVectorCharts_MVP.Views;
using System;
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
            IrisesAnalysisView view = new IrisesAnalysisView();
            ChartsService service = new ChartsService();
            var presenter = new IrisesAnalysisPresenter(view, service);
            /// MVP BINDING ///
            
            Application.Run(view);
        }
    }
}
