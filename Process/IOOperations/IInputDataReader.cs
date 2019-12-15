

using PlayListManagement.Model;

namespace PlayListManagement.Process.IOOPerations
{
    interface IInputDataReader
    {
        bool IsInputDataValid();
        bool IsChangeSetDataValid();
        UsersSongsPlayLists DeserializeInputData(string filepath);
        UsersSongsPlayListsChangeSet DeserializeChangeSet(string jsonString);
    }
}