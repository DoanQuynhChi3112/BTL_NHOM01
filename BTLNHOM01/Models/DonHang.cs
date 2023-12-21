using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLNHOM01.Models
{
    [Table("DonHangs")]
    public class DonHang
    {       
        public string DonHangID { get; set; } 
        public string MaHang { get; set; } 
        [ForeignKey("MaHang")]
        public DanhMucHang? DanhMucHang { get; set; }
        public string MaKH { get; set; }
        [ForeignKey("MaKH")]
        public KhachHang? KhachHang { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public string MaNV { get; set; }
        [ForeignKey("MaNV")]
        public NhanVien? NhanVien { get; set; }
        
        
    }
}