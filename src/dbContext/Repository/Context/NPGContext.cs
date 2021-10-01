using dbContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.Repository.Context
{
    public class NPGContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=db2;User Id=postgres;Password=********;"); //connection string nasıl oluşturulur 
        }
        public DbSet<movie> movie { get; set; }
        public DbSet<genre> genre { get; set; }
        public DbSet<director> director { get; set; }
        public DbSet<maincast> maincast { get; set; }
        

    }
}
