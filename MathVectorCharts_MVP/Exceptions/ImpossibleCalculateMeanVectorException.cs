using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Exceptions
{
    public class ImpossibleCalculateMeanVectorException : BaseMathVectorChartsException
    {
        private const string _description = "Невозможно высчитать усредненный вектор";
        public override string Description
        {
            get { return _description; }
        }
        public ImpossibleCalculateMeanVectorException(string message = _description) : base(message)
        {

        }
    }
}
