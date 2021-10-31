using Clustering;
using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathVectorCharts_MVP.Views
{
    public partial class ClusterAnalysisView : Form
    {
        public ClusterAnalysisView()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            const string filePath = @"C:\Users\Alexandr\Documents\k-means_DataSet____1.txt";
            List<string> linesFile = File.ReadAllLines(filePath).ToList();
            List<MathVector> points = new List<MathVector>();
            foreach (string line in linesFile)
            {
                IEnumerable<double> values = line.Split(' ').Where(p => p.Length != 0).Select(p => double.Parse(p));
                points.Add(new MathVector(values.ToArray()));
            }

            int countClusters = int.Parse(textBox1.Text);
            int seed = int.Parse(textBox2.Text);
            KmeansClusterer clusterer = new KmeansClusterer(points, countClusters, seed);
            var clusters = clusterer.RunClustering();


            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("Area 1");

            foreach (var cluster in clusters)
            {
                var addedSeries = chart1.Series.Add($"Cluster {cluster.Key}");
                addedSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                addedSeries.MarkerSize = 5;
                addedSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                foreach(var item in cluster.Value)
                {
                    addedSeries.Points.AddXY(item[0], item[1]);
                }
            }

            var centersSeries = chart1.Series.Add("Centers");
            centersSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            centersSeries.MarkerSize = 20;
            centersSeries.Color = Color.Black;
            centersSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            foreach (var point in clusterer.Clusters)
            {
                centersSeries.Points.AddXY(point.ClusterCenter[0], point.ClusterCenter[1]);
            }
        }
    }
}
