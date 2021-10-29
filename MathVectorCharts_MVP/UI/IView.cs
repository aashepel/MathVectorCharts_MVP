using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.UI
{
    public interface IView
    {
        void ShowErrorMessage(string message);
        void Show();
        void Close();
    }
}
