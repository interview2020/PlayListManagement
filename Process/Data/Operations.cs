using PlayListManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayListManagement.Process.Data
{
    abstract class Operations
    {
        public UsersSongsPlayLists inputData { get; set; }
        public UsersSongsPlayListsChangeSet changeSetData { get; set; }
        public abstract UsersSongsPlayLists ApplyChangeSetToInput();
        public bool IsPlaylistExisting(string Id, string User_id)
        {
            if (Id != null && 
                User_id != null && 
                inputData.Playlists.Find(x => x.Id == Id && x.User_id == User_id) != null)
            {
                return true;
            }
            return false;
        }

        public bool IsSongExisting(string Id)
        {
            if (inputData.Songs.Where(x => x.Id == Id) != null)
            {
                return true;
            }
            return false;
        }

        public bool IsSongsExisting(List<string> song_ids)
        {
            if (song_ids == null || song_ids.Count ==0)
            {
                return false;
            }

            bool isSongsExisting = true;
            foreach (string Id in song_ids)
            {
                if (string.IsNullOrEmpty(Id) || !IsSongExisting(Id))
                {
                    isSongsExisting = false;
                    break;
                }
            }
            return isSongsExisting;
        }
        public bool IsUserExisting(string Id)
        {
            if (Id != null && 
                inputData.Users.Where(x => x.Id == Id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
