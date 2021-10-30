using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.ViewModels
{
    public class BarChartInfo
    {
        public string Title { get; set; } = "None";
        public bool AxisXLabelShow { get; set; } = false;
        public bool AxisYLabelShow { get; set; } = true;

        public List<BarOfChartInfo> Values = new List<BarOfChartInfo>();
    }
}
