using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Models
{
    public class UserPostDTO
    {

        public string Name { get; set; }

        public string UserID { get; set; }

        public string Email { get; set; }

        public UserPostDTO(string name, string userID, string email)
        {
            Name = name;
            UserID = userID;
            Email = email;
        }
    }
}
