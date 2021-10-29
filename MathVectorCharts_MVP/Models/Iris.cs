using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Models
{
    public class Iris
    {
        /// <summary>
        /// Математический вектор, состоящий из значений параметров ириса
        /// </summary>
        private MathVector _vectorParams;

        /// <summary>
        /// Тип ириса (Например, setosa)
        /// </summary>
        private string _typeIris;

        /// <summary>
        /// Допустимые значения параметров ириса
        /// </summary>
        private static List<string> _possibleNameOfParams = new List<string> { "sepal_length", "sepal_width", "petal_length", "petal_width", "species" };

        /// <summary>
        /// Допустимые типы ирисов (поле не используется)
        /// </summary>
        private static List<string> _possibleTypesIrises = new List<string> { "setosa", "versicolor", "virginica" };

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="vectorParams">Вектор параметров</param>
        /// <param name="typeIris">Тип ириса</param>
        public Iris(MathVector vectorParams, string typeIris)
        {
            _vectorParams = vectorParams;
            _typeIris = typeIris;
        }

        public Iris()
        {
            _vectorParams = new MathVector(4);
        }

        /// <summary>
        /// Допустимые значения параметров ириса (используется при проверке файла)
        /// </summary>
        public static List<string> PossibleNameOfParams
        {
            get { return _possibleNameOfParams; }
        }

        /// <summary>
        /// Допустимые типы ирисов (поле не используется)
        /// </summary>
        public static List<string> PossibleTypesIrises
        {
            get { return _possibleTypesIrises; }
        }

        /// <summary>
        /// Свойство для получения математического вектора, состоящешо из значений параметров ириса
        /// </summary>
        public MathVector VectorParams
        {
            get { return _vectorParams; }
        }

        /// <summary>
        /// Свойство для получения типа ириса
        /// </summary>
        public string TypeIris
        {
            get { return _typeIris; }
            set { _typeIris = value; }
        }

        // Неиспользуемые свойства

        public double SepalLength
        {
            get { return _vectorParams[0]; }
            set { _vectorParams[0] = value; }
        }
        public double SepalWidth
        {
            get { return _vectorParams[1]; }
            set {  _vectorParams[1] = value; }
        }
        public double PetalLength
        {
            get { return _vectorParams[2]; }
            set {  _vectorParams[2] = value; }
        }
        public double PetalWidth
        {
            get { return _vectorParams[3]; }
            set { _vectorParams[3] = value; }
        }
        public override string ToString()
        {
            return $"{_vectorParams}, {_typeIris}";
        }
    }

}
