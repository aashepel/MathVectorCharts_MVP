using MathVectorCharts_MVP.Models;
using MathVectorCharts_MVP.ViewModels;
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
        void ReLoad();
        string FilePath { get; set; }
    }
}
