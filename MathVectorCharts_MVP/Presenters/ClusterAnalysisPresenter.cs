using MathVectorCharts_MVP.Services;
using MathVectorCharts_MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Presenters
{
    public class ClusterAnalysisPresenter : IPresenter
    {
        private IClusterAnalysisView _view;
        private IClusteringService _service;
        private string _filePath;
        private int _countClusters = 1;
        private ClusteringAlgorithmType _clusteringAlgorithmType = ClusteringAlgorithmType.Kmeans;
        public ClusterAnalysisPresenter(IClusterAnalysisView view, IClusteringService service)
        {
            _view = view;
            _service = service;

            _view.OpenFileClick += () => ShowFileSelector();
            _view.RenderChartClick += () => RenderChart();
            _view.OpenNotePadClick += () => OpenFileViaNotePad();
            _view.ClearChartsClick += () => ClearChart();
            _view.ChangeFilePath += (filePath) => FilePath = filePath;
            _view.ChangeCountClusters += (countClusters) => _countClusters = countClusters;
            _view.ClusteringAlgorithmTypeChanged += (type) => _clusteringAlgorithmType = type;
        }
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                _view.SetLabelFilePath(value);
            }
        }
        public void RenderChart()
        {
            try
            {
                ClearChart();
                var pointsClusters = _service.LoadPointClustering(_filePath, _clusteringAlgorithmType, _countClusters);
                _view.RenderChart(pointsClusters);
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
        }

        public void ShowFileSelector()
        {
            if (_view.ShowFileSelector() == System.Windows.Forms.DialogResult.OK)
            {
                ShowRenderMessageBox();
            }
        }

        public void ShowRenderMessageBox()
        {
            if (_view.ShowRenderMessageBox() == System.Windows.Forms.DialogResult.Yes)
            {
                RenderChart();
            }
        }

        public void OpenFileViaNotePad()
        {
            try
            {
                _view.OpenFileViaNotePad(_filePath);
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
        }

        public void ClearChart()
        {
            _view.ClearChart();
        }
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
