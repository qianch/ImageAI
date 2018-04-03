using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSearch.Web.Models
{
    public class Dish
    {
        public int ID { get; set; }
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Display(Name = "图片大小 (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public long ImgSize { get; set; }

        [Display(Name = "图片内容")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public string ImgContent { get; set; }

        [Display(Name = "图片类型")]
        public string ImgType { get; set; }

        [Display(Name = "解析结果")]
        public string Data { get; set; }

        [Display(Name = "上传时间 (UTC)")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime UploadDT { get; set; }
    }
}
