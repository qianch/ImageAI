using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baidu.Aip.ImageClassify;

namespace ImageSearch.Web.BaiduClient
{
    public class ImageClassifyClient
    {
        private const string _appID = "";
        private const string _apiKey = "";
        private const string _secretKey = "";
        public ImageClassify ImageClassify { get; set; }
        public ImageClassifyClient()
        {
            ImageClassify = new ImageClassify(_apiKey, _secretKey);
        }
    }
}
