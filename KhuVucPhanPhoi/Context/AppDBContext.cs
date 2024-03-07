using Microsoft.EntityFrameworkCore;
using KhuVucPhanPhoi.Models;

namespace KhuVucPhanPhoi.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { 
        
        }
        
        DbSet<NhaPhanPhoi> nhaPhanPhois { get; set; }
        DbSet<KhuVuc> khuVucs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
