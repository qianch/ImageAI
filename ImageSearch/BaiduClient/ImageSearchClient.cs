using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baidu.Aip.ImageSearch;

namespace ImageSearch.Web.BaiduClient
{
    public class ImageSearchClient
    {
        private const string _appID = "";
        private const string _apiKey = "";
        private const string _secretKey = "";
        public Baidu.Aip.ImageSearch.ImageSearch ImageSearch { get; set; }
        public ImageSearchClient()
        {
            ImageSearch = new Baidu.Aip.ImageSearch.ImageSearch(_apiKey, _secretKey);
        }
    }
}
