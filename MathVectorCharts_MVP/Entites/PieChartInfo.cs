using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Entites
{
    /// <summary>
    /// Класс, содержащий информацию, необходимую для построения круговой диаграммы
    /// </summary>
    public class PieChartInfo
    {
        /// <summary>
        /// Массив с информацией о кусочках диаграммы
        /// </summary>
        public List<PieOfChartInfo> Values { get; set; } = new List<PieOfChartInfo>();
    }
}
