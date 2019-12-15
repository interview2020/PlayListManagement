using System;
using System.Collections.Generic;
using System.Text;
using PlayListManagement.Model;

namespace PlayListManagement.Process.Data
{
    interface IDataChangeManager
    {
        void ApplyChangeSetToInput();
        void GenerateOutputFile();

    }
}
