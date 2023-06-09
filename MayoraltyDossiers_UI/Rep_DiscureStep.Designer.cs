namespace MayoraltyDossiers_UI
{
    partial class Rep_DiscureStep
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
            this.mayoralty_FilesDataSet1 = new MayoraltyDossiers_UI.Mayoralty_FilesDataSet();
            this.discureStep_VwTableAdapter1 = new MayoraltyDossiers_UI.Mayoralty_FilesDataSetTableAdapters.DiscureStep_VwTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mayoralty_FilesDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 6;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1});
            this.PageHeader.Height = 585;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrChart1
            // 
            this.xrChart1.AppearanceName = "Light";
            this.xrChart1.DataAdapter = this.discureStep_VwTableAdapter1;
            this.xrChart1.DataSource = this.mayoralty_FilesDataSet1;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Legend.Visible = false;
            this.xrChart1.Location = new System.Drawing.Point(15, 53);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.PaletteBaseColorNumber = 1;
            this.xrChart1.PaletteName = "Civic";
            this.xrChart1.ParentStyleUsing.UseBackColor = false;
            this.xrChart1.ParentStyleUsing.UseBorderColor = false;
            this.xrChart1.ParentStyleUsing.UseBorders = false;
            series1.Name = "Series 1";
            series1.ArgumentDataMember = "DiscureStep_Vw.DiscourUse_Step";
            series1.ValueDataMembersSerializable = "DiscureStep_Vw.DiscourUse_Count";
            series1.PointOptionsTypeName = "PointOptions";
            series2.Name = "Series 2";
            series2.PointOptionsTypeName = "PointOptions";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.xrChart1.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.xrChart1.Size = new System.Drawing.Size(942, 517);
            chartTitle1.Text = "تعداد جلوگیری ها بر اساس مراحل کاری";
            this.xrChart1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // mayoralty_FilesDataSet1
            // 
            this.mayoralty_FilesDataSet1.DataSetName = "Mayoralty_FilesDataSet";
            this.mayoralty_FilesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // discureStep_VwTableAdapter1
            // 
            this.discureStep_VwTableAdapter1.ClearBeforeFill = true;
            // 
            // Rep_DiscureStep
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
        public DevExpress.XtraReports.UI.XRChart xrChart1;
        private MayoraltyDossiers_UI.Mayoralty_FilesDataSetTableAdapters.DiscureStep_VwTableAdapter discureStep_VwTableAdapter1;
        private Mayoralty_FilesDataSet mayoralty_FilesDataSet1;
    }
}
