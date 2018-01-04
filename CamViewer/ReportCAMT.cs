using System.Drawing;
using System.Data;
using System.IO;

namespace CamViewer
{
    public partial class ReportCAMT : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportCAMT()
        {
            InitializeComponent();            
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataRowView drv = (DataRowView)GetCurrentRow();

            var fileName = drv.Row["Name"] + string.Empty;
            if (string.IsNullOrWhiteSpace(fileName) || drv.Row["Image"] == null)
                return;

            byte[] byteimg = (byte[])drv.Row["Image"];
            Image img = ByteArrayToImage(byteimg);
            this.xrPicturePaymentSlip.Image = img;
            this.xrLabelImageName.Text = fileName;
            this.xrLabelAmount.Text = (string)drv.Row["NtryAmt"];
            this.xrLabelAcctIdIBAN.Text = (string)drv.Row["AcctIdIBAN"];
            this.xrLabelAcctOwnrNm.Text = (string)drv.Row["AcctOwnrNm"];
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = Image.FromStream(ms, true);//Exception occurs here
            }
            catch { }
            return returnImage;
        }
    }
}
