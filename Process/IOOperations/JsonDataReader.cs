using PlayListManagement.Model;
using System.Text.Json;
using System.IO;

namespace PlayListManagement.Process.IOOPerations
{/// <summary>
/// JsonDataReader: Converts input and changeset json files to models to work on
/// </summary>
    class JsonDataReader : IInputDataReader
    {
        /// <summary>
        /// DeserializeChangeSet: Deserializes the ChangeSet file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public UsersSongsPlayListsChangeSet DeserializeChangeSet(string filepath)
        {
            IsInputDataValid();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true,
            };
            return JsonSerializer.Deserialize<UsersSongsPlayListsChangeSet>(File.ReadAllText(filepath), options);
          }

        /// <summary>
        /// DeserializeInputData: Deserialize the inputData file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public UsersSongsPlayLists DeserializeInputData(string filepath)
        {
            IsInputDataValid();
           
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            return JsonSerializer.Deserialize<UsersSongsPlayLists>(File.ReadAllText(filepath), options);
        }

        /// <summary>
        /// IsChangeSetDataValid: Not implemented
        /// </summary>
        /// <returns></returns>
        public bool IsChangeSetDataValid()
        {  
            //Validate if changeset data is formatted correctly
            //Throw exception if not valid 
            //else return true
            return true;
        }

        /// <summary>
        /// IsInputDataValid: Not Implemented
        /// </summary>
        /// <returns></returns>
        public bool IsInputDataValid()
        {  
            //Validate if file exists
            //Validate file format with json schema 
            //Throw exception if file not valid or not found
            //else return true
            return true;
        }
    }

}