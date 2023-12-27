using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BTLNHOM01.Models;
namespace BTLNHOM01.Models
{
    [Table("NhaCungCaps")]
    public class NhaCungCap
    {
        [Key]
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        [AllowHtml]
        public string DiachiNCC { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                      ErrorMessage = "Entered phone format is not valid.")]
        public string SoDTNCC { get; set; }
    }   
}