using System;
using PlayListManagement.Model;
using PlayListManagement.Process.IOOPerations;
using PlayListManagement.Process.Data;

namespace PlayListManagement
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Initializing application...");
            
            if (args.Length < 3)
            {
                Console.WriteLine("Please enter input, change and output files as arguments");
                Console.WriteLine("Usage: PlayListManagement <input-file> <changes-file> <output-file>");
                return 1;
            }

            //IDataChangeManager datachangeManager = new DataChangeManager("mixtape-data.json", "change-data.json", "out.json");
            IDataChangeManager datachangeManager = new DataChangeManager(args[0], args[1], args[2]);

            Console.WriteLine("Reading file and applying changes");
            datachangeManager.ApplyChangeSetToInput();
            Console.WriteLine("Generating outputfile");
            datachangeManager.GenerateOutputFile();
            Console.WriteLine($"Applcation completed. Check the respective folder for output file {args[2]}");
            return 0;
        }
    }
}
