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
    /// <summary>
    /// Абстрактный txt парсер
    /// </summary>
    /// <typeparam name="T">Объекты какого класса необходимо парсить</typeparam>
    public abstract class TxtParser<T> : AbstractParser<T>, ITxtParser<T>
    {
        public TxtParser(string filePath, char separator, bool skipEmptyValues) : base(filePath)
        {
            Separator = separator;
            SkipEmptyValues = skipEmptyValues;
        }

        /// <summary>
        /// Символ, отделяющий значения в строках
        /// </summary>
        public virtual char Separator { get; set; }

        /// <summary>
        /// Свойство, указывающее на то, пропускать ли пустые значение в строках или нет
        /// </summary>
        public virtual bool SkipEmptyValues { get; set; }

        /// <inheritdoc cref="AbstractParser{T}.Parse()"/>
        public abstract override void Parse();
    }

    /// <summary>
    /// Парсер для матрицы (списка векторов)
    /// </summary>
    public class MatrixValuesParser : TxtParser<MathVector>, ITxtParser<MathVector>
    {
        public MatrixValuesParser(string filePath, char separator = ' ', bool skipEmptyValues = true) : base(filePath, separator, skipEmptyValues)
        {

        }

        /// <summary>
        /// Метод Parse для матрицы
        /// </summary>
        /// <exception cref="InvalidFileContentException">Бросаем</exception>
        public override void Parse()
        {
            ValidateParamsFile();
            try
            {
                var lines = File.ReadAllLines(_filePath).ToList(); // Получаем массив строк из файла

                _records = lines
                    .Select(line => line.Split(Separator).Where(p => p.Length != 0)) // Делим строки на "ячейки" с непустыми значениями
                    .Select(points => points.Select(point => double.Parse(point))) // Из массива значений формируем массив double значений
                    .Select(lineMatrix => new MathVector(lineMatrix.ToArray())) // Добавляем в список новый математический вектор
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
