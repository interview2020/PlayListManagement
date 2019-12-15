

using PlayListManagement.Model;

namespace PlayListManagement.Process.IOOPerations
{
    interface IOutputDataWriter
    {
        void GenerateOutputFile(UsersSongsPlayLists updatedData, string outputfilepath);
    }
}