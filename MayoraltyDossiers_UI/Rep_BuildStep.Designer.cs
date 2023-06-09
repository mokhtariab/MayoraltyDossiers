namespace MayoraltyDossiers_UI
{
    partial class Rep_BuildStep
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
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.buildStep_VwTableAdapter1 = new MayoraltyDossiers_UI.Mayoralty_FilesDataSetTableAdapters.BuildStep_VwTableAdapter();
            this.mayoralty_FilesDataSet = new MayoraltyDossiers_UI.Mayoralty_FilesDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mayoralty_FilesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 0;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1});
            this.PageHeader.Height = 719;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrChart1
            // 
            this.xrChart1.DataAdapter = this.buildStep_VwTableAdapter1;
            this.xrChart1.DataSource = this.mayoralty_FilesDataSet;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Location = new System.Drawing.Point(15, 23);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.ParentStyleUsing.UseBackColor = false;
            this.xrChart1.ParentStyleUsing.UseBorderColor = false;
            this.xrChart1.ParentStyleUsing.UseBorders = false;
            series1.Name = "Series 1";
            series1.ArgumentDataMember = "BuildStep_Vw.StepUsetxt";
            series1.ValueDataMembersSerializable = "BuildStep_Vw.CountStep";
            series1.ShowInLegend = false;
            series1.PointOptionsTypeName = "PointOptions";
            series2.Name = "Series 2";
            series2.ShowInLegend = false;
            series2.PointOptionsTypeName = "PointOptions";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.xrChart1.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.xrChart1.Size = new System.Drawing.Size(1034, 679);
            chartTitle1.Text = "تعداد ساختمانهای در حال ساخت براساس مراحل کاری";
            this.xrChart1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // buildStep_VwTableAdapter1
            // 
            this.buildStep_VwTableAdapter1.ClearBeforeFill = true;
            // 
            // mayoralty_FilesDataSet
            // 
            this.mayoralty_FilesDataSet.DataSetName = "Mayoralty_FilesDataSet";
            this.mayoralty_FilesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Rep_BuildStep
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mayoralty_FilesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private Mayoralty_FilesDataSet mayoralty_FilesDataSet;
        private MayoraltyDossiers_UI.Mayoralty_FilesDataSetTableAdapters.BuildStep_VwTableAdapter buildStep_VwTableAdapter1;
        public DevExpress.XtraReports.UI.XRChart xrChart1;
    }
}
