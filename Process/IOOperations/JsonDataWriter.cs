using PlayListManagement.Model;
using System.Text.Json;
using System;
using System.IO;

namespace PlayListManagement.Process.IOOPerations
{
    /// <summary>
    /// JsonDataWriter: Converts c# objects to json and writes to file
    /// </summary>
    class JsonDataWriter : IOutputDataWriter
    {
        /// <summary>
        /// GenerateOutputFile: Generates json output file based on the object data passed. If the target exists, file is overwritten
        /// </summary>
        /// <param name="usersSongsPlayLists"></param>
        /// <param name="outputfilepath"></param>
        public void GenerateOutputFile(UsersSongsPlayLists usersSongsPlayLists, string outputfilepath)
        {
            var jsondata = SerializeToJsonString(usersSongsPlayLists);

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
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error during file write{ exception}");
            }
        }
        /// <summary>
        /// SerializeToJsonString: Serialize .net object usersSongsPlayLists to json string.
        /// </summary>
        /// <param name="usersSongsPlayLists"></param>
        /// <returns></returns>
        private string SerializeToJsonString(UsersSongsPlayLists usersSongsPlayLists)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            return JsonSerializer.Serialize(usersSongsPlayLists, options);
        }
    }
}