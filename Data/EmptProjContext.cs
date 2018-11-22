using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using emptProj.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace emptProj.Data
{
    public class EmptProjContext : DbContext
    {
        public EmptProjContext(DbContextOptions<EmptProjContext> options): base(options)
        {
            
        }        
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
