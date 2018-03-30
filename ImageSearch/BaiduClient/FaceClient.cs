using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baidu.Aip.Face;

namespace ImageSearchApp.BaiduClient
{
    public class FaceClient
    {
        private const string _appID = "11022177";
        private const string _apiKey = "noWmGRpSMf7FoQhcioEFxo3v";
        private const string _secretKey = "rtaMcXPOmgoEDv2iSqoBkIzQ8Qh2FCo9";
        public Face Face { get; set; }
        public FaceClient()
        {
            Face = new Face(_apiKey, _secretKey);
        }
    }
}
