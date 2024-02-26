using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Nhanvien.Models;

namespace Nhanvien.Context;

public partial class UnilevelContext : DbContext
{
    public UnilevelContext()
    {
    }

    public UnilevelContext(DbContextOptions<UnilevelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiViet> BaiViets { get; set; }

    public virtual DbSet<BinhLuan> BinhLuans { get; set; }

    public virtual DbSet<CauHoi> CauHois { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<CongViec> CongViecs { get; set; }

    public virtual DbSet<DapAn> DapAns { get; set; }

    public virtual DbSet<DapAnK> DapAnKs { get; set; }

    public virtual DbSet<KetQuaK> KetQuaKs { get; set; }

    public virtual DbSet<KhaoSat> KhaoSats { get; set; }

    public virtual DbSet<KhuVuc> KhuVucs { get; set; }

    public virtual DbSet<LichTham> LichThams { get; set; }

    public virtual DbSet<NgoiThamGiaCv> NgoiThamGiaCvs { get; set; }

    public virtual DbSet<NguoiThamGiaK> NguoiThamGiaKs { get; set; }

    public virtual DbSet<NhaPhanPhoi> NhaPhanPhois { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NhanVienPhuTrach> NhanVienPhuTraches { get; set; }

    public virtual DbSet<NhomChucVu> NhomChucVus { get; set; }

    public virtual DbSet<NhomQuyenTruyCap> NhomQuyenTruyCaps { get; set; }

    public virtual DbSet<PhanCapNv> PhanCapNvs { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<QuyenTruyCap> QuyenTruyCaps { get; set; }

    public virtual DbSet<TepBaoCao> TepBaoCaos { get; set; }

    public virtual DbSet<ThongBao> ThongBaos { get; set; }

    public virtual DbSet<ThongBaoNv> ThongBaoNvs { get; set; }

    public virtual DbSet<ThuVien> ThuViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PHONG_MSI_15\\SQLEXPRESS;Initial Catalog=unilevel;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiViet>(entity =>
        {
            entity.ToTable("BaiViet");

            entity.Property(e => e.BaivietId).HasColumnName("baivietID");
            entity.Property(e => e.DuongDan)
                .HasMaxLength(1500)
                .HasColumnName("duongDan");
            entity.Property(e => e.Mota)
                .HasMaxLength(1500)
                .HasColumnName("mota");
            entity.Property(e => e.Ngaytao)
                .HasColumnType("datetime")
                .HasColumnName("ngaytao");
            entity.Property(e => e.NnvId).HasColumnName("nnvID");
            entity.Property(e => e.ThuvienId).HasColumnName("thuvienID");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(500)
                .HasColumnName("tieuDe");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");

            entity.HasOne(d => d.Nnv).WithMany(p => p.BaiViets)
                .HasForeignKey(d => d.NnvId)
                .HasConstraintName("FK_BaiViet_NhanVien");

            entity.HasOne(d => d.Thuvien).WithMany(p => p.BaiViets)
                .HasForeignKey(d => d.ThuvienId)
                .HasConstraintName("FK_BaiViet_ThuVien");
        });

        modelBuilder.Entity<BinhLuan>(entity =>
        {
            entity.ToTable("BinhLuan");

            entity.Property(e => e.BinhluanId).HasColumnName("binhluanID");
            entity.Property(e => e.NoidungBl)
                .HasMaxLength(500)
                .HasColumnName("noidungBL");
            entity.Property(e => e.SoSao).HasColumnName("soSao");
        });

        modelBuilder.Entity<CauHoi>(entity =>
        {
            entity.ToTable("CauHoi");

            entity.Property(e => e.CauhoiId)
                .ValueGeneratedNever()
                .HasColumnName("cauhoiID");
            entity.Property(e => e.KhaosatId).HasColumnName("khaosatID");
            entity.Property(e => e.NhieuLuaChon).HasColumnName("nhieuLuaChon");
            entity.Property(e => e.NoidungCh)
                .HasMaxLength(500)
                .HasColumnName("noidungCH");

            entity.HasOne(d => d.Khaosat).WithMany(p => p.CauHois)
                .HasForeignKey(d => d.KhaosatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CauHoi_KhaoSat");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.ToTable("ChucVu");

            entity.Property(e => e.ChucvuId).HasColumnName("chucvuID");
            entity.Property(e => e.NgayTao)
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.NhomcvId).HasColumnName("nhomcvID");
            entity.Property(e => e.TenCv)
                .HasMaxLength(250)
                .HasColumnName("tenCV");

            entity.HasOne(d => d.Nhomcv).WithMany(p => p.ChucVus)
                .HasForeignKey(d => d.NhomcvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChucVu_NhomChucVu");
        });

        modelBuilder.Entity<CongViec>(entity =>
        {
            entity.ToTable("CongViec");

            entity.Property(e => e.CongviecId).HasColumnName("congviecID");
            entity.Property(e => e.BinhluanId).HasColumnName("binhluanID");
            entity.Property(e => e.LichthamId).HasColumnName("lichthamID");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("mota");
            entity.Property(e => e.NgayBd)
                .HasColumnType("datetime")
                .HasColumnName("ngayBD");
            entity.Property(e => e.NgayKt)
                .HasColumnType("datetime")
                .HasColumnName("ngayKT");
            entity.Property(e => e.TieudeCv)
                .HasMaxLength(500)
                .HasColumnName("tieudeCV");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");

            entity.HasOne(d => d.Binhluan).WithMany(p => p.CongViecs)
                .HasForeignKey(d => d.BinhluanId)
                .HasConstraintName("FK_CongViec_BinhLuan");

            entity.HasOne(d => d.Lichtham).WithMany(p => p.CongViecs)
                .HasForeignKey(d => d.LichthamId)
                .HasConstraintName("FK_CongViec_LichTham");
        });

        modelBuilder.Entity<DapAn>(entity =>
        {
            entity.ToTable("DapAn");

            entity.Property(e => e.DapanId).HasColumnName("dapanID");
            entity.Property(e => e.CauhoiId).HasColumnName("cauhoiID");
            entity.Property(e => e.DapanKhac).HasColumnName("dapanKhac");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(1500)
                .HasColumnName("hinhanh");
            entity.Property(e => e.NoidungDa)
                .HasMaxLength(500)
                .HasColumnName("noidungDA");

            entity.HasOne(d => d.Cauhoi).WithMany(p => p.DapAns)
                .HasForeignKey(d => d.CauhoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DapAn_CauHoi");
        });

        modelBuilder.Entity<DapAnK>(entity =>
        {
            entity.HasKey(e => new { e.KetquaId, e.DapanId });

            entity.ToTable("DapAnKS");

            entity.Property(e => e.KetquaId).HasColumnName("ketquaID");
            entity.Property(e => e.DapanId).HasColumnName("dapanID");
            entity.Property(e => e.NoidungDakhac)
                .HasMaxLength(500)
                .HasColumnName("noidungDAKhac");

            entity.HasOne(d => d.Dapan).WithMany(p => p.DapAnKs)
                .HasForeignKey(d => d.DapanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DapAnKS_DapAn");

            entity.HasOne(d => d.Ketqua).WithMany(p => p.DapAnKs)
                .HasForeignKey(d => d.KetquaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DapAnKS_KetQuaKS");
        });

        modelBuilder.Entity<KetQuaK>(entity =>
        {
            entity.HasKey(e => e.KetquaId);

            entity.ToTable("KetQuaKS");

            entity.Property(e => e.KetquaId).HasColumnName("ketquaID");
            entity.Property(e => e.CauhoiId).HasColumnName("cauhoiID");
            entity.Property(e => e.KhaosatId).HasColumnName("khaosatID");
            entity.Property(e => e.NvId).HasColumnName("nvID");

            entity.HasOne(d => d.Cauhoi).WithMany(p => p.KetQuaKs)
                .HasForeignKey(d => d.CauhoiId)
                .HasConstraintName("FK_KetQuaKS_CauHoi");

            entity.HasOne(d => d.NguoiThamGiaK).WithMany(p => p.KetQuaKs)
                .HasForeignKey(d => new { d.NvId, d.KhaosatId })
                .HasConstraintName("FK_KetQuaKS_NguoiThamGiaKS");
        });

        modelBuilder.Entity<KhaoSat>(entity =>
        {
            entity.ToTable("KhaoSat");

            entity.Property(e => e.KhaosatId).HasColumnName("khaosatID");
            entity.Property(e => e.NgayBd)
                .HasColumnType("datetime")
                .HasColumnName("ngayBD");
            entity.Property(e => e.NgayKt)
                .HasColumnType("datetime")
                .HasColumnName("ngayKT");
            entity.Property(e => e.TenTieuDe)
                .HasMaxLength(250)
                .HasColumnName("tenTieuDe");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");
        });

        modelBuilder.Entity<KhuVuc>(entity =>
        {
            entity.ToTable("KhuVuc");

            entity.Property(e => e.KhuvucId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("khuvucID");
            entity.Property(e => e.TenKv)
                .HasMaxLength(500)
                .HasColumnName("tenKV");
        });

        modelBuilder.Entity<LichTham>(entity =>
        {
            entity.ToTable("LichTham");

            entity.Property(e => e.LichthamId).HasColumnName("lichthamID");
            entity.Property(e => e.Buoi).HasColumnName("buoi");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("mota");
            entity.Property(e => e.NgayTham)
                .HasColumnType("datetime")
                .HasColumnName("ngayTham");
            entity.Property(e => e.NguoiTao).HasColumnName("nguoiTao");
            entity.Property(e => e.NhacNho)
                .HasColumnType("datetime")
                .HasColumnName("nhacNho");
            entity.Property(e => e.Nhaphanphoi).HasColumnName("nhaphanphoi");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.NguoiTaoNavigation).WithMany(p => p.LichThams)
                .HasForeignKey(d => d.NguoiTao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LichTham_NhanVien");

            entity.HasOne(d => d.NhaphanphoiNavigation).WithMany(p => p.LichThams)
                .HasForeignKey(d => d.Nhaphanphoi)
                .HasConstraintName("FK_LichTham_NhaPhanPhoi");
        });

        modelBuilder.Entity<NgoiThamGiaCv>(entity =>
        {
            entity.HasKey(e => new { e.CongviecId, e.NvId });

            entity.ToTable("NgoiThamGiaCV");

            entity.Property(e => e.CongviecId).HasColumnName("congviecID");
            entity.Property(e => e.NvId).HasColumnName("nvID");
            entity.Property(e => e.Chucvu).HasColumnName("chucvu");
            entity.Property(e => e.TepbaocaoId).HasColumnName("tepbaocaoID");

            entity.HasOne(d => d.Congviec).WithMany(p => p.NgoiThamGiaCvs)
                .HasForeignKey(d => d.CongviecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NgoiThamGiaCV_CongViec");

            entity.HasOne(d => d.Nv).WithMany(p => p.NgoiThamGiaCvs)
                .HasForeignKey(d => d.NvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NgoiThamGiaCV_NhanVien");

            entity.HasOne(d => d.Tepbaocao).WithMany(p => p.NgoiThamGiaCvs)
                .HasForeignKey(d => d.TepbaocaoId)
                .HasConstraintName("FK_NgoiThamGiaCV_TepBaoCao");
        });

        modelBuilder.Entity<NguoiThamGiaK>(entity =>
        {
            entity.HasKey(e => new { e.NvId, e.KhaosatId });

            entity.ToTable("NguoiThamGiaKS");

            entity.Property(e => e.NvId).HasColumnName("nvID");
            entity.Property(e => e.KhaosatId).HasColumnName("khaosatID");
            entity.Property(e => e.VaitroNguoiThamGia).HasColumnName("vaitroNguoiThamGia");

            entity.HasOne(d => d.Khaosat).WithMany(p => p.NguoiThamGiaKs)
                .HasForeignKey(d => d.KhaosatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NguoiThamGiaKS_KhaoSat");

            entity.HasOne(d => d.Nv).WithMany(p => p.NguoiThamGiaKs)
                .HasForeignKey(d => d.NvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NguoiThamGiaKS_NhanVien");
        });

        modelBuilder.Entity<NhaPhanPhoi>(entity =>
        {
            entity.ToTable("NhaPhanPhoi");

            entity.Property(e => e.NhaphanphoiId).HasColumnName("nhaphanphoiID");
            entity.Property(e => e.Diachi)
                .HasMaxLength(500)
                .HasColumnName("diachi");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("email");
            entity.Property(e => e.KhuvucId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("khuvucID");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNpp)
                .HasMaxLength(250)
                .HasColumnName("tenNPP");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");

            entity.HasOne(d => d.Khuvuc).WithMany(p => p.NhaPhanPhois)
                .HasForeignKey(d => d.KhuvucId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhaPhanPhoi_KhuVuc");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.NvId);

            entity.ToTable("NhanVien");

            entity.Property(e => e.NvId).HasColumnName("nvID");
            entity.Property(e => e.ChucvuId).HasColumnName("chucvuID");
            entity.Property(e => e.GmailNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gmailNV");
            entity.Property(e => e.HinhanhNv)
                .HasMaxLength(1500)
                .HasColumnName("hinhanhNV");
            entity.Property(e => e.HoTen)
                .HasMaxLength(250)
                .HasColumnName("hoTen");
            entity.Property(e => e.MatkhauNv)
                .HasMaxLength(150)
                .HasColumnName("matkhauNV");
            entity.Property(e => e.NgayLam)
                .HasColumnType("datetime")
                .HasColumnName("ngayLam");
            entity.Property(e => e.NgayTao)
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TkId).HasColumnName("tkID");
            entity.Property(e => e.TrangthaiNv).HasColumnName("trangthaiNV");

            entity.HasOne(d => d.Chucvu).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.ChucvuId)
                .HasConstraintName("FK_NhanVien_ChucVu");
        });

        modelBuilder.Entity<NhanVienPhuTrach>(entity =>
        {
            entity.HasKey(e => new { e.NhaphanphoiId, e.NvId });

            entity.ToTable("NhanVienPhuTrach");

            entity.Property(e => e.NhaphanphoiId).HasColumnName("nhaphanphoiID");
            entity.Property(e => e.NvId).HasColumnName("nvID");
            entity.Property(e => e.QuanLy).HasColumnName("quanLy");

            entity.HasOne(d => d.Nhaphanphoi).WithMany(p => p.NhanVienPhuTraches)
                .HasForeignKey(d => d.NhaphanphoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVienPhuTrach_NhaPhanPhoi");

            entity.HasOne(d => d.Nv).WithMany(p => p.NhanVienPhuTraches)
                .HasForeignKey(d => d.NvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVienPhuTrach_NhanVien");
        });

        modelBuilder.Entity<NhomChucVu>(entity =>
        {
            entity.HasKey(e => e.NhomcvId);

            entity.ToTable("NhomChucVu");

            entity.Property(e => e.NhomcvId).HasColumnName("nhomcvID");
            entity.Property(e => e.Quyen).HasColumnName("quyen");
            entity.Property(e => e.TenNcv)
                .HasMaxLength(150)
                .HasColumnName("tenNCV");
        });

        modelBuilder.Entity<NhomQuyenTruyCap>(entity =>
        {
            entity.HasKey(e => e.NhomQuyenId);

            entity.ToTable("NhomQuyenTruyCap");

            entity.Property(e => e.NhomQuyenId).HasColumnName("nhomQuyenID");
            entity.Property(e => e.TenNq)
                .HasMaxLength(250)
                .HasColumnName("tenNQ");
        });

        modelBuilder.Entity<PhanCapNv>(entity =>
        {
            entity.HasKey(e => new { e.NvId, e.NvqlId });

            entity.ToTable("PhanCapNV");

            entity.Property(e => e.NvId).HasColumnName("nvID");
            entity.Property(e => e.NvqlId).HasColumnName("nvqlID");
            entity.Property(e => e.Trencap).HasColumnName("trencap");

            entity.HasOne(d => d.Nv).WithMany(p => p.PhanCapNvNvs)
                .HasForeignKey(d => d.NvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanCapNV_NhanVien");

            entity.HasOne(d => d.Nvql).WithMany(p => p.PhanCapNvNvqls)
                .HasForeignKey(d => d.NvqlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanCapNV_NhanVien1");
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.ToTable("Quyen");

            entity.Property(e => e.QuyenId).HasColumnName("quyenID");
            entity.Property(e => e.TenQuyen)
                .HasMaxLength(150)
                .HasColumnName("tenQuyen");
        });

        modelBuilder.Entity<QuyenTruyCap>(entity =>
        {
            entity.ToTable("QuyenTruyCap");

            entity.Property(e => e.QuyenTruycapId).HasColumnName("quyenTruycapID");
            entity.Property(e => e.NhomQuyenId).HasColumnName("nhomQuyenID");
            entity.Property(e => e.QuyenId).HasColumnName("quyenID");
            entity.Property(e => e.TenQuyenTc)
                .HasMaxLength(150)
                .HasColumnName("tenQuyenTC");

            entity.HasOne(d => d.NhomQuyen).WithMany(p => p.QuyenTruyCaps)
                .HasForeignKey(d => d.NhomQuyenId)
                .HasConstraintName("FK_QuyenTruyCap_NhomQuyenTruyCap");

            entity.HasOne(d => d.Quyen).WithMany(p => p.QuyenTruyCaps)
                .HasForeignKey(d => d.QuyenId)
                .HasConstraintName("FK_QuyenTruyCap_Quyen");

            entity.HasMany(d => d.Chucvus).WithMany(p => p.QuyenTruycaps)
                .UsingEntity<Dictionary<string, object>>(
                    "CapQuyen",
                    r => r.HasOne<ChucVu>().WithMany()
                        .HasForeignKey("ChucvuId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CapQuyen_ChucVu"),
                    l => l.HasOne<QuyenTruyCap>().WithMany()
                        .HasForeignKey("QuyenTruycapId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CapQuyen_QuyenTruyCap"),
                    j =>
                    {
                        j.HasKey("QuyenTruycapId", "ChucvuId");
                        j.ToTable("CapQuyen");
                        j.IndexerProperty<int>("QuyenTruycapId").HasColumnName("quyenTruycapID");
                        j.IndexerProperty<int>("ChucvuId").HasColumnName("chucvuID");
                    });
        });

        modelBuilder.Entity<TepBaoCao>(entity =>
        {
            entity.ToTable("TepBaoCao");

            entity.Property(e => e.TepbaocaoId).HasColumnName("tepbaocaoID");
            entity.Property(e => e.NgayNhap)
                .HasColumnType("datetime")
                .HasColumnName("ngayNhap");
            entity.Property(e => e.TenTep)
                .HasMaxLength(500)
                .HasColumnName("tenTep");
            entity.Property(e => e.TepBc).HasColumnName("tepBC");
        });

        modelBuilder.Entity<ThongBao>(entity =>
        {
            entity.ToTable("ThongBao");

            entity.Property(e => e.ThongbaoId).HasColumnName("thongbaoID");
            entity.Property(e => e.Noidung)
                .HasMaxLength(500)
                .HasColumnName("noidung");
            entity.Property(e => e.ThongbaoHeThong).HasColumnName("thongbaoHeThong");
        });

        modelBuilder.Entity<ThongBaoNv>(entity =>
        {
            entity.HasKey(e => new { e.ThongbaoId, e.NvId });

            entity.ToTable("ThongBaoNV");

            entity.Property(e => e.ThongbaoId).HasColumnName("thongbaoID");
            entity.Property(e => e.NvId).HasColumnName("nvID");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");

            entity.HasOne(d => d.Nv).WithMany(p => p.ThongBaoNvs)
                .HasForeignKey(d => d.NvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThongBaoNV_NhanVien");

            entity.HasOne(d => d.Thongbao).WithMany(p => p.ThongBaoNvs)
                .HasForeignKey(d => d.ThongbaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThongBaoNV_ThongBao");
        });

        modelBuilder.Entity<ThuVien>(entity =>
        {
            entity.ToTable("ThuVien");

            entity.Property(e => e.ThuvienId).HasColumnName("thuvienID");
            entity.Property(e => e.DuongDan)
                .HasMaxLength(1500)
                .HasColumnName("duongDan");
            entity.Property(e => e.NgayNhap)
                .HasColumnType("datetime")
                .HasColumnName("ngayNhap");
            entity.Property(e => e.Ten)
                .HasMaxLength(500)
                .HasColumnName("ten");
            entity.Property(e => e.Tep).HasColumnName("tep");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
