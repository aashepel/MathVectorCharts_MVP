using MathVectorCharts_MVP.Exceptions;
using MathVectorCharts_MVP.Models;
using MathVectorCharts_MVP.Tools.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Tools.Parsers
{
    public class CsvParser<T> : AbstractParser<T>, ICsvParser<T> where T : class, new()
    {
        protected IFormatProvider _formatter;
        public CsvParser(string filePath, char separator = ',') : base(filePath)
        {
            Separator = separator;
            _formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
        }
        public char Separator { get; set; }
        public override void Parse()
        {
            ValidateParamsFile();
            throw new NotImplementedException();
        }
    }
    public class CsvIrisParser : CsvParser<Iris>, ICsvParser<Iris>
    {
        public CsvIrisParser(string filePath, char separator = ',') : base(filePath, separator)
        {
        }
        public override void Parse()
        {
            ValidateParamsFile();
            try
            {
                var lines = File.ReadAllLines(FilePath, Encoding.UTF8).ToList();
                _headers = lines.ElementAtOrDefault(0)?.Split(Separator).ToList();

                _records = lines
                    .Skip(1)
                    .Select(p => p.Split(Separator))
                    .Select(p => new Iris
                    {
                        SepalLength = Double.Parse(p[0], _formatter),
                        SepalWidth = Double.Parse(p[1], _formatter),
                        PetalLength = Double.Parse(p[2], _formatter),
                        PetalWidth = Double.Parse(p[3], _formatter),
                        TypeIris = p[4]
                    })
                    .ToList();
                _successfullyParsed = true;
            }
            catch
            {
                _successfullyParsed = false;
                throw new InvalidFileContentException();
            }
        }
    }
}
