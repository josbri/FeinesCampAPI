using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string JwtID { get; set; }

        public string Email { get; set; }
        public List<Client> Clients {get; set; }

        public List<Tarea> Tasks { get; set; }
        public User() { }

    }
}
