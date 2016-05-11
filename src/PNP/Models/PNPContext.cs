using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace PNP.Models
{
    public class PNPContext : DbContext
    {
        public virtual DbSet<Story> Stories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PNP;integrated security = True");
        }
    }
}
