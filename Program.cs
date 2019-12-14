using System;
using PlayListManagement.Model;
using PlayListManagement.Process.IOOPerations;

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

            IInputDataReader jsonDataReader = new JsonDataReader();
            UsersSongsPlayLists inputData = jsonDataReader.DeserializeInputData("mixtape-data.json");
            ChangeSet changeData = jsonDataReader.DeserializeChangeSet("change-data.json");

            return 0;
        }
    }
}
