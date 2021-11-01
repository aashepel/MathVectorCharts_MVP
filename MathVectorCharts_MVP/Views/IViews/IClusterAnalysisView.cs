using Clustering;
using MathVectorCharts_MVP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathVectorCharts_MVP.Views
{
    public interface IClusterAnalysisView : IView
    {
        void RenderChart(PointClusters clusters);
        void SetLabelFilePath(string filePath);
        void OpenFileViaNotePad(string filePath);
        DialogResult ShowFileSelector();
        DialogResult ShowRenderMessageBox();
        void ClearChart();
        event Action OpenFileClick;
        event Action RenderChartClick;
        event Action OpenNotePadClick;
        event Action ClearChartsClick;
        event Action<string> ChangeFilePath;
        event Action<int> ChangeCountClusters;
        event Action<ClusteringAlgorithmType> ClusteringAlgorithmTypeChanged;
    }
}
