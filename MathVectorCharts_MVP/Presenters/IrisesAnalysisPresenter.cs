﻿using MathVectorCharts_MVP.Services;
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

            _view.OpenFileClick += () => ShowFileSelector();
            _view.RenderChartsClick += () => RenderAllCharts();
            _view.OpenNotePadClick += () => OpenFileViaNotePad();
            _view.ReOpenFileClick += () => ReLoadCharts();
            _view.ClearChartsClick += () => _view.ClearAllCharts();
            _view.OpenClusterViewClick += () => OpenClusterView();
            _view.ChangeFilePath += filePath => FilePath = filePath;
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

        public void OpenClusterView()
        {
            IClusterAnalysisView view = new ClusterAnalysisView();
            IClusteringService service = new ClusteringService();
            ClusterAnalysisPresenter _clusterAnalysisPresenter = new ClusterAnalysisPresenter(view, service);
            view.Show();
        }

        public void RenderAllCharts()
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
                _view.OpenFileViaNotePad(_filePath);
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
                RenderAllCharts();
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
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
