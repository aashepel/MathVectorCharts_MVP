using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Tools.Parsers.Interfaces
{
    public interface IParser<T>
    {
        bool SuccessfullyParsed { get; }
        string FilePath { get; set; }
        void Parse(string filePath);
        void Parse();
        List<T> Records { get; }
        List<string> Headers { get; }
    }
}
