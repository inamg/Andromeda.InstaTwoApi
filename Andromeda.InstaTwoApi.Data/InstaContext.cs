using Andromeda.InstaTwoApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Andromeda.InstaTwoApi.Data
{
    public class InstaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Device> Devices { get; set; }

        public InstaContext(DbContextOptions<InstaContext> contextOptions) : base(contextOptions)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=INAMGULLEA3D;Database=KenticoAbc;Trusted_Connection=True;");
                
            base.OnConfiguring(optionsBuilder);
        }
        
       
    }
}