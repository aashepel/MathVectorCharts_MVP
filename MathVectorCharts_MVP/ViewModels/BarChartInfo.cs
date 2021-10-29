using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Models
{
    public class BarChartInfo
    {
        public string Title { get; set; } = "None";
        public bool AxisXLabelShow { get; set; } = false;
        public bool AxisYLabelShow { get; set; } = true;
        /// <summary>
        /// Key - тип ириса. Value - значение точки
        /// </summary>
        public List<KeyValuePair<string,double>> Values { get; set; } = new List<KeyValuePair<string, double>>();
    }
}
