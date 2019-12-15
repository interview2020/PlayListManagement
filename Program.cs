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
            Console.WriteLine("Hello World!");
            /*
            if (args.Length < 3)
            {
                Console.WriteLine("Please enter input, change and output files as arguments");
                Console.WriteLine("Usage: PlayListManagement <input-file> <changes-file> <output-file>");
                return 1;
            }
            
            */
            IDataChangeManager datachangeManager = new DataChangeManager("mixtape-data.json", "change-data.json", "out.json");
            datachangeManager.ApplyChangeSetToInput();
            datachangeManager.GenerateOutputFile();
            return 0;
        }
    }
}
