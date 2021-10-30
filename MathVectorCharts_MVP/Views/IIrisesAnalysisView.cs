using MathVectorCharts_MVP.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MathVectorCharts_MVP.Views
{
    public interface IIrisesAnalysisView : IView
    {
        void RenderBarCharts(List<BarChartInfo> chartsInfo);
        void RenderPieChart(PieChartInfo pieChartInfo);
        void OpenFileViaNotePad(string filePath);
        DialogResult ShowFileSelector();
        void ShowRenderMessageBox();
        void ClearAllCharts();
        event Action OpenFile;
        event Action RenderCharts;
        event Action OpenNotePad;
        event Action ReOpenFile;
        event Action ClearCharts;
    }
}
