using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Tools.Parsers.Interfaces
{
    public interface ITxtParser<T> : IParser<T>
    {
        char Separator { get; set; }
        bool SkipEmptyValues { get; set; }
    }
}
