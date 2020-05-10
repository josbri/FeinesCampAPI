using PartesCampAPI.Models;
using PartesCampAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services
{
    public class UserResponse : BaseResponse
    {
        public User User { get; private set; }

        /// <summary>
        /// Passes success, message and client to the BaseResponse class.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="user"></param>
        private UserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        /// <summary>
        /// If we pass a user, we are creating a success response (only have user if created).
        /// </summary>
        /// <param name="user">Saved user</param>
        public UserResponse(User user) : this(true, string.Empty, user) { }


        /// <summary>
        /// If we pass a string, we create a error response.
        /// </summary>
        /// <param name="message">Error message</param>
        public UserResponse(string message) : this(false, message, null) { }
    }
}
