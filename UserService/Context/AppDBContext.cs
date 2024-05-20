using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;
using UserService.Models;

namespace UserService.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Area> Areas { get; set; }
        //public DbSet<Position> Positions { get; set; }
        public DbSet<Title> Titles { get; set; }

        public DbSet<Distributor> Distributors { get; set; }

        /*//table area
        public DbSet<Area> khuVucs { get; set; }
        public DbSet<NhaPhanPhoi> nhaPhanPhois { get; set; }

        //table auth
        public DbSet<Nhanvien> Nhanviens { get; set; }
        public DbSet<PhanCapNV> PhanCapNVs { get; set; }
        //table phân quyền
        public DbSet<ChucVu> chucVus { get; set; }
        public DbSet<CapQuyen> capQuyens { get; set; }
        public DbSet<Quyen> quyens { get; set; }
        public DbSet<QuyenTruyCap> quyenTruyCaps { get; set; }
        public DbSet<NhomQuyenTruyCap> nhomQuyenTruyCap { get; set; }

        //vieng Tham
        public DbSet<ViengTham> ViengThams { get; set; }
        public DbSet<Buoi> Buois { get; set; }*/

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<CapQuyen>()
                .HasKey(cq => new { cq.QuyenTruycapId, cq.ChucvuId });*/

            // create foreign key on account
            modelBuilder.Entity<Account>()
                .HasOne(account => account.account) // one table 
                .WithMany(c => c.accounts) // two table
                .HasForeignKey(a => a.managerID) // key ForeignKey
                .IsRequired(false);

            modelBuilder.Entity<Account>()
                .HasOne(account => account.area) // one table 
                .WithMany(c => c.accounts) // two table (thông qua table của hasone thì nó tham chiếu qua table kia để tìm lại phần nhiều của mình)
                .HasForeignKey(a => a.areaCode) // key ForeignKey
                .IsRequired(false);

            modelBuilder.Entity<Account>()
                .HasOne(account => account.title) // one table 
                .WithMany(c => c.accounts) // two table (thông qua table của hasone thì nó tham chiếu qua table kia để tìm lại phần nhiều của mình)
                .HasForeignKey(a => a.titleID) // key ForeignKey
                .IsRequired(true);

            // create key area
            modelBuilder.Entity<Distributor>()
                .HasOne(a=> a.area)
                .WithMany(a=> a.distributors)
                .HasForeignKey(a=> a.areacode)
                .IsRequired(true);

            /*
            modelBuilder.Entity<Buoi>().HasData(
                    new Buoi { buoiID = 1, tenBuoi = "Buổi sáng" },
                    new Buoi { buoiID = 2, tenBuoi = "Buổi chiều" },
                    new Buoi { buoiID = 3, tenBuoi = "Cả ngày" }
                 );*/
            /*            modelBuilder.Entity<Session>().HasData(
                               new Session { buoiID = 1, tenBuoi = "Buổi sáng" },
                               new Session { buoiID = 2, tenBuoi = "Buổi chiều" },
                               new Session { buoiID = 3, tenBuoi = "Cả ngày" }
                            );*/

        }
    }
}
