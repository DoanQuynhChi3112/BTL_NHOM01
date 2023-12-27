using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLNHOM01.Models
{
    [Table("phieuxuats")]
    public class phieuxuat
    {
        [Key]
         public string MaPX{ get; set; }    
        public string DonHangID { get; set; }
        [ForeignKey("DonHangID")]
        public DonHang? DonHang { get; set; }
        public string TenHang { get; set; }
        [ForeignKey("TenHang")]
        public DanhMucHang? DanhMucHang { get; set; }
        public string MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public NhaCungCap? NhaCungCap { get; set; }
        public int Soluong { get; set; }
        public string thanhtien { get; set; }
        [DataType(DataType.Date)]
        public DateTime Ngaytao { get; set; }       
    }
}