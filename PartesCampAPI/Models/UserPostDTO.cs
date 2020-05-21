using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class UserPostDTO
    {

        public string Name { get; set; }

        public string JwtID { get; set; }

        public string Email { get; set; }


        public UserPostDTO() { }
    }
}
