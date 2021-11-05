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
    /// <summary>
    /// Абстрактный Csv парсер
    /// </summary>
    /// <typeparam name="T">Объекты какого класса необходимо "парсить"</typeparam>
    public abstract class CsvParser<T> : AbstractParser<T>, ICsvParser<T> where T : class, new()
    {
        protected IFormatProvider _formatter;
        public CsvParser(string filePath, char separator = ',') : base(filePath)
        {
            Separator = separator;
            _formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
        }

        /// <summary>
        /// Символ, отделяющий ячейки в строке
        /// </summary>
        public char Separator { get; set; }

        /// <inheritdoc cref="AbstractParser{T}.Parse()"/>
        public abstract override void Parse();
    }

    public class CsvIrisParser : CsvParser<Iris>, ICsvParser<Iris>
    {
        public CsvIrisParser(string filePath, char separator = ',') : base(filePath, separator)
        {
        }

        /// <summary>
        /// Метод Parse для ирисов
        /// </summary>
        /// <exception cref="InvalidFileContentException"></exception>
        public override void Parse()
        {
            ValidateParamsFile();
            try
            {
                var lines = File.ReadAllLines(FilePath, Encoding.UTF8).ToList(); // Получаем все строки файла
                _headers = lines.ElementAtOrDefault(0)?.Split(Separator).ToList(); // Получаем заголовки csv файла

                _records = lines
                    .Skip(1) // Пропускаем первую строку (это заголовок)
                    .Select(p => p.Split(Separator)) // Делим строку на ячейки 
                    .Select(p => new Iris // Из ячеек делаем ирис
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
