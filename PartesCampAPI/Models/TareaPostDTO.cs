﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class TareaPostDTO
    {
        public string Name { get; set; }

        public int LandID { get; set; }

        public int ClientID { get; set; }
        public bool Completed { get; set; }

        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }
        public string CommentsPre { get; set; }

        public string CommentsPost { get; set; }

        public float Time { get; set; }

        public TareaPostDTO(string name, int landID, int clientID, bool completed, DateTime created, DateTime finished, string commentsPre, string commentsPost, float time)
        {
            Name = name;
            LandID = landID;
            ClientID = clientID;
            Created = created;
            Finished = finished;
            Completed = completed;
            CommentsPre = commentsPre;
            CommentsPost = commentsPost;
            Time = time;
        }

        public TareaPostDTO() { }
    }
}
