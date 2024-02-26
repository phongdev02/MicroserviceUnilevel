using Microsoft.EntityFrameworkCore;
using TaiKhoan.Models;

namespace TaiKhoan.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { 
        
        }

        public DbSet<Nhanvien> Nhanviens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nhanvien>().HasData(new Nhanvien
            {
                NvId = 1,
                GmailNv = "gmail@gmail.com",
                MatkhauNv = "password123",
                NgayTao = DateTime.Now,
                HoTen = "John Doe",
                NgayLam = DateTime.Now.AddDays(-30),
                TrangthaiNv = true,
                Sdt = "123456789",
                ChucvuId = 1,
                HinhanhNv = "avatar.jpg",
                TkId = 1
            });

            modelBuilder.Entity<Nhanvien>().HasData(new Nhanvien
            {
                NvId = 2,
                GmailNv = "gmail@gmail.com",
                MatkhauNv = "password123",
                NgayTao = DateTime.Now,
                HoTen = "John Doe",
                NgayLam = DateTime.Now.AddDays(-30),
                TrangthaiNv = true,
                Sdt = "123456789",
                ChucvuId = 1,
                HinhanhNv = "avatar.jpg",
                TkId = 1
            });


        }
    }
}
