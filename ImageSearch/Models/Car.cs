using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSearch.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Img Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public long ImgSize { get; set; }

        [DisplayFormat(DataFormatString = "{0:N1}")]
        public string ImgContent { get; set; }

        public string ImgType { get; set; }
        public string Data { get; set; }

        [Display(Name = "Uploaded (UTC)")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime UploadDT { get; set; }
    }
}
