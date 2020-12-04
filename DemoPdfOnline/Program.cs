using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using pdftron;
using pdftron.Common;
using pdftron.SDF;
using pdftron.PDF;

namespace DemoPdfOnline
{
    public class Program
    {

        private static PDFNetLoader loader = PDFNetLoader.Instance();

        static void Main(string[] args)
        {
            // Initialize PDFNet before using any PDFTron related
            // classes and methods (some exceptions can be found in API)
            PDFNet.Initialize();

            // Using PDFNet related classes and methods, must catch or throw PDFNetException
            try
            {
                using (PDFDoc doc = new PDFDoc())
                {
                    doc.InitSecurityHandler();

                    // An example of creating a new page and adding it to
                    // doc's sequence of pages
                    Page newPg = doc.PageCreate();
                    doc.PagePushBack(newPg);

                    // Save as a linearized file which is most popular 
                    // and effective format for quick PDF Viewing.
                    doc.Save("linearized_output.pdf", SDFDoc.SaveOptions.e_linearized);

                    System.Console.WriteLine("Done. Results saved in linearized_output.pdf");
                }
            }
            catch (PDFNetException e)
            {
                System.Console.WriteLine(e);
            }
        }
    }
}