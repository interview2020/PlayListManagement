

using PlayListManagement.Model;

namespace PlayListManagement.Process.IOOPerations
{
    /// <summary>
    /// IInputDataReader: Interface for InputDataReader(s)
    /// </summary>
    interface IInputDataReader
    {
        bool IsInputDataValid();
        bool IsChangeSetDataValid();
        UsersSongsPlayLists DeserializeInputData(string filepath);
        UsersSongsPlayListsChangeSet DeserializeChangeSet(string jsonString);
    }
}