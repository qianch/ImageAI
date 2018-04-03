using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baidu.Aip.ImageSearch;

namespace ImageSearch.Web.BaiduClient
{
    public class ImageSearchClient
    {
        private const string _appID = "11021488";
        private const string _apiKey = "ZQCZGBbfx603o8HMqbGjesaY";
        private const string _secretKey = "sbaGE6eTq1Q0knt2IxIrzr0FICzRnjcM";
        public Baidu.Aip.ImageSearch.ImageSearch ImageSearch { get; set; }
        public ImageSearchClient()
        {
            ImageSearch = new Baidu.Aip.ImageSearch.ImageSearch(_apiKey, _secretKey);
        }
    }
}
