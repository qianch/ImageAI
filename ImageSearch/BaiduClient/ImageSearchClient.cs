using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baidu.Aip.ImageSearch;

namespace ImageSearchApp.BaiduClient
{
    public class ImageSearchClient
    {
        private string _appID = "11021488";
        private string _apiKey = "ZQCZGBbfx603o8HMqbGjesaY";
        private string _secretKey = "sbaGE6eTq1Q0knt2IxIrzr0FICzRnjcM";
        public Baidu.Aip.ImageSearch.ImageSearch ImageSearch { get; set; }
        public ImageSearchClient()
        {
            ImageSearch = new Baidu.Aip.ImageSearch.ImageSearch(_apiKey, _secretKey);
        }
    }
}
