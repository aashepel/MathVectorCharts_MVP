using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.ViewModels
{
    /// <summary>
    /// Класс, содержащий информацию, необходимую для построения столбчатой диаграммы
    /// </summary>
    public class BarChartInfo
    {
        /// <summary>
        /// Заголовок диаграммы
        /// </summary>
        public string Title { get; set; } = "None";
        
        /// <summary>
        /// Показывать ли значения на оси X
        /// </summary>
        public bool AxisXLabelShow { get; set; } = false;

        /// <summary>
        /// Показывать ли значнеия на оси Y
        /// </summary>
        public bool AxisYLabelShow { get; set; } = true;

        /// <summary>
        /// Массив информации о столбиках диаграммы
        /// </summary>
        public List<BarOfChartInfo> Values = new List<BarOfChartInfo>();
    }
}
