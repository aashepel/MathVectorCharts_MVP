using MathVectorCharts_MVP.Services;
using MathVectorCharts_MVP.Views;
using System;

namespace MathVectorCharts_MVP.Presenters
{
    public class IrisesAnalysisPresenter : IPresenter
    {
        private readonly IIrisesAnalysisView _view;
        private readonly IChartsService _service;
        private ClusterAnalysisView _clusterAnalysisView;

        public IrisesAnalysisPresenter(IIrisesAnalysisView view, IChartsService service)
        {
            _view = view;
            _service = service;

            _view.OpenFile += () => ShowFileSelector();
            _view.RenderCharts += () => RenderAllCharts();
            _view.OpenNotePad += () => OpenFileViaNotePad();
            _view.ReOpenFile += () => ReLoadCharts();
            _view.ClearCharts += () => ClearAllCharts();
            _view.OpenClusterView += () => OpenClusterView();
            _view.ChangeFilePath += filePath => FilePath = filePath;
        }

        public string FilePath
        {
            get
            {
                return _service.FilePath;
            }
            set
            {
                _service.FilePath = value;
                _view.SetLabelFilePath(value);
            }
        }

        public void OpenClusterView()
        {
            _clusterAnalysisView = new ClusterAnalysisView();
            _clusterAnalysisView.Show();
        }
        
        public void RenderAllCharts()
        {
            try
            {
                ClearAllCharts();
                _view.RenderBarCharts(_service.LoadBarChartsInfo());
                _view.RenderPieChart(_service.LoadPieChartInfo());
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
                RenderAllCharts();
            }
        }

        public void OpenFileViaNotePad()
        {
            try
            {
                _view.OpenFileViaNotePad(_service.FilePath);
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
        }

        public void ReLoadCharts()
        {
            try
            {
                _service.ReLoad();
                ShowRenderMessageBox();
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
        }

        public void ClearAllCharts()
        {
            _view.ClearAllCharts();
        }

        public void Show()
        {
            _view.Show();
        }

        public void Close()
        {
            _view.Close();
        }
    }
}
