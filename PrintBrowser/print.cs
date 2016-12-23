using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Xml;

namespace PrintBrowser
{
    public static class Print
    {
        /// <summary>
        /// Print the xaml Template to the printer.
        /// </summary>
        /// <param name="printerName"></param>
        /// <param name="flowDocument"></param>
        /// <param name="isFixedPrinterWidth"></param>
        /// <param name="isAsync">While in the UI Thread, maybe need async.</param>
        private static void PrintFlowDocument(string printerName, FlowDocument flowDocument, bool isFixedPrinterWidth, bool isAsync)
        {
            LocalPrintServer lps = new LocalPrintServer();
            PrintQueue printQueue = new PrintQueue(lps, printerName);
            if (isFixedPrinterWidth)
            {
                flowDocument.PageWidth = printQueue.GetPrintCapabilities().OrientedPageMediaWidth.Value;
            }
            XpsDocumentWriter documentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
            if (isAsync)
            {
                documentWriter.WriteAsync(((IDocumentPaginatorSource)flowDocument).DocumentPaginator);
            }
            else
            {
                documentWriter.Write(((IDocumentPaginatorSource)flowDocument).DocumentPaginator);
            }
        }
        private static FlowDocument LoadDocument(string printTemplate, object data)
        {
            FlowDocument fdoc = (FlowDocument)System.Windows.Application.LoadComponent(new Uri(printTemplate, UriKind.RelativeOrAbsolute));
            fdoc.DataContext = data;
            return fdoc;
        }
        public static void PrintXaml(string printerName, string xaml)
        {
            StringReader stringReader = new StringReader(xaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            FlowDocument readerFlowDocument = (FlowDocument)XamlReader.Load(xmlReader);
            PrintFlowDocument(printerName, readerFlowDocument, true, false);
        }

        /// <summary>
        /// Get all vaild Printers' Queues.
        /// </summary>
        /// <returns>Printers' Queues</returns>
        public static PrintQueueCollection GetPrintQueues()
        {
            LocalPrintServer ls = new LocalPrintServer();
            return ls.GetPrintQueues();
        }
    }

}
