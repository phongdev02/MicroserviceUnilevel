using Microsoft.EntityFrameworkCore;
using ChucvuPhanquyen.Models;

namespace ChucvuPhanquyen.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { 
        
        }

        public DbSet<ChucVu> chucVus { get; set; }
        public DbSet<NhomQuyenTruyCap> nhomQuyenTruyCaps { get; set; }
        public DbSet<Quyen> quyens {  get; set; }
        public DbSet<QuyenTruyCap> quyenTruyCaps { get; set; }
        public DbSet<NhomChucVu> nhomChucVus { get; set; }
        public DbSet<CapQuyen> CapQuyens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CapQuyen>()
                .HasKey(cq => new { cq.QuyenTruycapId, cq.ChucvuId });

           /* modelBuilder.Entity<CapQuyen>()
                .HasOne(cq => cq.QuyenTruyCap)
                .WithMany(qtc => qtc.CapQuyens)
                .HasForeignKey(cq => cq.QuyenTruycapId);

            modelBuilder.Entity<CapQuyen>()
                .HasOne(cq => cq.ChucVu)
                .WithMany(cv => cv.CapQuyens)
                .HasForeignKey(cq => cq.ChucvuId);*/


        }

    }
}
