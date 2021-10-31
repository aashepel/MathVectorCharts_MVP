using MathVectorCharts_MVP.Presenters;
using MathVectorCharts_MVP.Services;
using MathVectorCharts_MVP.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MathVectorCharts_MVP.Views
{
    public partial class IrisesAnalysisView : Form, IIrisesAnalysisView
    {
        List<Chart> _barCharts = new List<Chart>();

        public event Action OpenFile;
        public event Action RenderCharts;
        public event Action OpenNotePad;
        public event Action ReOpenFile;
        public event Action ClearCharts;
        public event Action<string> ChangeFilePath;
        public event Action OpenClusterView;

        public IrisesAnalysisView()
        {
            InitializeComponent();

            btnOpenFile.Click += (sender, args) => OpenFile?.Invoke();
            btnRenderCharts.Click += (sender, args) => RenderCharts?.Invoke();
            btnOpenNotePad.Click += (sender, args) => OpenNotePad?.Invoke();
            btnReOpenFile.Click += (sender, args) => ReOpenFile?.Invoke();
            btnClearCharts.Click += (sender, args) => ClearCharts?.Invoke();
            btnOpenClusterView.Click += (sender, args) => OpenClusterView?.Invoke();

            _barCharts.Add(chartBar_1);
            _barCharts.Add(chartBar_2);
            _barCharts.Add(chartBar_3);
            _barCharts.Add(chartBar_4);
        }

        void IIrisesAnalysisView.RenderBarCharts(List<BarChartInfo> chartsInfo)
        {
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
                    var addedSeries = _barCharts[i].Series.Add(chartsInfo[i].Values[j].TitleBar);
                    addedSeries.Points.Add(chartsInfo[i].Values[j].Value);
                    addedSeries.IsValueShownAsLabel = true;
                    addedSeries.Label = chartsInfo[i].Values[j].Value.ToString();
                    addedSeries["DrawingStyle"] = "Cylinder";
                    _barCharts[i].Legends.Add(chartsInfo[i].Values[j].TitleBar);
                }
            }
        }

        void IIrisesAnalysisView.RenderPieChart(PieChartInfo pieChartInfo)
        {
            chartPie_1.ChartAreas.Clear();
            chartPie_1.ChartAreas.Add("ChartArea");
            chartPie_1.ChartAreas[0].Area3DStyle.Enable3D = true;
            var addedSeries = chartPie_1.Series.Add("Series_1");
            addedSeries.ChartType = SeriesChartType.Pie;
            foreach(var value in pieChartInfo.Values)
            {
                int indexAddedPoints = addedSeries.Points.AddY(value.Value);
                chartPie_1.Legends.Add(value.TitlePie);
                addedSeries.Points[indexAddedPoints].Label = "#VALY (#PERCENT)";
                addedSeries.Points[indexAddedPoints].LegendText = value.TitlePie;
            }
        }
        DialogResult IIrisesAnalysisView.ShowFileSelector()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Файлы csv|*.csv";
            openFileDialog.InitialDirectory = Application.StartupPath;
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ChangeFilePath?.Invoke(openFileDialog.FileName);
                btnRenderCharts.Enabled = true;
            }
            return dialogResult;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void IIrisesAnalysisView.ClearAllCharts()
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

        void IIrisesAnalysisView.OpenFileViaNotePad(string filePath)
        {
            Process.Start("C:\\Windows\\System32\\notepad.exe", filePath);
        }

        DialogResult IIrisesAnalysisView.ShowRenderMessageBox()
        {
            var resultDialog = MessageBox.Show("Построить графики?", "Диалог", MessageBoxButtons.YesNo);
            return resultDialog;
        }
        void IIrisesAnalysisView.SetLabelFilePath(string filePath)
        {
            lblFilePath.Text = filePath;
        }

        void IView.Show()
        {
            this.Show();
        }

        void IView.Close()
        {
            this.Close();
        }
    }
}
