

using PlayListManagement.Model;

namespace PlayListManagement.Process.IOOPerations
{
    /// <summary>
    /// IOutputDataWriter: Interface for OutputDataWriter(s)
    /// </summary>
    interface IOutputDataWriter
    {
        void GenerateOutputFile(UsersSongsPlayLists updatedData, string outputfilepath);
    }
}