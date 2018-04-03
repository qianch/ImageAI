using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSearch.Web.Models
{
    public class Identity
    {
        public int ID { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        public string Name { get; set; }

        [Display(Name = "身份证号码")]
        [Required(ErrorMessage = "身份证号码必填")]
        public string CardNO { get; set; }
        public string Result { get; set; }
    }
}
