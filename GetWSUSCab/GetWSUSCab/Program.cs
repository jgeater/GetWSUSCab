using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace GetWSUSCab
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("Invalid command Line options");
                System.Console.WriteLine("");
                System.Console.WriteLine("Downloads the wsusscn2.cab file to the desired directory");
                System.Console.WriteLine("");
                System.Console.WriteLine("Usage GetWSUSCab.exe <Path>");
                System.Console.WriteLine("");
                System.Console.WriteLine("Example:");
                System.Console.WriteLine(@"GetWSUSCab.exe c:\temp");
                System.Console.WriteLine("");
                System.Console.WriteLine("NOTE: If you want to use spaces in the names you must put the the string in quotes");
                System.Environment.Exit(1);
            }

            string DlDir = args[0];

            //test to see if the folder is valid
            if (!System.IO.Directory.Exists(DlDir))
            {
                Console.WriteLine("The directory is invalid");
                Environment.Exit(2);
            }

            //delete the existing cab file if found
            if (File.Exists(DlDir + @"\wsusscn2.cab"))
            {
                File.Delete(DlDir + @"\wsusscn2.cab");
            }

            Console.WriteLine("Downloading the cab file. This may take a few minutes.");
            try
            { 
            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://download.windowsupdate.com/microsoftupdate/v6/wsusscan/wsusscn2.cab", DlDir + @"\wsusscn2.cab");
            Console.WriteLine("Download Completed");
            Environment.Exit(0);
            }
            catch (Exception)
            {
                Console.WriteLine("Error Downloading File");
                Environment.Exit(3);

            }
        }
    }
}
