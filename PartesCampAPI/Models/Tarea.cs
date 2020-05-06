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

        public DateTime Created { get; set; } = new DateTime();

        public DateTime Finished { get; set; }

        public bool Completed { get; set; }
        
        public string CommentsPre { get; set; }

        public string CommentsPost { get; set; }

        public float Time { get; set; }
        public Tarea() { }

    }
}
