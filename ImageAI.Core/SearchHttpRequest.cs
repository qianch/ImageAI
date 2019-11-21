using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace ImageAI.Core
{
    public class SearchHttpRequest
    {
        public enum BodyFormat
        {
            Formed,
            Json
        }

        public Dictionary<string, object> Bodys;

        public BodyFormat BodyType;
        public Encoding ContentEncoding;

        public Dictionary<string, string> Headers;

        public string Method;
        public Dictionary<string, string> Querys;

        /// <summary>
        /// 不带query
        /// </summary>
        public Uri Uri;

        public SearchHttpRequest()
        {
            Headers = new Dictionary<string, string>();
            Querys = new Dictionary<string, string>();
            Bodys = new Dictionary<string, object>();
            BodyType = BodyFormat.Formed;
            ContentEncoding = Encoding.UTF8;
            System.Net.ServicePointManager.Expect100Continue = false;
        }

        public SearchHttpRequest(string uri) : this()
        {
            Uri = new Uri(uri);
        }

        public HttpWebRequest GenerateRquest { get; set; }

        public string UriWithQuery
        {
            get
            {
                var query = Utils.ParseQueryString(Querys);
                return Uri + "?" + query;
            }
        }

        public byte[] ProcessHttpRequest(HttpWebRequest webRequest)
        {
            webRequest.Method = Method;
            webRequest.ReadWriteTimeout = 30000;
            foreach (var header in Headers)
            {
                webRequest.Headers.Add(header.Key, header.Value);
            }
            GenerateRquest = webRequest;
            switch (BodyType)
            {
                case BodyFormat.Formed:
                    {
                        var body = Bodys.Select(pair => pair.Key + "=" + Utils.UriEncode(pair.Value.ToString()))
                        .DefaultIfEmpty("")
                        .Aggregate((a, b) => a + "&" + b);
                        webRequest.ContentType = "application/x-www-form-urlencoded";
                        return ContentEncoding.GetBytes(body);
                    }
                case BodyFormat.Json:
                    {
                        var body = JsonConvert.SerializeObject(Bodys);
                        webRequest.ContentType = "application/json";
                        return ContentEncoding.GetBytes(body);
                    }
            }
            return null;
        }

        public HttpWebRequest GenerateWebRequest()
        {
            var ret = (HttpWebRequest)WebRequest.Create(UriWithQuery);
            ret.ReadWriteTimeout = 30000;
            ret.Timeout = 30000;
            var body = ProcessHttpRequest(ret);
            if (ret.Method.Equals("POST", StringComparison.CurrentCultureIgnoreCase))
            {
                var stream = ret.GetRequestStream();
                stream.Write(body, 0, body.Length);
                stream.Close();
            }
            return ret;
        }
    }
}
