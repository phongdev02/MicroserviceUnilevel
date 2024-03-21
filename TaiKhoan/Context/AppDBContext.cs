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
        public DbSet<PhanCapNV> PhanCapNVs { get; set; }
        //table phân quyền
        public DbSet<ChucVu> chucVus { get; set; }
        public DbSet<CapQuyen> capQuyens { get; set; }
        public DbSet<Quyen> quyens { get; set; }
        public DbSet<QuyenTruyCap> quyenTruyCaps { get; set; }
        public DbSet<NhomQuyenTruyCap> nhomChucVus { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CapQuyen>()
                .HasKey(cq => new { cq.QuyenTruycapId, cq.ChucvuId });

            modelBuilder.Entity<Nhanvien>()
            .HasOne(nv => nv.ChucVu)            // Một nhân viên chỉ có một chức vụ
            .WithMany(cv => cv.Nhanvien)        // Một chức vụ có thể có nhiều nhân viên
            .HasForeignKey(nv => nv.ChucvuId);
        }
    }
}
