using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace MathVectorCharts_MVP.UI.ChartsUI
{
    public class ChartsPresenter
    {
        private readonly IChartsView _view;
        private readonly IChartsService _service;

        public ChartsPresenter(IChartsView view, IChartsService model)
        {
            _view = view;
            _service = model;
        }

        public void LoadCharts()
        {
            _view.RenderBarCharts(_service.LoadBarChartsInfo());
            _view.RenderPieChart(_service.LoadPieChartInfo());
        }

        public void LoadIrises(string filePath)
        {
            _service.LoadIrises(filePath);
        }

        public void ClearAllCharts()
        {
            _view.ClearAllCharts();
        }
    }
}
