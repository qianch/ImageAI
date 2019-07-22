using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baidu.Aip.ImageClassify;

namespace ImageSearch.Web.BaiduClient
{
    public class ImageClassifyClient
    {
        private const string _appID = "11007064";
        private const string _apiKey = "CysimXMgKBFLcexUqGwGNK6t";
        private const string _secretKey = "9wsK72IM764T2CS6i4VUoPgrNZtbQWFa";
        public ImageClassify ImageClassify { get; set; }
        public ImageClassifyClient()
        {
            ImageClassify = new ImageClassify(_apiKey, _secretKey);
        }
    }
}
