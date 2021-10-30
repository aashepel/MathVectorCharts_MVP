using MathVectorCharts_MVP.Services;
using MathVectorCharts_MVP.Views;
using System;

namespace MathVectorCharts_MVP.Presenters
{
    public class IrisesAnalysisPresenter : IPresenter
    {
        private readonly IIrisesAnalysisView _view;
        private readonly IChartsService _service;
        public event Action<string> ChangeFilePath;

        public IrisesAnalysisPresenter(IIrisesAnalysisView view, IChartsService model)
        {
            _view = view;
            _service = model;

            _view.OpenFile += () => ShowFileSelector();
            _view.RenderCharts += () => RenderAllCharts();
            _view.OpenNotePad += () => OpenFileViaNotePad();
            _view.ReOpenFile += () => ReLoadCharts();
            _view.ClearCharts += () => ClearAllCharts();
        }

        public string FilePath
        {
            get
            {
                return _service.FilePath;
            }
            set
            {
                ChangeFilePath.Invoke(value);
                _service.FilePath = value;
            }
        }
        
        public void RenderAllCharts()
        {
            try
            {
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
                _view.ShowRenderMessageBox();
            }
        }

        public void ShowRenderMessageBox()
        {
            _view.ShowRenderMessageBox();
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
                _view.ShowRenderMessageBox();
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
    }
}
