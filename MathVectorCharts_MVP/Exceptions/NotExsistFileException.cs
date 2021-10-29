using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Exceptions
{
    public class NotExsistFileException : BaseMathVectorChartsException
    {
        private const string _description = "Файла по указанному пути не существует";
        public override string Description
        {
            get { return _description; }
        }
        public NotExsistFileException(string message = _description) : base(message)
        {

        }
    }
}
