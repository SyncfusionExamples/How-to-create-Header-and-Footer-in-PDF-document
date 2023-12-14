using SfDataGridSample.Services;
using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.Exporting;
using Syncfusion.Maui.DataGrid.Helper;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream();
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            DataGridPdfExportingOption option = new DataGridPdfExportingOption();
            pdfExport.HeaderAndFooterExporting += PdfExport_HeaderAndFooterExporting;
            var pdfDoc = pdfExport.ExportToPdf(this.dataGrid, option);
            pdfDoc.Save(stream);
            pdfDoc.Close(true);
            SaveService saveService = new();
            saveService.SaveAndView("ExportFeature.pdf", "application/pdf", stream);
        }

        private void PdfExport_HeaderAndFooterExporting(object? sender, DataGridPdfHeaderFooterEventArgs e)
        {
            float Width = e.PdfPage.GetClientSize().Width;
            PdfPageTemplateElement header = new PdfPageTemplateElement(Width, 100);
            PdfPageTemplateElement footer = new PdfPageTemplateElement(Width, 100);
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
            header.Graphics.DrawString("Header", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF((Width / 2) - 20, 0));
            e.PdfDocumentTemplate.Top = header;
            footer.Graphics.DrawString("Footer", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF((Width / 2) - 20, 20));
            e.PdfDocumentTemplate.Bottom = footer;
        }
    }
}
