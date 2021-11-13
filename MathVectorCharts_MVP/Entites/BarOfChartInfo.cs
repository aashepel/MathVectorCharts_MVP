using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Entites
{
    /// <summary>
    /// Класс, содержащий информацию о конкретном столбце диаграммы
    /// </summary>
    public class BarOfChartInfo
    {
        /// <summary>
        /// Заголовок столбца для легенды
        /// </summary>
        public string TitleBar { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public double Value { get; set; }
    }
}
