using System;
using System.Collections.Generic;

namespace PlayListManagement.Model
{
    class UsersSongsPlayLists
    {
        public List<PlayList> Playlists { get; set; }
        public List<Song> Songs { get; set; }   
        public List<User> Users { get; set; }
    }
}