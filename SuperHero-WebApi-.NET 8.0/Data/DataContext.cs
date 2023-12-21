using Microsoft.EntityFrameworkCore;
using SuperHero_WebApi_.NET_8._0.Entities;

namespace SuperHero_WebApi_.NET_8._0.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        
    }
}
