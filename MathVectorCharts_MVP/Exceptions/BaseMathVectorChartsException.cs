using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Exceptions
{
    public class BaseMathVectorChartsException : Exception
    {
        private const string _description = "Базовый класс исключений сборки";
        public virtual string Description
        {
            get { return _description; }
        }
        public BaseMathVectorChartsException(string message = _description) : base(message)
        {

        }
    }
}
