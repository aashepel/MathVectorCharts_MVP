﻿namespace MathVectorCharts_MVP.Views
{
    partial class IrisesAnalysisView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnRenderCharts = new System.Windows.Forms.Button();
            this.chartBar_1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBar_2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBar_3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBar_4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnClearCharts = new System.Windows.Forms.Button();
            this.chartPie_1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnReOpenFile = new System.Windows.Forms.Button();
            this.btnOpenNotePad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie_1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // btnRenderCharts
            // 
            this.btnRenderCharts.Enabled = false;
            this.btnRenderCharts.Location = new System.Drawing.Point(501, 12);
            this.btnRenderCharts.Name = "btnRenderCharts";
            this.btnRenderCharts.Size = new System.Drawing.Size(117, 23);
            this.btnRenderCharts.TabIndex = 1;
            this.btnRenderCharts.Text = "Render Charts";
            this.btnRenderCharts.UseVisualStyleBackColor = true;
            // 
            // chartBar_1
            // 
            chartArea6.Name = "ChartArea1";
            this.chartBar_1.ChartAreas.Add(chartArea6);
            this.chartBar_1.Location = new System.Drawing.Point(12, 41);
            this.chartBar_1.Name = "chartBar_1";
            this.chartBar_1.Size = new System.Drawing.Size(300, 300);
            this.chartBar_1.TabIndex = 2;
            this.chartBar_1.Text = "chart1";
            // 
            // chartBar_2
            // 
            chartArea7.Name = "ChartArea1";
            this.chartBar_2.ChartAreas.Add(chartArea7);
            this.chartBar_2.Location = new System.Drawing.Point(318, 41);
            this.chartBar_2.Name = "chartBar_2";
            this.chartBar_2.Size = new System.Drawing.Size(300, 300);
            this.chartBar_2.TabIndex = 3;
            this.chartBar_2.Text = "chart1";
            // 
            // chartBar_3
            // 
            chartArea8.Name = "ChartArea1";
            this.chartBar_3.ChartAreas.Add(chartArea8);
            this.chartBar_3.Location = new System.Drawing.Point(624, 41);
            this.chartBar_3.Name = "chartBar_3";
            this.chartBar_3.Size = new System.Drawing.Size(300, 300);
            this.chartBar_3.TabIndex = 4;
            this.chartBar_3.Text = "chart2";
            // 
            // chartBar_4
            // 
            chartArea9.Name = "ChartArea1";
            this.chartBar_4.ChartAreas.Add(chartArea9);
            this.chartBar_4.Location = new System.Drawing.Point(930, 41);
            this.chartBar_4.Name = "chartBar_4";
            this.chartBar_4.Size = new System.Drawing.Size(300, 300);
            this.chartBar_4.TabIndex = 5;
            this.chartBar_4.Text = "chart3";
            // 
            // btnClearCharts
            // 
            this.btnClearCharts.Location = new System.Drawing.Point(624, 12);
            this.btnClearCharts.Name = "btnClearCharts";
            this.btnClearCharts.Size = new System.Drawing.Size(117, 23);
            this.btnClearCharts.TabIndex = 6;
            this.btnClearCharts.Text = "Clear Charts";
            this.btnClearCharts.UseVisualStyleBackColor = true;
            // 
            // chartPie_1
            // 
            chartArea10.Name = "ChartArea1";
            this.chartPie_1.ChartAreas.Add(chartArea10);
            this.chartPie_1.Location = new System.Drawing.Point(12, 347);
            this.chartPie_1.Name = "chartPie_1";
            this.chartPie_1.Size = new System.Drawing.Size(606, 300);
            this.chartPie_1.TabIndex = 7;
            this.chartPie_1.Text = "chart3";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(625, 348);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(84, 13);
            this.lblFilePath.TabIndex = 8;
            this.lblFilePath.Text = "Путь не указан";
            // 
            // btnReOpenFile
            // 
            this.btnReOpenFile.Location = new System.Drawing.Point(93, 12);
            this.btnReOpenFile.Name = "btnReOpenFile";
            this.btnReOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnReOpenFile.TabIndex = 9;
            this.btnReOpenFile.Text = "ReOpen File";
            this.btnReOpenFile.UseVisualStyleBackColor = true;
            // 
            // btnOpenNotePad
            // 
            this.btnOpenNotePad.Location = new System.Drawing.Point(1082, 12);
            this.btnOpenNotePad.Name = "btnOpenNotePad";
            this.btnOpenNotePad.Size = new System.Drawing.Size(148, 23);
            this.btnOpenNotePad.TabIndex = 10;
            this.btnOpenNotePad.Text = "Open File via NotePad";
            this.btnOpenNotePad.UseVisualStyleBackColor = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1240, 663);
            this.Controls.Add(this.btnOpenNotePad);
            this.Controls.Add(this.btnReOpenFile);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.chartPie_1);
            this.Controls.Add(this.btnClearCharts);
            this.Controls.Add(this.chartBar_4);
            this.Controls.Add(this.chartBar_3);
            this.Controls.Add(this.chartBar_2);
            this.Controls.Add(this.chartBar_1);
            this.Controls.Add(this.btnRenderCharts);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "View";
            this.Text = "IrisesAnalysis";
            ((System.ComponentModel.ISupportInitialize)(this.chartBar_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnRenderCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar_1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar_2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar_3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar_4;
        private System.Windows.Forms.Button btnClearCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie_1;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnReOpenFile;
        private System.Windows.Forms.Button btnOpenNotePad;
    }
}
