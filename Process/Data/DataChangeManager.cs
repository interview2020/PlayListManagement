using System;
using System.Collections.Generic;
using System.Text;
using PlayListManagement.Model;
using PlayListManagement.Process.IOOPerations;

namespace PlayListManagement.Process.Data
{
    /// <summary>
    /// DataChangeManager: Facade to data operations on the file data
    /// </summary>
    class DataChangeManager : IDataChangeManager
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

        /// <summary>
        /// DeserializeFiles: DeserializeFiles json file to C# objects
        /// </summary>
        private void DeserializeFiles()
        {
            IInputDataReader jsonDataReader = new JsonDataReader();
            inputData = jsonDataReader.DeserializeInputData(InputFile);
            changeSetData = jsonDataReader.DeserializeChangeSet(ChangeFile);
        }

        /// <summary>
        /// ApplyChangeSetToInput: Applies the change set data to the input data
        /// </summary>
        public void ApplyChangeSetToInput()
        {
            DeserializeFiles();
            PlayListOperations playListOperations = new PlayListOperations(inputData, changeSetData);
            inputData = playListOperations.ApplyChangeSetToInput();
        }

        /// <summary>
        /// GenerateOutputFile: Generates output file. Will over write if the file exists
        /// </summary>
        public void GenerateOutputFile()
        {
            IOutputDataWriter jsonDataReader = new JsonDataWriter();
            jsonDataReader.GenerateOutputFile(inputData, OutputFile);
        }
    }
}
