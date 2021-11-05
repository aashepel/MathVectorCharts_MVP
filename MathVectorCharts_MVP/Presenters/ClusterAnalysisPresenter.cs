using Clustering;
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
    /// <summary>
    /// Презентер для формы кластерного анализа
    /// </summary>
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

            // Подписываемся на события view (можно вынести в отдельный метод)
            _view.OpenFileClick += () => OnOpenFileClicked();
            _view.RenderChartClick += () => OnRenderChartClicked();
            _view.OpenNotePadClick += () => OnOpenFileViaNotePad();
            _view.ChangeFilePath += (filePath) => OnFilePathChanged(filePath);
            _view.ChangeCountClusters += (countClusters) => OnCountClustersChanged(countClusters);
            _view.ClusteringAlgorithmTypeChanged += (type) => OnClusteringAlgorithmTypeChanged(type);
        }
        
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
            }
        }

        /// <summary>
        /// Метод, вызывающийся при изменении пути к файлу
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void OnFilePathChanged(string filePath)
        {
            _filePath = filePath;
            _view.SetLabelFilePath(filePath);
        }

        /// <summary>
        /// Метод, вызывающийся при изменении числа кластеров
        /// </summary>
        /// <param name="count"></param>
        public void OnCountClustersChanged(int count)
        {
            _countClusters = count;
        }

        /// <summary>
        /// Метод, вызывающийся при изменении алгоритма кластеризации
        /// </summary>
        /// <param name="type"></param>
        public void OnClusteringAlgorithmTypeChanged(ClusteringAlgorithmType type)
        {
            _clusteringAlgorithmType = type;
        }

        /// <summary>
        /// Метод, вызвающийся при нажатии на кнопку "Отрисовать диаграммы"
        /// </summary>
        public void OnRenderChartClicked()
        {
            try
            {
                _view.ClearChart();
                PointClusters pointsClusters = _service.LoadPointClustering(_filePath, _clusteringAlgorithmType, _countClusters);
                _view.RenderChart(pointsClusters);
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Метод, вызывающийся при нажатии на кнопку "Открыть файл"
        /// </summary>
        public void OnOpenFileClicked()
        {
            var resultFileDialog = _view.ShowFileSelector();
            if (resultFileDialog == System.Windows.Forms.DialogResult.OK)
            {
                if (_view.ShowDialogYesNo("Построить графики?") == System.Windows.Forms.DialogResult.Yes)
                {
                    OnRenderChartClicked();
                }    
            }
        }

        /// <summary>
        /// Метод, вызвающийся при нажатии на кнопку "Открыть файл в блокноте"
        /// </summary>
        public void OnOpenFileViaNotePad()
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
