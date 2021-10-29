using MathVectorCharts_MVP.Models;
using MathVectorCharts_MVP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.UI
{
    public interface IChartsView : IView
    {
        void RenderBarCharts(List<BarChartInfo> chartsInfo);
        void RenderPieChart(PieChartInfo pieChartInfo);
        void ClearAllCharts();
    }
}
