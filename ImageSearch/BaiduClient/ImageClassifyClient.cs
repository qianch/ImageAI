using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baidu.Aip.ImageClassify;

namespace ImageSearchApp.BaiduClient
{
    public class ImageClassifyClient
    {
        private string _appID = "11007064";
        private string _apiKey = "CysimXMgKBFLcexUqGwGNK6t";
        private string _secretKey = "9wsK72IM764T2CS6i4VUoPgrNZtbQWFa";
        public ImageClassify imageClassify { get; set; }
        public ImageClassifyClient()
        {
            imageClassify = new ImageClassify(_apiKey, _secretKey);
        }
    }
}
