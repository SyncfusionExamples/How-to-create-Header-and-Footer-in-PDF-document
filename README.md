# How to create Header and Footer in PDF document
[SfDataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) supports exporting data to PDF, complete with headers and footers. To achieve this, utilize the ExportToPdf method by passing the `SfDataGrid` as an argument. The header and footer can be crafted in the [HeaderAndFooterExporting](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataGrid.Exporting.DataGridPdfExportingController.html#Syncfusion_Maui_DataGrid_Exporting_DataGridPdfExportingController_HeaderAndFooterExporting) event using the `PdfDocumentTemplate` property from the event argument.

The following code demonstrates how to subscribe to the `HeaderAndFooterExporting` event and create headers and footers for the exported PDF document.
 
##### xaml:
 ```XML
 <Grid RowDefinitions="60,*"
      ColumnDefinitions="*,*">
    <Button Text="ExportToPdf"
            Grid.Row="0"
            Margin="5"
            Grid.Column="0"
            Clicked="Button_Clicked" />
    <syncfusion:SfDataGrid x:Name="dataGrid"
                           Grid.Column="0"
                           Grid.ColumnSpan="2"
                           Grid.Row="1"
                           ColumnWidthMode="Auto"
                           ItemsSource="{Binding Employees}">
    </syncfusion:SfDataGrid>
</Grid>
 ```
 

##### xaml.cs:
 
 ```XML
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
 ```
 

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-create-Header-and-Footer-in-PDF-document/tree/master)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).

##### Conclusion

I hope you enjoyed learning about how to create Header and Footer in PDF document in .NET MAUI DataGrid (SfDataGrid)?

You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components. 

If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!
