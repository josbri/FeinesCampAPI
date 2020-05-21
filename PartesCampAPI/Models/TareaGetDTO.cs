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

        public string ClientName { get; set; }

        public int UserID { get; set; }
        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }

        public string CommentPre { get; set; }
        public string CommentPro { get; set; }

        public bool Completed { get; set; }
        
        public bool Facturada { get; set; }
        public string Image { get; set; }

        public float Time { get; set; }


        public TareaGetDTO () { }
    }
}
