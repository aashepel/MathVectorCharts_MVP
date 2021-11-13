using MathVectorCharts_MVP.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Services
{
    public interface IChartsService
    {
        List<BarChartInfo> LoadBarChartsInfo();
        PieChartInfo LoadPieChartInfo();
        void LoadIrises(string filePath);
    }
}
