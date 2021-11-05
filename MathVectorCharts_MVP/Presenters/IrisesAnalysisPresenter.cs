using MathVectorCharts_MVP.Services;
using MathVectorCharts_MVP.Views;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Presenters
{
    public class IrisesAnalysisPresenter : IPresenter
    {
        private readonly IIrisesAnalysisView _view;
        private readonly IChartsService _service;
        private string _filePath;

        public IrisesAnalysisPresenter(IIrisesAnalysisView view, IChartsService service)
        {
            _view = view;
            _service = service;

            // Подписываемся на события view
            _view.OpenFileClick += () => OnOpenFileClicked();
            _view.RenderChartsClick += () => OnRenderChartsClicked();
            _view.OpenNotePadClick += () => OnOpenFileViaNotePadClicked();
            _view.ClearChartsClick += () => OnClearChartsClicked();
            _view.OpenClusterViewClick += () => OnOpenClusterViewClicked();
            _view.ChangeFilePath += filePath => OnFilePathChanged(filePath);
        }

        /// <summary>
        /// Метод вызывающийся при измненении пути к файлу
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void OnFilePathChanged(string filePath)
        {
            _filePath = filePath;
            // Выставляем путь к файлу в label во view
            _view.SetLabelFilePath(filePath);
        }

        /// <summary>
        /// Метод, вызывающийся при нажатии на кнопку "Кластерный анализ"
        /// </summary>
        public void OnOpenClusterViewClicked()
        {
            IClusterAnalysisView view = new ClusterAnalysisView(); // Создаем view
            IClusteringService service = new ClusteringService(); // Создаем сервис кластеризации
            ClusterAnalysisPresenter _clusterAnalysisPresenter = new ClusterAnalysisPresenter(view, service); // Делаем привязку
            view.Show();
        }

        /// <summary>
        /// Метод, вызывающийся при нажатии на кнопку очистки диаграмм
        /// </summary>
        public void OnClearChartsClicked()
        {
            _view.ClearAllCharts();
        }

        /// <summary>
        /// Метод, вызывающийся при нажатии на кнопку "Пострить диаграммы"
        /// </summary>
        public void OnRenderChartsClicked()
        {
            try
            {
                _service.LoadIrises(_filePath);
                _view.ClearAllCharts();
                _view.RenderBarCharts(_service.LoadBarChartsInfo());
                _view.RenderPieChart(_service.LoadPieChartInfo());
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
            // Если в результате показа окна выбора файла, файл был выбран
            if (_view.ShowFileSelector() == System.Windows.Forms.DialogResult.OK)
            {
                // Если в результате показа диалога был выбран ответ OK, вызываем метод отвечающий за построение диаграмм
                if (_view.ShowDialogYesNo("Построить графики?") == System.Windows.Forms.DialogResult.Yes)
                {
                    // Метод отвечающий за построение диаграмм
                    OnRenderChartsClicked();
                }
            }
        }

        /// <summary>
        /// Метод, вызывающийся при нажатии на кнопку "Открыть файл в блокноте"
        /// </summary>
        public void OnOpenFileViaNotePadClicked()
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

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
