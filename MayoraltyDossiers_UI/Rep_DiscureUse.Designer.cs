namespace MayoraltyDossiers_UI
{
    partial class Rep_DiscureUse
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.ChartTitle chartTitle3 = new DevExpress.XtraCharts.ChartTitle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.discureUse_VwTableAdapter1 = new MayoraltyDossiers_UI.Mayoralty_FilesDataSetTableAdapters.DiscureUse_VwTableAdapter();
            this.mayoralty_FilesDataSet1 = new MayoraltyDossiers_UI.Mayoralty_FilesDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mayoralty_FilesDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 2;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1});
            this.PageHeader.Height = 572;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrChart1
            // 
            this.xrChart1.DataAdapter = this.discureUse_VwTableAdapter1;
            this.xrChart1.DataSource = this.mayoralty_FilesDataSet1;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Legend.Visible = false;
            this.xrChart1.Location = new System.Drawing.Point(15, 23);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.ParentStyleUsing.UseBackColor = false;
            this.xrChart1.ParentStyleUsing.UseBorderColor = false;
            this.xrChart1.ParentStyleUsing.UseBorders = false;
            series1.Name = "Series 1";
            series1.DataSource = this.mayoralty_FilesDataSet1;
            series1.ArgumentDataMember = "DiscureUse_Vw.DiscourUseText";
            series1.ValueDataMembersSerializable = "DiscureUse_Vw.DiscourUse";
            series1.PointOptionsTypeName = "PointOptions";
            series2.Name = "Series 2";
            series2.PointOptionsTypeName = "PointOptions";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.xrChart1.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.xrChart1.Size = new System.Drawing.Size(942, 520);
            chartTitle3.Text = "تعداد جلوگیری ها بر اساس حوزه صادرکننده";
            chartTitle3.TextColor = System.Drawing.Color.Maroon;
            this.xrChart1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle3});
            // 
            // discureUse_VwTableAdapter1
            // 
            this.discureUse_VwTableAdapter1.ClearBeforeFill = true;
            // 
            // mayoralty_FilesDataSet1
            // 
            this.mayoralty_FilesDataSet1.DataSetName = "Mayoralty_FilesDataSet";
            this.mayoralty_FilesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Rep_DiscureUse
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
            this.Landscape = true;
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mayoralty_FilesDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private MayoraltyDossiers_UI.Mayoralty_FilesDataSetTableAdapters.DiscureUse_VwTableAdapter discureUse_VwTableAdapter1;
        private Mayoralty_FilesDataSet mayoralty_FilesDataSet1;
        public DevExpress.XtraReports.UI.XRChart xrChart1;
    }
}
