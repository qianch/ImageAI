using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baidu.Aip.Face;

namespace ImageSearch.Web.BaiduClient
{
    public class FaceClient
    {
        private const string _appID = "";
        private const string _apiKey = "";
        private const string _secretKey = "";
        public Face Face { get; set; }
        public FaceClient()
        {
            Face = new Face(_apiKey, _secretKey);
        }
    }
}
