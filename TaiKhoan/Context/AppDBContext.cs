using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaiKhoan.Models;

namespace TaiKhoan.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Nhanvien> Nhanviens { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
