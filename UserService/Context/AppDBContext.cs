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

        //table area
        public DbSet<KhuVuc> khuVucs { get; set; }
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
        public DbSet<Buoi> Buois { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CapQuyen>()
                .HasKey(cq => new { cq.QuyenTruycapId, cq.ChucvuId });

            modelBuilder.Entity<Nhanvien>()
            .HasOne(nv => nv.ChucVu)            // Một nhân viên chỉ có một chức vụ
            .WithMany(cv => cv.Nhanvien)        // Một chức vụ có thể có nhiều nhân viên
            .HasForeignKey(nv => nv.ChucvuId);

            modelBuilder.Entity<NhaPhanPhoi>()
            .HasMany(e => e.Nhanvien)
            .WithOne(e => e.nhaPhanPhoi)
            .HasForeignKey(e => e.nppID)
            .HasPrincipalKey(e => e.nppID);

            modelBuilder.Entity<KhuVuc>()
            .HasMany(e => e.NhaPhanPhois)
            .WithOne(e => e.KhuVuc)
            .HasForeignKey(e => e.KhuvucID)
            .HasPrincipalKey(e => e.KhuvucCode);

            //set foreign key for ViengTham
            modelBuilder.Entity<ViengTham>()
            .HasOne(nv => nv.buois)            // Một nhân viên chỉ có một chức vụ
            .WithMany(cv => cv.ViengThams)        // Một chức vụ có thể có nhiều nhân viên
            .HasForeignKey(nv => nv.buoiID);

            /*modelBuilder.Entity<Buoi>()
            .HasMany(e => e.ViengThams)
            .WithOne(e => e.buois)
            .HasForeignKey(e => e.buoiID)
            .HasPrincipalKey(e => e.buoiID);

            modelBuilder.Entity<Nhanvien>()
            .HasMany(nv => nv.ViengThams)
            .WithOne(vt => vt.Nhanven)// Một nhân viên chỉ có một chức vụ
            .HasForeignKey(vt => vt.NguoiTaoID)
            .HasPrincipalKey(nv => nv.NvId);*/

            //set key Nguoi Tham Du
            modelBuilder.Entity<DanhSachLichViengTham>()
              .HasKey(ds => new { ds.viengthamID , ds.taikhoanID});

            modelBuilder.Entity<Buoi>().HasData(
                    new Buoi { buoiID = 1, tenBuoi = "Buổi sáng" },
                    new Buoi { buoiID = 2, tenBuoi = "Buổi chiều" },
                    new Buoi { buoiID = 3, tenBuoi = "Cả ngày" }
                 );

        }
    }
}
