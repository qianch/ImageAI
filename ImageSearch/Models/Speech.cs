using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSearch.Web.Models
{
    public class Speech
    {
        public int ID { get; set; }

        [Display(Name = "文本")]
        [Required(ErrorMessage = "文本必填")]
        [StringLength(100, MinimumLength = 3)]
        public string Text { get; set; }

        [Display(Name = "语速")]
        public int Speed { get; set; }

        [Display(Name ="音量")]
        public int Volume { get; set; }
    }
}
