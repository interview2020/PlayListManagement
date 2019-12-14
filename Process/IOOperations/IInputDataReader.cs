

using PlayListManagement.Model;

namespace PlayListManagement.Process.IOOPerations
{
    interface IInputDataReader
    {
        bool IsInputDataValid();
        bool IsChangeSetDataValid();
        UsersSongsPlayLists DeserializeInputData(string filepath);
        ChangeSet DeserializeChangeSet(string jsonString);
    }
}