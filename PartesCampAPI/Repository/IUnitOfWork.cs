using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
