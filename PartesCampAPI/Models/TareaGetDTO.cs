using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class TareaGetDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int LandID { get; set; }

        public LandGetInTaskDTO Land { get; set; }

        public int OwnerID { get; set; }

        public string Owner { get; set; }

        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }

        public string CommentPre { get; set; }
        public string CommentPro { get; set; }

        public bool Completed { get; set; }

        public TareaGetDTO(int iD, string name, int landID, LandGetInTaskDTO land, int ownerID, string owner, DateTime created, DateTime finished, string commentPre, string commentPro, bool completed)
        {
            ID = iD;
            Name = name;
            LandID = landID;
            Land = land;
            OwnerID = ownerID;
            Owner = owner;
            Created = created;
            Finished = finished;
            CommentPre = commentPre;
            CommentPro = commentPro;
            Completed = completed;
        }

        public TareaGetDTO () { }
    }
}
