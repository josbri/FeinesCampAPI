using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services.Communication
{
    public class ClientResponse : BaseResponse
    {
        public Client Client { get; private set; }

        /// <summary>
        /// Passes success, message and client to the BaseResponse class.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="client"></param>
        private ClientResponse(bool success, string message, Client client) : base(success, message)
        {
            Client = client;
        }

        /// <summary>
        /// If we pass a client, we are creating a success response (only have client if created).
        /// </summary>
        /// <param name="client">Saved client</param>
        public ClientResponse(Client client) : this(true, string.Empty, client) { }


        /// <summary>
        /// If we pass a string, we create a error response.
        /// </summary>
        /// <param name="message">Error message</param>
        public ClientResponse(string message) : this(false, message, null) { }
    }
}
