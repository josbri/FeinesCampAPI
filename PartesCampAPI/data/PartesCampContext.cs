using Microsoft.EntityFrameworkCore;
using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.data
{
    public class PartesCampContext : DbContext
    {
        public DbSet<Land> Lands { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Tarea> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public PartesCampContext(DbContextOptions<PartesCampContext> options) : base(options)
        {

        }

    }
}
