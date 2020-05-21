using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int LandID { get; set; }
        public Land Land { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

        public string ClientName { get; set; }
        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }

        public bool Completed { get; set; }

        public bool Facturada { get; set; }
        public string CommentsPre { get; set; }

        public string CommentsPost { get; set; }

        public float Time { get; set; }

        public string Image { get; set; }
        public Tarea() { }

    }
}
