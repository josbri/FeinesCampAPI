using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class TareaPostDTO
    {
        public string Name { get; set; }

        public int LandID { get; set; }
        public bool Completed { get; set; }

        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }
        public string CommentsPre { get; set; }

        public string CommentsPost { get; set; }

        public string ClientName { get; set; }

        public float Time { get; set; }

        public string Image { get; set; }

        public int UserID { get; set; }

        public TareaPostDTO(string name, int landID, string clientname, int clientID, int userid, bool completed, string image, DateTime created, DateTime finished, string commentsPre, string commentsPost, float time)
        {
            ClientName = clientname;
            Name = name;
            LandID = landID;
            Created = created;
            Finished = finished;
            Completed = completed;
            CommentsPre = commentsPre;
            CommentsPost = commentsPost;
            Time = time;
            Image = image;
            UserID = userid;
        }

        public TareaPostDTO() { }
    }
}
