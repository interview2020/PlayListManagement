using System;
using System.Collections.Generic;

namespace PlayListManagement.Model
{
    class ChangeSet
    {
        public List<UsersSongsPlayLists> Add { get; set; }
        public List<UsersSongsPlayLists> Update { get; set; }
        public List<UsersSongsPlayLists> Delete { get; set; }
    }
}