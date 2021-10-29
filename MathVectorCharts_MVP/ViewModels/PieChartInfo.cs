using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.ViewModels
{
    public class PieChartInfo
    {
        public List<KeyValuePair<string, double>> Values { get; set; } = new List<KeyValuePair<string, double>>(); 
    }
}
