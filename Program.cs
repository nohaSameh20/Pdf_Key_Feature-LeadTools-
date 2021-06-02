// *************************************************************
// Copyright (c) 1991-2021 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Diagnostics;
using System.IO;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Pdf;

namespace Encrypt_PDF_Files
{
   class Program
   {
      static void Main(string[] args)
      {
            try
            {
                //LeadTool Licence
                RasterSupport.SetLicense(@"C:\Users\Noha\Downloads\eval-license-files_63faf918-a88f-4660-8941-cc34a867986e\eval-license-files.lic",
                                    File.ReadAllText(@"C:\Users\Noha\Downloads\eval-license-files_63faf918-a88f-4660-8941-cc34a867986e\eval-license-files.lic.key"));



                //Convert tif to New pdf file
                //string fileName = @"C:\Users\Noha\Music\Files\resume-io-r-Cb6B3wmWg.tif";
                //RasterCodecs codecs = new RasterCodecs();
                //RasterImage image = codecs.Load(fileName, 0, CodecsLoadByteOrder.Bgr, 1, 1);
                //var changeExtension = Path.ChangeExtension(fileName, "pdf");
                //codecs.Save(image, changeExtension, RasterImageFormat.RasPdfG4, 1);


                // Encrypted
                //string inputFileName = @"C:\Users\Noha\Music\Files\resume-io-r-Cb6B3wmWg.pdf";
                //string outputFileName = @"C:\Users\Noha\Music\Files\resume-io-r-Cb6B3wmWgEncCopy.pdf";
                //EncryptPdf(inputFileName, outputFileName);

                //Delete 
                //string inputFileName = @"C:\Users\Noha\Music\Files\MultiPage.pdf";
                //PDFFile inputFile = new PDFFile(inputFileName);
                //var pageCount= inputFile.GetPageCount();
                //inputFile.DeletePages(2, 3, null);
                //pageCount = inputFile.GetPageCount();

                //Extract
                //string inputFileName = @"C:\Users\Noha\Music\Files\Extract.pdf";
                //PDFFile inputFile = new PDFFile(inputFileName);
                //var pageCount = inputFile.GetPageCount();
                //inputFile.ExtractPages(1, 3, null);
                //pageCount = inputFile.GetPageCount();

                //Insert
                //string original = @"C:\Users\Noha\Music\Files\PDF1.pdf";
                //string file1 = @"C:\Users\Noha\Music\Files\PDF2.pdf";

                //PDFFile inputFile = new PDFFile(original);
                //var pageCount = inputFile.GetPageCount();
                //inputFile.InsertPagesFrom(9, new PDFFile(file1), 1, 2);
                //pageCount = inputFile.GetPageCount();

                //Merge
                //string original = @"C:\Users\Noha\Music\Files\PDF1.pdf";
                //string file1 = @"C:\Users\Noha\Music\Files\PDF2.pdf";
                //string file2 = @"C:\Users\Noha\Music\Files\PDF3.pdf";


                //PDFFile inputFile = new PDFFile(original);
                //var pageCount = inputFile.GetPageCount();
                //inputFile.MergeWith(new string[] { file1, file2 }, null);
                //pageCount = inputFile.GetPageCount();


                //Replace
                //string original = @"C:\Users\Noha\Music\Files\PDF1.pdf";
                //string file1 = @"C:\Users\Noha\Music\Files\PDF2.pdf";

                //PDFFile inputFile = new PDFFile(original);
                //var pageCount = inputFile.GetPageCount();
                //inputFile.ReplacePagesFrom(7, new PDFFile(file1), 3, 6);
                //pageCount = inputFile.GetPageCount();

                //linearize

                //string original = @"C:\Users\Noha\Music\Files\PDF1.pdf";
                //string file1 = @"C:\Users\Noha\Music\Files\PDF2.pdf";

                //PDFFile inputFile = new PDFFile(original);
                //var pageCount = inputFile.GetPageCount();
                //inputFile.Linearize(file1);
                //pageCount = inputFile.GetPageCount();


                //Rotate
                //string original = @"C:\Users\Noha\Music\Files\PDF1.pdf";
                //string file1 = @"C:\Users\Noha\Music\Files\PDF2.pdf";

                //PDFFile inputFile = new PDFFile(original);
                //var pageCount = inputFile.GetPageCount();
                //PDFDistillerOptions options = new PDFDistillerOptions();
                //options.AutoRotatePageMode = PDFDistillerAutoRotatePageMode.All;
                //options.OutputMode = PDFDistillerOutputMode.EBookOptimized;
                //inputFile.Distill(options, file1);
                //pageCount = inputFile.GetPageCount();

            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

        //Convert PDF to encrypted and disable printing
        static void EncryptPdf(string inputFileName, string outputFileName)
        {
            PDFFile inputFile = new PDFFile(inputFileName);
            Console.WriteLine("Original PDF File Loaded");
            inputFile.SecurityOptions = new PDFSecurityOptions();

            // Set a password to open the file
            inputFile.SecurityOptions.UserPassword = "PasswordToOpen";

            // Set a password that will be needed when changing the file permissions in the future
            inputFile.SecurityOptions.OwnerPassword = "PermissionsPassword";
            // Disable printing
            inputFile.SecurityOptions.PrintEnabled = false;
            inputFile.SecurityOptions.HighQualityPrintEnabled = false;
            inputFile.SecurityOptions.EncryptionMode = PDFEncryptionMode.RC128Bit;

            Console.WriteLine("Security Options Set.");
            inputFile.Convert(1, -1, outputFileName);
            Console.WriteLine("Encrypted PDF Produced.");
            Console.WriteLine("Checking if output PDF is encrypted:" + PDFFile.IsEncrypted(outputFileName));
            var pageCount = inputFile.GetPageCount();
            var author  = inputFile.DocumentProperties.Author = "Travis";
            var subject = inputFile.DocumentProperties.Subject = "My Resume";
            inputFile.CompatibilityLevel = PDFCompatibilityLevel.PDF15;
            inputFile.Convert(1, -1, null);
            
        }

    }
}