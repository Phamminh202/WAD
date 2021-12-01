using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace T2010A_WAD.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên nhãn hiệu")]
        public string BrandName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ảnh nhãn hiệu")]
        public string BrandImage { get; set; }
        public string About { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}