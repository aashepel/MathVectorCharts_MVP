using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace MathVectorCharts_MVP.UI
{
    public class ChartsPresenter
    {
        private readonly IChartsView _view;
        private readonly IChartsModel _model;

        public ChartsPresenter(IChartsView view, IChartsModel model)
        {
            _view = view;
            _model = model;
        }

        public void LoadCharts()
        {
            _view.RenderBarCharts(_model.LoadBarChartsInfo());
            _view.RenderPieChart(_model.LoadPieChartInfo());
        }

        public void LoadIrises(string filePath)
        {
            _model.LoadIrises(filePath);
        }

        public void ClearAllCharts()
        {
            _view.ClearAllCharts();
        }
    }
}
