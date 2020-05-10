using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services.Communication
{
    public class TaskResponse : BaseResponse
    {
        public Tarea Task { get; private set; }


        private TaskResponse(bool success, string message, Tarea task) : base(success, message)
        {
            Task = task;
        }


        public TaskResponse(Tarea task) : this(true, string.Empty, task) { }

        public TaskResponse(string message) : this(false, message, null) { }

    }
}
