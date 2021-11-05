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
        void SetLabelFilePath(string filePath);
        void OpenFileViaNotePad(string filePath);
        DialogResult ShowFileSelector();
        DialogResult ShowDialogYesNo(string text);
        void ClearAllCharts();
        event Action OpenFileClick;
        event Action RenderChartsClick;
        event Action OpenNotePadClick;
        event Action ClearChartsClick;
        event Action<string> ChangeFilePath;
        event Action OpenClusterViewClick;
    }
}
