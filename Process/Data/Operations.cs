using PlayListManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayListManagement.Process.Data
{
    /// <summary>
    /// Operations: Abasrtact class for data operation. Contains common validations
    /// </summary>
    abstract class Operations
    {
        public UsersSongsPlayLists inputData { get; set; }
        public UsersSongsPlayListsChangeSet changeSetData { get; set; }
        public abstract UsersSongsPlayLists ApplyChangeSetToInput();
        /// <summary>
        /// IsPlaylistExisting: Checks if the specified playlist exists in the input data
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="User_id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// IsSongExisting: Check if the song exists in the list of songs
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsSongExisting(string Id)
        {
            if (inputData.Songs.Where(x => x.Id == Id) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// IsSongsExisting: Checks id each song in the input list exists in input data songs
        /// </summary>
        /// <param name="song_ids"></param>
        /// <returns></returns>
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

        /// <summary>
        /// IsUserExisting: Checks is the user exists in the input data
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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
