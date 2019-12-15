
using PlayListManagement.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlayListManagement.Process.Data
{
    class PlayListOperations:Operations
    {
       
        public PlayListOperations(UsersSongsPlayLists inputData, UsersSongsPlayListsChangeSet changeSet)
        {
            base.inputData = inputData;
            base.changeSetData = changeSet;
        }

        /// <summary>
        /// ApplyChangeSetToInput: Applies all the changes in the change set to input data
        /// </summary>
        /// <returns>UsersSongsPlayLists</returns>
        public override UsersSongsPlayLists ApplyChangeSetToInput()
        {
            ApplyNewAndUpdateChangesToPlayList();
            RemovePlaylist();
            return inputData;
        }
    
        private void ApplyNewAndUpdateChangesToPlayList()
        {
            if(changeSetData.Additions.Playlists == null)
            {
                return;
            }

            foreach(Playlist playList in changeSetData.Additions.Playlists)
            {
                if (!IsUserExisting(playList.User_id) ||
                    !IsSongsExisting(playList.Song_ids))
                {

                    if (!IsPlaylistExisting(playList.Id, playList.User_id))
                    {
                        Console.WriteLine($"ApplyPlayListChanges: Failed to add new playlist {playList.Id} for user {playList.User_id}. Invalid user or song ids.");
                    }
                    else
                    {
                        Console.WriteLine($"ApplyPlayListChanges: Failed to update songs in playlist {playList.Id} for user {playList.User_id}. Invalid user or song ids.");
                    }
                    continue;
                }
                if (!IsPlaylistExisting(playList.Id, playList.User_id))
                {
                    inputData.Playlists.Add(playList);
                    Console.WriteLine($"ApplyPlayListChanges: Added new playlist {playList.Id} for user {playList.User_id}");
                }
                else
                {
                    AddExistingSongToPlaylist(playList.Id, playList.User_id, playList.Song_ids);
                }
            }
        }

        private void RemovePlaylist()
        {
            if(changeSetData.Deletions.Playlists == null)
            {
                return;
            }
            foreach(Playlist playList in changeSetData.Deletions.Playlists)
            {
                if (IsPlaylistExisting(playList.Id, playList.User_id))
                {
                    inputData.Playlists.Remove(inputData.Playlists.Find(x => x.Id == playList.Id && x.User_id == playList.User_id));
                    Console.WriteLine($"RemovePlaylist: Playlist {playList.Id} of user {playList.User_id} removed.");
                }
                else {
                    Console.WriteLine($"RemovePlaylist: Playlist {playList.Id} with User {playList.User_id} does not exist. Operation skipped");
                }
            }
        }

        private void AddExistingSongToPlaylist(string playlistId, string userId, List<string> Song_ids)
        {
            Playlist playList = inputData.Playlists.Find(x => x.Id == playlistId && x.User_id == userId);
            foreach (string Id in Song_ids)
            {
                if (!playList.Song_ids.Contains(Id))
                {
                    playList.Song_ids.Add(Id);
                    Console.WriteLine($"AddExistingSongToPlaylist: Added new song {Id} to playlist {playList.Id}");
                } 
                else 
                {
                    Console.WriteLine($"AddExistingSongToPlaylist: Song {Id} already exists in playlist {playList.Id}. Operation skipped.");
                }
            }
        }
    }

}