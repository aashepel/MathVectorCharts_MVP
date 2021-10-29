using MathVectorCharts_MVP.Models;
using MathVectorCharts_MVP.Tools.Parsers;
using MathVectorCharts_MVP.Tools.Parsers.Interfaces;
using MathVectorCharts_MVP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.UI.ChartsUI
{
    public class ChartsService : IChartsService
    {
        IrisesDataSet _dataSet;
        IParser<Iris> _parser;
        public ChartsService()
        {
            _dataSet = new IrisesDataSet();
            _parser = new CsvIrisParser(null, ',');
        }
        List<BarChartInfo> IChartsService.LoadBarChartsInfo()
        {
            if (!_parser.SuccessfullyParsed)
            {
                _parser.Parse();
            }

            List<BarChartInfo> barChartsInfo = new List<BarChartInfo>();
            for (int i = 0; i < _parser.Headers.Count - 1; i++)
            {
                BarChartInfo chartInfo = new BarChartInfo();
                chartInfo.Title = _parser.Headers[i];
                for (int j = 0; j < _dataSet.CountTypes; j++)
                {
                    chartInfo.Values.Add(new KeyValuePair<string, double>(_dataSet[j].Type, Math.Round(_dataSet[j].ArithmeticMeanOfColumn(i), 2)));
                }
                barChartsInfo.Add(chartInfo);
            }
            return barChartsInfo;
        }

        PieChartInfo IChartsService.LoadPieChartInfo()
        {
            if (!_parser.SuccessfullyParsed)
            {
                _parser.Parse();
            }

            PieChartInfo pieChartInfo = new PieChartInfo();
            for (int i = 0; i < _dataSet.CountTypes; i++)
            {
                for (int j = i + 1; j < _dataSet.CountTypes; j++)
                {
                    string title = $"{_dataSet[i].Type} & {_dataSet[j].Type}";
                    double value = Math.Round(_dataSet[i].ArithmeticMeanVector().CalcDistance(_dataSet[j].ArithmeticMeanVector()), 2);
                    KeyValuePair<string, double> dataPoint = new KeyValuePair<string, double>(title, value);
                    pieChartInfo.Values.Add(dataPoint);
                }
            }
            return pieChartInfo;
        }

        void IChartsService.LoadIrises(string filePath)
        {
            _parser.Parse(filePath);
            _dataSet.Irises = new List<Iris>(_parser.Records);
        }
    }
}
