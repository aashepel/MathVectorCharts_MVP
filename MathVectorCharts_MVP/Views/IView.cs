using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Views
{
    public interface IView
    {
        void ShowErrorMessage(string message);
        void InitializePresenter();
        void Show();
        void Close();
    }
}
