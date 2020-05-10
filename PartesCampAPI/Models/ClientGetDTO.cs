using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class ClientGetDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<LandGetInTaskDTO> Land { get; set; }

        public int UserID { get; set; }


        ClientGetDTO() { }
    }
}
