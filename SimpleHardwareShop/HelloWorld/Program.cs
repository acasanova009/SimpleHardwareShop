

using System;
using System.Diagnostics;
using System.IO;
using ZetPDF;
using ZetPDF.Drawing;
using ZetPDF.Pdf;
using ZetPDF.Pdf.IO;

namespace HelloWorld
{
  /// <summary>
  /// This sample is the obligatory Hello World program.
  /// </summary>
  class Program
  {
    static void Main()
    {
      // Create a new PDF document
      PdfDocument document = new PdfDocument();
      document.Info.Title = "Created with ZetPDF";

      // Create an empty page
      PdfPage page = document.AddPage();

      // Get an XGraphics object for drawing
      XGraphics gfx = XGraphics.FromPdfPage(page);

      //XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

      // Create a font
      XFont font = new XFont("Times New Roman", 20, XFontStyle.BoldItalic);

      // Draw the text
      gfx.DrawString("Hello, World!", font, XBrushes.Black,
        new XRect(0, 0, page.Width, page.Height),
        XStringFormats.Center);

      // Save the document...
      const string filename = "HelloWorld_tempfile.pdf";
      document.Save(filename);
      // ...and start a viewer.
      Process.Start(filename);
    }
  }
}
