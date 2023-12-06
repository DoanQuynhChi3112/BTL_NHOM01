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
        [Key]
        public string DonHangID { get; set; } 
        public string MaKH { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public string MaNV { get; set; }
        
    }
}