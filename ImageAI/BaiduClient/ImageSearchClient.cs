using Baidu.Aip.ImageSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAI.BaiduClient
{
    public class ImageSearchClient
    {
        private const string _appID = "11021488";
        private const string _apiKey = "ZQCZGBbfx603o8HMqbGjesaY";
        private const string _secretKey = "sbaGE6eTq1Q0knt2IxIrzr0FICzRnjcM";
        public ImageSearch ImageSearch { get; set; }
        public ImageSearchClient()
        {
            ImageSearch = new Baidu.Aip.ImageSearch.ImageSearch(_apiKey, _secretKey);
        }
    }
}
