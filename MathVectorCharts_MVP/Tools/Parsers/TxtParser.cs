using LinearAlgebra;
using MathVectorCharts_MVP.Exceptions;
using MathVectorCharts_MVP.Tools.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Tools.Parsers
{
    public class TxtParser<T> : AbstractParser<T>, ITxtParser<T>
    {
        public TxtParser(string filePath, char separator, bool skipEmptyValues) : base(filePath)
        {
            Separator = separator;
            SkipEmptyValues = skipEmptyValues;
        }

        public virtual char Separator { get; set; }
        public virtual bool SkipEmptyValues { get; set; }

        public override void Parse()
        {
            ValidateParamsFile();
        }
    }

    public class MatrixValuesParser : TxtParser<MathVector>, ITxtParser<MathVector>
    {
        public MatrixValuesParser(string filePath, char separator = ' ', bool skipEmptyValues = true) : base(filePath, separator, skipEmptyValues)
        {

        }
        public override void Parse()
        {
            ValidateParamsFile();
            try
            {
                var lines = File.ReadAllLines(_filePath).ToList();

                _records = lines
                    .Select(line => line.Split(Separator).Where(p => p.Length != 0))
                    .Select(points => points.Select(point => double.Parse(point)))
                    .Select(lineMatrix => new MathVector(lineMatrix.ToArray()))
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
