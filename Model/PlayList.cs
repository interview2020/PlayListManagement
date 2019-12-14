using System;

using System.Collections.Generic;

namespace PlayListManagement.Model
{
    class PlayList
    {
        public string Id { get; set; }
        public string User_id { get; set; }
        public List<string> Song_ids { get; set; }
    }
}