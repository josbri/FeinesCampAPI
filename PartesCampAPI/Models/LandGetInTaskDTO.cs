using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class LandGetInTaskDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int ClientID { get; set; }

        public ClientGetInLandDTO Client {get;set;}


        public LandGetInTaskDTO() { }
    }
}
