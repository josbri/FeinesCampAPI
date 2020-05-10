using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services.Communication
{
    public class LandResponse : BaseResponse
    {

        public Land Land { get; private set; }

        private LandResponse(bool success, string message, Land land) : base(success, message)
        {
            Land = land;
        }

        public LandResponse(Land land) : this(true, string.Empty, land) { }

        public LandResponse(string message) : this(false, message, null) { }
    }
}
