using MathVectorCharts_MVP.Entites;
using MathVectorCharts_MVP.Tools.Parsers;
using MathVectorCharts_MVP.Tools.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Services
{
    /// <summary>
    /// Класс, для получения информации об отрисовываемых диаграммах
    /// </summary>
    public class ChartsService : IChartsService
    {
        private IrisesDataSet _dataSet;
        private IParser<Iris> _parser;

        public ChartsService()
        {
            _dataSet = new IrisesDataSet();
            _parser = new CsvIrisParser(null, ',');
        }

        /// <summary>
        /// Метод для получения информации, необходимой для отрисовки столбчатых диаграмм
        /// </summary>
        /// <returns>Массив информации о столбчатых диаграммах</returns>
        public List<BarChartInfo> LoadBarChartsInfo()
        {
            List<BarChartInfo> barChartsInfo = new List<BarChartInfo>(); // Список информации о всех столбчатых диаграммах
            // В цикле, для каждого поля (свойства) ириса, кроме последнего (так как последнее поле ириса - его тип, делаем количество циклов меньншим на 1) получаем информацию для конкретной диграммы
            for (int i = 0; i < _parser.Headers.Count - 1; i++)
            {
                BarChartInfo chartInfo = new BarChartInfo();
                chartInfo.Title = _parser.Headers[i]; // Заголовок диаграммы - название поля из заголовка таблицы
                // В цикле получаем информацию для построения конкретного столбика диаграммы
                for (int j = 0; j < _dataSet.CountTypes; j++)
                {
                    string title = _dataSet[j].Type; // Устанавливаем заголовок столбца (для легенды диаграммы)
                    double value = Math.Round(_dataSet[j].ArithmeticMeanOfColumn(i), 2); // Значение столбца
                    chartInfo.Values.Add(new BarOfChartInfo { TitleBar = title, Value = value }); // Добавляем в список информации о столбцах диаграммы
                }
                barChartsInfo.Add(chartInfo); // Добавляем информацию о диаграмме в общий список
            }
            return barChartsInfo;
        }

        /// <summary>
        /// Метод для получения информации, необходимой для построения круговой диаграммы
        /// </summary>
        /// <returns></returns>
        public PieChartInfo LoadPieChartInfo()
        {
            PieChartInfo pieChartInfo = new PieChartInfo(); // Информация о круглой диаграмме
            for (int i = 0; i < _dataSet.CountTypes; i++)
            {
                for (int j = i + 1; j < _dataSet.CountTypes; j++)
                {
                    string title = $"{_dataSet[i].Type} & {_dataSet[j].Type}"; // Заголовок кусочка для занесения в легенду
                    double value = Math.Round(_dataSet[i].ArithmeticMeanVector().CalcDistance(_dataSet[j].ArithmeticMeanVector()), 2); // Значение
                    pieChartInfo.Values.Add(new PieOfChartInfo { TitlePie = title, Value = value }); // Добавляем информацию о кусочке в список
                }
            }
            return pieChartInfo;
        }

        /// <summary>
        /// Метод для загрузки ирисов из файла в дата-сет
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadIrises(string filePath)
        {
            _parser.Parse(filePath);
            _dataSet.Irises = new List<Iris>(_parser.Records); // Заносим ирисы в дата-сет, где они распределяются по другим дата-сетам
        }
    }
}
