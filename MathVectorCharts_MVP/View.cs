using MathVectorCharts_MVP.Models;
using MathVectorCharts_MVP.UI;
using MathVectorCharts_MVP.UI.ChartsUI;
using MathVectorCharts_MVP.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MathVectorCharts_MVP
{
    public partial class View : Form, IChartsView
    {
        private ChartsPresenter _presenter;
        List<Chart> _barCharts = new List<Chart>();
        public View()
        {
            InitializeComponent();
            _presenter = new ChartsPresenter(this, new ChartsService());
            _barCharts.Add(chartBar_1);
            _barCharts.Add(chartBar_2);
            _barCharts.Add(chartBar_3);
            _barCharts.Add(chartBar_4);
        }

        void IChartsView.RenderBarCharts(List<BarChartInfo> chartsInfo)
        {
            _presenter.ClearAllCharts();
            for (int i = 0; i < _barCharts.Count; i++)
            {
                _barCharts[i].Titles.Add(chartsInfo[i].Title);
                _barCharts[i].ChartAreas.Clear();
                _barCharts[i].ChartAreas.Add("ChartArea");
                _barCharts[i].ChartAreas[0].AxisX.LabelStyle.Enabled = chartsInfo[i].AxisXLabelShow;
                _barCharts[i].ChartAreas[0].Area3DStyle.Enable3D = true;
                _barCharts[i].ChartAreas[0].Area3DStyle.Rotation = 50;
                for (int j = 0; j < chartsInfo[i].Values.Count; j++)
                {
                    var addedSeries = _barCharts[i].Series.Add(chartsInfo[i].Values[j].Key);
                    addedSeries.Points.Add(chartsInfo[i].Values[j].Value);
                    addedSeries.IsValueShownAsLabel = true;
                    addedSeries.Label = chartsInfo[i].Values[j].Value.ToString();
                    addedSeries["DrawingStyle"] = "Cylinder";
                    _barCharts[i].Legends.Add(chartsInfo[i].Values[j].Key);
                }
            }
        }

        void IChartsView.RenderPieChart(PieChartInfo pieChartInfo)
        {
            chartPie_1.ChartAreas.Clear();
            chartPie_1.ChartAreas.Add("ChartArea");
            chartPie_1.ChartAreas[0].Area3DStyle.Enable3D = true;
            var addedSeries = chartPie_1.Series.Add("Series_1");
            addedSeries.ChartType = SeriesChartType.Pie;
            foreach(var value in pieChartInfo.Values)
            {
                int indexAddedPoints = addedSeries.Points.AddY(value.Value);
                chartPie_1.Legends.Add(value.Key);
                addedSeries.Points[indexAddedPoints].Label = "#VALY (#PERCENT)";
                addedSeries.Points[indexAddedPoints].LegendText = value.Key;
            }
        }

        private void btnOpenFile_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Файлы csv|*.csv";
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _presenter.LoadIrises(openFileDialog.FileName);
                    btnRenderCharts.Enabled = true;
                    var resultDialog = MessageBox.Show("Построить графики?", "Диалог", MessageBoxButtons.YesNo);
                    if (resultDialog == DialogResult.Yes)
                    {
                        _presenter.LoadCharts();
                    }
                }
                catch (Exception ex)
                {
                    btnRenderCharts.Enabled = false;
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRenderCharts_Click(object sender, EventArgs e)
        {
            _presenter.LoadCharts();
        }

        void IChartsView.ClearAllCharts()
        {
            chartPie_1.Series.Clear();
            chartPie_1.Legends.Clear();
            chartPie_1.Titles.Clear();
            chartPie_1.ChartAreas.Clear();
            foreach(var chart in _barCharts)
            {
                chart.Series.Clear();
                chart.Legends.Clear();
                chart.Titles.Clear();
                chart.ChartAreas.Clear();
            }
        }

        private void btnClearCharts_Click(object sender, EventArgs e)
        {
            _presenter.ClearAllCharts();
        }
    }
}
