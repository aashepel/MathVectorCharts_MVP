namespace MathVectorCharts_MVP.Views
{
    partial class ClusterAnalysisView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnRenderChart = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelCntClusters = new System.Windows.Forms.Label();
            this.comboBoxAlgClasterization = new System.Windows.Forms.ComboBox();
            this.labelAlgClusterization = new System.Windows.Forms.Label();
            this.btnOpenFileViaNotepad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(127, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1262, 601);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(109, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Загрузить файл";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // btnRenderChart
            // 
            this.btnRenderChart.Location = new System.Drawing.Point(12, 560);
            this.btnRenderChart.Name = "btnRenderChart";
            this.btnRenderChart.Size = new System.Drawing.Size(109, 53);
            this.btnRenderChart.TabIndex = 2;
            this.btnRenderChart.Text = "Отрисовать график";
            this.btnRenderChart.UseVisualStyleBackColor = true;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(124, 626);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(127, 13);
            this.lblFilePath.TabIndex = 3;
            this.lblFilePath.Text = "Путь к файлу не указан";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(2, 112);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(109, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelCntClusters
            // 
            this.labelCntClusters.AutoSize = true;
            this.labelCntClusters.Location = new System.Drawing.Point(-1, 96);
            this.labelCntClusters.Name = "labelCntClusters";
            this.labelCntClusters.Size = new System.Drawing.Size(122, 13);
            this.labelCntClusters.TabIndex = 5;
            this.labelCntClusters.Text = "Количество кластеров";
            // 
            // comboBoxAlgClasterization
            // 
            this.comboBoxAlgClasterization.FormattingEnabled = true;
            this.comboBoxAlgClasterization.Items.AddRange(new object[] {
            "Kmeans"});
            this.comboBoxAlgClasterization.Location = new System.Drawing.Point(2, 168);
            this.comboBoxAlgClasterization.Name = "comboBoxAlgClasterization";
            this.comboBoxAlgClasterization.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAlgClasterization.TabIndex = 6;
            // 
            // labelAlgClusterization
            // 
            this.labelAlgClusterization.AutoSize = true;
            this.labelAlgClusterization.Location = new System.Drawing.Point(-1, 152);
            this.labelAlgClusterization.Name = "labelAlgClusterization";
            this.labelAlgClusterization.Size = new System.Drawing.Size(119, 13);
            this.labelAlgClusterization.TabIndex = 7;
            this.labelAlgClusterization.Text = "Метод кластеризации";
            // 
            // btnOpenFileViaNotepad
            // 
            this.btnOpenFileViaNotepad.Location = new System.Drawing.Point(12, 507);
            this.btnOpenFileViaNotepad.Name = "btnOpenFileViaNotepad";
            this.btnOpenFileViaNotepad.Size = new System.Drawing.Size(109, 47);
            this.btnOpenFileViaNotepad.TabIndex = 8;
            this.btnOpenFileViaNotepad.Text = "Открыть файл в блокноте";
            this.btnOpenFileViaNotepad.UseVisualStyleBackColor = true;
            // 
            // ClusterAnalysisView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 648);
            this.Controls.Add(this.btnOpenFileViaNotepad);
            this.Controls.Add(this.labelAlgClusterization);
            this.Controls.Add(this.comboBoxAlgClasterization);
            this.Controls.Add(this.labelCntClusters);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnRenderChart);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.chart1);
            this.Name = "ClusterAnalysisView";
            this.Text = "ClusterAnalysisView";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnRenderChart;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelCntClusters;
        private System.Windows.Forms.ComboBox comboBoxAlgClasterization;
        private System.Windows.Forms.Label labelAlgClusterization;
        private System.Windows.Forms.Button btnOpenFileViaNotepad;
    }
}