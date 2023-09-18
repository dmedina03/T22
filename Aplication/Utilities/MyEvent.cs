using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Layout.Element;
using iText.Layout;
using iText.Kernel.Geom;

namespace Aplication.Utilities
{
    public class MyEvent : IEventHandler
    {
        private readonly byte[] headerImage;
        private readonly byte[] footerImage;

        public MyEvent(byte[] headerImage, byte[] footerImage)
        {
            this.headerImage = headerImage;
            this.footerImage = footerImage;
        }

        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;

            PdfPage page = docEvent.GetPage();

            PdfDocument pdfDoc = docEvent.GetDocument();

            PdfCanvas pdfCanvas = new PdfCanvas(page.GetLastContentStream(), page.GetResources(), pdfDoc);

            ImageData header = ImageDataFactory.Create(headerImage);

            ImageData footer = ImageDataFactory.Create(footerImage);

            pdfCanvas.AddImage(footer, 0, 0, 600, true);
            pdfCanvas.AddImage(header, 65, 750, 160, true);

            int pageNum = docEvent.GetDocument().GetPageNumber(page);

            PdfFont bold = PdfFontFactory.CreateFont(FontConstants.TIMES_BOLD);

            Text PageNumber = new Text(pageNum.ToString()).SetFont(bold);

            Paragraph parrafo = new Paragraph();

            parrafo.Add(PageNumber);

            Rectangle rectangle = new Rectangle(520, -75, 100, 100);

            Canvas canvas = new Canvas(pdfCanvas, pdfDoc, rectangle);

            canvas.Add(parrafo);
        }

    }
}
