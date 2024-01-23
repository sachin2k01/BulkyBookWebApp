using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class BulkyDBContext:DbContext
    {
        public BulkyDBContext(DbContextOptions<BulkyDBContext> options):base(options) { }

        public DbSet<Category> Categories { get; set; }

    }
}
