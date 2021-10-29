using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Exceptions
{
    public class ImpossibleCalculateMeanValueOfColumn : BaseMathVectorChartsException
    {
        private const string _description = "Невозможно высчитать среднее значение по параметру списка ирисов";
        public override string Description
        {
            get { return _description; }
        }
        public ImpossibleCalculateMeanValueOfColumn(string message = _description) : base(message)
        {

        }
    }
}
