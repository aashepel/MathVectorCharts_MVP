using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Entites
{
    public class PieOfChartInfo
    {
        /// <summary>
        /// Заголовок кусочка для легенды
        /// </summary>
        public string TitlePie { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public double Value { get; set; }
    }
}
