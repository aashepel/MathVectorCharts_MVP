using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Exceptions
{
    public class UnknowClusteringAlgorithm : BaseMathVectorChartsException
    {
        private const string _description = "Алгоритм кластеризации еще не определен в программе. Выберите другой алгоритм";
        public override string Description
        {
            get { return _description; }
        }
        public UnknowClusteringAlgorithm(string message = _description) : base(message)
        {

        }
    }
}
