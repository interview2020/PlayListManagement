using System;
using System.Collections.Generic;
using System.Text;
using PlayListManagement.Model;

namespace PlayListManagement.Process.Data
{
    /// <summary>
    /// IDataChangeManager: Interface for DataChangeManager
    /// </summary>
    interface IDataChangeManager
    {
        void ApplyChangeSetToInput();
        void GenerateOutputFile();

    }
}
