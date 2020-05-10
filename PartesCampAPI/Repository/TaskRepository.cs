using PartesCampAPI.data;
using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public class TaskRepository : RepositoryBase<Tarea>, ITaskRepository
    {
        public TaskRepository(PartesCampContext context) : base(context) { }
    
    }
}
