using PlayListManagement.Model;
using System.Text.Json;
using System.IO;

namespace PlayListManagement.Process.IOOPerations
{
    class JsonDataReader : IInputDataReader
    {
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

        public bool IsChangeSetDataValid()
        {  
            //Validate if changeset data is formatted correctly
            //Throw exception if not valid 
            //else return true
            return true;
        }

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