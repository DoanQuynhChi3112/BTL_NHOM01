using Microsoft.EntityFrameworkCore;
using BTLNHOM01.Data;
using BTLNHOM01.Models;

namespace BTLNHOM01.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {}
        public DbSet<BTLNHOM01.Models.DanhMucHang> DanhMucHang { get; set; } = default!;
        public DbSet<BTLNHOM01.Models.DonHang> DonHang { get; set; } = default!;
        public DbSet<BTLNHOM01.Models.KhachHang> KhachHang { get; set; } = default!;
        public DbSet<BTLNHOM01.Models.NhanVien> NhanVien { get; set; } = default!;
        public DbSet<BTLNHOM01.Models.PhieuNhap> PhieuNhap { get; set; } = default!;
        public DbSet<BTLNHOM01.Models.phieuxuat> phieuxuat { get; set; } = default!;
        public DbSet<BTLNHOM01.Models.NhaCungCap> NhaCungCap { get; set; } = default!;
        
    }
}