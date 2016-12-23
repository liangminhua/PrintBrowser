using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace PrintBrowser
{
    class Internal
    {
        [STAThread]
        public void print(string printerName, string xaml)
        {
            Print.PrintXaml(printerName, xaml);
        }

        public string[] GetPrinters()
        {
            PrintQueueCollection pqc = Print.GetPrintQueues();
            var Printers = from queues in pqc
                           select queues.FullName;
            return Printers.ToArray();
        }
    }
}