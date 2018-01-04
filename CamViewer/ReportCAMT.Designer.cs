namespace CamViewer
{
    partial class ReportCAMT
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabelAcctIdIBAN = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelAmount = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageBreak = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrLabelImageName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPicturePaymentSlip = new DevExpress.XtraReports.UI.XRPictureBox();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabelAcctOwnrNm = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelAcctOwnrNm,
            this.xrLabelAcctIdIBAN,
            this.xrLabelAmount,
            this.xrPageBreak,
            this.xrLabelImageName,
            this.xrPicturePaymentSlip});
            this.Detail.HeightF = 720.2084F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrLabelAcctIdIBAN
            // 
            this.xrLabelAcctIdIBAN.LocationFloat = new DevExpress.Utils.PointFloat(0F, 647.8334F);
            this.xrLabelAcctIdIBAN.Name = "xrLabelAcctIdIBAN";
            this.xrLabelAcctIdIBAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelAcctIdIBAN.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.xrLabelAcctIdIBAN.StylePriority.UseTextAlignment = false;
            this.xrLabelAcctIdIBAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabelAmount
            // 
            this.xrLabelAmount.LocationFloat = new DevExpress.Utils.PointFloat(0F, 624.8334F);
            this.xrLabelAmount.Name = "xrLabelAmount";
            this.xrLabelAmount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelAmount.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.xrLabelAmount.StylePriority.UseTextAlignment = false;
            this.xrLabelAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageBreak
            // 
            this.xrPageBreak.LocationFloat = new DevExpress.Utils.PointFloat(0F, 708.2085F);
            this.xrPageBreak.Name = "xrPageBreak";
            // 
            // xrLabelImageName
            // 
            this.xrLabelImageName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 601.8334F);
            this.xrLabelImageName.Name = "xrLabelImageName";
            this.xrLabelImageName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelImageName.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.xrLabelImageName.StylePriority.UseTextAlignment = false;
            this.xrLabelImageName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPicturePaymentSlip
            // 
            this.xrPicturePaymentSlip.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.xrPicturePaymentSlip.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPicturePaymentSlip.Name = "xrPicturePaymentSlip";
            this.xrPicturePaymentSlip.SizeF = new System.Drawing.SizeF(650F, 601.8334F);
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 26.04167F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 25.62491F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelAcctOwnrNm
            // 
            this.xrLabelAcctOwnrNm.LocationFloat = new DevExpress.Utils.PointFloat(0F, 670.8334F);
            this.xrLabelAcctOwnrNm.Name = "xrLabelAcctOwnrNm";
            this.xrLabelAcctOwnrNm.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelAcctOwnrNm.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.xrLabelAcctOwnrNm.StylePriority.UseTextAlignment = false;
            this.xrLabelAcctOwnrNm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportCAMT
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 26, 26);
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabelImageName;
        private DevExpress.XtraReports.UI.XRPictureBox xrPicturePaymentSlip;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak;
        private DevExpress.XtraReports.UI.XRLabel xrLabelAmount;
        private DevExpress.XtraReports.UI.XRLabel xrLabelAcctIdIBAN;
        private DevExpress.XtraReports.UI.XRLabel xrLabelAcctOwnrNm;
    }
}
