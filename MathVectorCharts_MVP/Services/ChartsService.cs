﻿using MathVectorCharts_MVP.Models;
using MathVectorCharts_MVP.Tools.Parsers;
using MathVectorCharts_MVP.Tools.Parsers.Interfaces;
using MathVectorCharts_MVP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Services
{
    public class ChartsService : IChartsService
    {
        private IrisesDataSet _dataSet;
        private IParser<Iris> _parser;

        public ChartsService()
        {
            _dataSet = new IrisesDataSet();
            _parser = new CsvIrisParser(null, ',');
        }


        string IChartsService.FilePath
        {
            get
            {
                return _parser.FilePath;
            }
            set
            {
                _parser.FilePath = value;
            }
        }

        public List<BarChartInfo> LoadBarChartsInfo()
        {
            if (!_parser.SuccessfullyParsed)
            {
                ReLoad();
            }

            List<BarChartInfo> barChartsInfo = new List<BarChartInfo>();
            for (int i = 0; i < _parser.Headers.Count - 1; i++)
            {
                BarChartInfo chartInfo = new BarChartInfo();
                chartInfo.Title = _parser.Headers[i];
                for (int j = 0; j < _dataSet.CountTypes; j++)
                {
                    string title = _dataSet[j].Type;
                    double value = Math.Round(_dataSet[j].ArithmeticMeanOfColumn(i), 2);
                    chartInfo.Values.Add(new BarOfChartInfo { TitleBar = title, Value = value });
                }
                barChartsInfo.Add(chartInfo);
            }
            return barChartsInfo;
        }

        public PieChartInfo LoadPieChartInfo()
        {
            if (!_parser.SuccessfullyParsed)
            {
                ReLoad();
            }

            PieChartInfo pieChartInfo = new PieChartInfo();
            for (int i = 0; i < _dataSet.CountTypes; i++)
            {
                for (int j = i + 1; j < _dataSet.CountTypes; j++)
                {
                    string title = $"{_dataSet[i].Type} & {_dataSet[j].Type}";
                    double value = Math.Round(_dataSet[i].ArithmeticMeanVector().CalcDistance(_dataSet[j].ArithmeticMeanVector()), 2);
                    pieChartInfo.Values.Add(new PieOfChartInfo { TitlePie = title, Value = value });
                }
            }
            return pieChartInfo;
        }

        public void LoadIrises(string filePath)
        {
            _parser.Parse(filePath);
            _dataSet.Irises = new List<Iris>(_parser.Records);
        }

        public void ReLoad()
        {
            _parser.Parse();
            _dataSet.Irises = new List<Iris>(_parser.Records);
        }
    }
}