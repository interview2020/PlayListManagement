using System;
using System.Collections.Generic;

namespace PlayListManagement.Model
{
    class UsersSongsPlayListsChangeSet
    {
        public UsersSongsPlayLists Additions { get; set; }
        public UsersSongsPlayLists Updates { get; set; }
        public UsersSongsPlayLists Deletions { get; set; }
    }
}