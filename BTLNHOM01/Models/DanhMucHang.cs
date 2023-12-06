using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTLNHOM01.Models
{
    [Table("DanhMucHangs")]
    public class DanhMucHang
    {
        [Key]
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string DonViTinh { get; set; }
        public string SoLuong { get; set; }
        public string GiaSP { get; set; }
    }
}