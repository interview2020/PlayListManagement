using System;
using System.Collections.Generic;
using System.Text;
using PlayListManagement.Model;
using PlayListManagement.Process.IOOPerations;

namespace PlayListManagement.Process.Data
{
    class DataChangeManager: IDataChangeManager
    {
        public string InputFile { get; private set; }
        public string ChangeFile { get; private set; }
        public string OutputFile { get; private set; }

        private UsersSongsPlayLists inputData;
        private UsersSongsPlayListsChangeSet changeSetData;
        public DataChangeManager(string input_file, string change_file, string output_file)
        {
            InputFile = input_file;
            ChangeFile = change_file;
            OutputFile = output_file;
        }

        private void DeserializeFiles()
        {
            IInputDataReader jsonDataReader = new JsonDataReader();
            inputData = jsonDataReader.DeserializeInputData(InputFile);
            changeSetData = jsonDataReader.DeserializeChangeSet(ChangeFile);
        }
        public void ApplyChangeSetToInput()
        {
            DeserializeFiles();
            PlayListOperations playListOperations = new PlayListOperations(inputData, changeSetData);
            inputData = playListOperations.ApplyChangeSetToInput();
        }

        public void GenerateOutputFile()
        {
            IOutputDataWriter jsonDataReader = new JsonDataWriter();
            jsonDataReader.GenerateOutputFile(inputData, OutputFile);

        }
    }
}
