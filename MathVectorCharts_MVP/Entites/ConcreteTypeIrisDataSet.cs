using LinearAlgebra;
using MathVectorCharts_MVP.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Entites
{
    public class ConcreteTypeIrisDataSet
    {
        /// <summary>
        /// Список ирисов ОДНОГО типа
        /// </summary>
        private List<Iris> _irises;

        /// <summary>
        /// Конструкор
        /// </summary>
        /// <param name="type">Тип ириса</param>
        public ConcreteTypeIrisDataSet(string type)
        {
            _irises = new List<Iris>();
            Type = type;
        }

        /// <summary>
        /// Авто-свойство для типа ириса
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Свойство для получения списка ирисов
        /// </summary>
        public List<Iris> Irises
        {
            get { return _irises; }
        }

        /// <summary>
        /// Метод для добавления ириса в дата-сет
        /// </summary>
        /// <param name="iris"></param>
        public void Add(Iris iris)
        {
            _irises.Add(iris);
        }

        /// <summary>
        /// Метод для вычисления усредненного вектора
        /// </summary>
        /// <returns>Усредненный математический вектор</returns>
        public IMathVector ArithmeticMeanVector()
        {

            IMathVector arithmeticMeansVector;
            // Если список ирисов пуст, бросаем исключение
            if (_irises.Any())
            {
                arithmeticMeansVector = new MathVector(_irises.ElementAt(0).VectorParams);
            }
            else
            {
                throw new ImpossibleCalculateMeanVectorException();
            }

            try
            {
                foreach (Iris iris in _irises)
                {
                    arithmeticMeansVector = (arithmeticMeansVector as MathVector) + iris.VectorParams;
                }
                arithmeticMeansVector = (arithmeticMeansVector as MathVector) / _irises.Count;
            }
            // Если при вычислении усредненного вектора возникает исключительная ситуация (например, обращение к несуществующему индексу вектора), бросаем свое исключение
            catch
            {
                throw new ImpossibleCalculateMeanVectorException();
            }

            return (arithmeticMeansVector as MathVector);
        }

        /// <summary>
        /// Метод для вычисления среднего арифмитического значения по определенному столбцу списка векторов
        /// </summary>
        /// <param name="indexColumn">Индекс столбца. Нумерация с нуля</param>
        /// <returns>Среднее арифмитическое значение</returns>
        public double ArithmeticMeanOfColumn(int indexColumn)
        {
            // Если ирисов в списке нет, бросаем исключение
            if (!_irises.Any())
            {
                throw new ImpossibleCalculateMeanValueOfColumn();
            }
            double sum = 0;
            int counter = 0;
            try
            {
                foreach (Iris iris in _irises)
                {
                    sum += iris.VectorParams[indexColumn];
                    counter++;
                }
            }
            // Если при вычислении усредненного вектора возникает исключительная ситуация (например, обращение к несуществующему индексу вектора), бросаем свое исключение
            catch
            {
                throw new ImpossibleCalculateMeanValueOfColumn();
            }
            return sum / counter;
        }
        public double ArithmeticMeanSepalLength()
        {
            return ArithmeticMeanOfColumn(0);
        }
        public double ArithmeticMeanSepalWidth()
        {
            return ArithmeticMeanOfColumn(1);
        }
        public double ArithmeticMeanPetalLength()
        {
            return ArithmeticMeanOfColumn(2);
        }
        public double ArithmeticMeanPetalWidth()
        {
            return ArithmeticMeanOfColumn(3);
        }
        public override string ToString()
        {
            string result = "";
            result += "-------------------------------------------------------------\n";
            result += $"TYPE: {Type.ToUpper()}\n";
            result += $"ArithmeticMeanSepalLength: {ArithmeticMeanSepalLength()}\n";
            result += $"ArithmeticMeanSepalWidth: {ArithmeticMeanSepalWidth()}\n";
            result += $"ArithmeticMeanPetalLength: {ArithmeticMeanPetalLength()}\n";
            result += $"ArithmeticMeanPetalWidth: {ArithmeticMeanPetalWidth()}\n";
            foreach (var iris in _irises)
            {
                result += iris;
                result += '\n';
            }
            result += "-------------------------------------------------------------\n";
            return result;
        }
    }
}
