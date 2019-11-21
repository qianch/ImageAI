using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ImageAI.Core
{
    public class SearchServiceBase
    {
        protected string SendRequest(SearchHttpRequest searchRequest)
        {
            return Utils.StreamToString(SendRequetRaw(searchRequest).GetResponseStream(), searchRequest.ContentEncoding);
        }
        protected HttpWebResponse SendRequetRaw(SearchHttpRequest searchRequest)
        {
            var webReq = searchRequest.GenerateWebRequest();
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)webReq.GetResponse();
            }
            catch (WebException e)
            {
                // 网络请求失败应该抛异常
                throw new SearchException((int)e.Status, e.Message);
            }

            if (resp.StatusCode != HttpStatusCode.OK)
                throw new SearchException((int)resp.StatusCode, "Server response code：" + (int)resp.StatusCode);

            return resp;
        }

        protected virtual JObject PostAction(SearchHttpRequest searchRequest)
        {
            var respStr = SendRequest(searchRequest);
            //Console.WriteLine(respStr);
            JObject respObj;
            try
            {
                respObj = JsonConvert.DeserializeObject(respStr) as JObject;
            }
            catch (Exception e)
            {
                // 非json应该抛异常
                throw new SearchException(e.Message + ": " + respStr);
            }

            if (respObj == null)
                throw new SearchException("Empty response, please check input");

            // 服务失败，不抛异常
            //	        if (respObj["error_code"] != null)
            //	        {
            //	            Console.WriteLine((string)respObj["error_msg"]);
            //	            throw new AipException((int)respObj["error_code"], (string)respObj["error_msg"]);
            //	        }
            return respObj;
        }
    }
}
