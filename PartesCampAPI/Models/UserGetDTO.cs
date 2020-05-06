using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class UserGetDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }

        public List<ClientGetDTO> Clients { get; set; }

        public List<TareaGetDTO> Tasks { get; set; }

        public UserGetDTO() { }
    }
}
