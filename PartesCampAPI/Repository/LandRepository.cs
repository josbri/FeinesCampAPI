using Microsoft.EntityFrameworkCore;
using PartesCampAPI.data;
using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public class LandRepository : RepositoryBase<Land>, ILandRepository
    {

        public LandRepository(PartesCampContext context) : base(context) { }

    }
}
