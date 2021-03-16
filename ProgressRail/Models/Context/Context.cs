using Microsoft.EntityFrameworkCore;
using ProgressRail.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressRail.Models.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option) : base(option) 
        {
            Database.EnsureCreated();
        }

        public DbSet<ToDo> ToDo { get; set; }

    }
}
