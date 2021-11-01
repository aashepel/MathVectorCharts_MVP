using Clustering;
using LinearAlgebra;
using MathVectorCharts_MVP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathVectorCharts_MVP.Views
{
    public partial class ClusterAnalysisView : Form, IClusterAnalysisView
    {
        public event Action OpenFileClick;

        public event Action RenderChartClick;

        public event Action OpenNotePadClick;

        public event Action ClearChartsClick;

        public event Action<string> ChangeFilePath;

        public event Action<int> ChangeCountClusters;

        public event Action<ClusteringAlgorithmType> ClusteringAlgorithmTypeChanged;

        public ClusterAnalysisView()
        {
            InitializeComponent();

            comboBoxAlgClasterization.DataSource = Enum.GetValues(typeof(ClusteringAlgorithmType));
            comboBoxAlgClasterization.SelectedIndex = 0;


            btnOpenFile.Click += (s, args) => OpenFileClick?.Invoke();
            btnRenderChart.Click += (s, args) => RenderChartClick?.Invoke();
            btnOpenFileViaNotepad.Click += (s, args) => OpenNotePadClick?.Invoke();
            numericUpDown1.ValueChanged += (s, args) => ChangeCountClusters?.Invoke((int)numericUpDown1.Value);
            comboBoxAlgClasterization.TextChanged += (s, args) => ClusteringAlgorithmTypeChanged?.Invoke((ClusteringAlgorithmType)comboBoxAlgClasterization.SelectedItem);

        }

        void IClusterAnalysisView.ClearChart()
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("Area 1");
        }

        void IClusterAnalysisView.OpenFileViaNotePad(string filePath)
        {
            Process.Start("C:\\Windows\\System32\\notepad.exe", filePath);
        }

        void IClusterAnalysisView.RenderChart(PointClusters clusters)
        {
            int index = 0;
            foreach (var cluster in clusters.PC)
            {
                var addedSeries = chart1.Series.Add($"Cluster {index}");
                addedSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                addedSeries.MarkerSize = 5;
                addedSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                foreach (var item in cluster.Value)
                {
                    addedSeries.Points.AddXY(item[0], item[1]);
                }
                index++;
            }

            var centersSeries = chart1.Series.Add("Centers");
            centersSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            centersSeries.MarkerSize = 20;
            centersSeries.Color = Color.Black;
            centersSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            foreach (var cluster in clusters.PC)
            {
                centersSeries.Points.AddXY(cluster.Key[0], cluster.Key[1]);
            }

            //string messageBoxText = "";
            //foreach (var centroid in clusters.PC.Keys.OrderByDescending(p => p[0]).ThenByDescending(p => p[1]))
            //{
            //    messageBoxText += centroid + ", ";
            //}
            //MessageBox.Show(messageBoxText);
        }

        void IClusterAnalysisView.SetLabelFilePath(string filePath)
        {
            lblFilePath.Text = filePath;
        }

        void IView.ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        DialogResult IClusterAnalysisView.ShowFileSelector()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Application.StartupPath;
            var resultDialog = openFileDialog.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                ChangeFilePath?.Invoke(openFileDialog.FileName);
            }
            return resultDialog;
        }

        DialogResult IClusterAnalysisView.ShowRenderMessageBox()
        {
            var resultDialog = MessageBox.Show("Построить графики?", "Диалог", MessageBoxButtons.YesNo);
            return resultDialog;
        }
    }
}
