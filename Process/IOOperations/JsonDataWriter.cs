using PlayListManagement.Model;
using System.Text.Json;
using System;
using System.IO;

namespace PlayListManagement.Process.IOOPerations
{
    class JsonDataWriter : IOutputDataWriter
    {
        public void GenerateOutputFile(UsersSongsPlayLists updatedData, string outputfilepath)
        {

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            var jsondata = JsonSerializer.Serialize(updatedData, options);
            Console.WriteLine(jsondata);

            try
            {
                File.WriteAllText(outputfilepath, jsondata);
            }
            catch (DirectoryNotFoundException dirNotFoundException)
            {
                Console.WriteLine($"Error during file write, directory not found: {dirNotFoundException}");
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                Console.WriteLine($"Error during file write: {unauthorizedAccessException}");
            }
            catch (IOException ioException)
            {
                Console.WriteLine($"Error during file write { ioException}");

                Console.WriteLine("Error during file write");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error during file write{ exception}");
            }
        }
    }
}