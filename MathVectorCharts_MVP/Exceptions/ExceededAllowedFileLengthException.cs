using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Exceptions
{
    public class ExceededAllowedFileLengthException : BaseMathVectorChartsException
    {
        private const string _descritpion = "Превышен допустимый размер файла";
        public override string Description
        {
            get { return _descritpion; }
        }
        public ExceededAllowedFileLengthException(string message = _descritpion) : base(message)
        {

        }
    }
}
