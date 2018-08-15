using ImageSearch.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageSearch.Web.Framework.Identity
{
    public class IdentitySearch : SearchServiceBase
    {
        private const string SBKRS = "http://www.962222.net/sbkRS.jsp";

        public IdentitySearch() : base()
        {

        }

        protected SearchHttpRequest DefaultRequest(string uri)
        {
            return new SearchHttpRequest(uri)
            {
                Method = "GET",
                BodyType = SearchHttpRequest.BodyFormat.Formed,
                ContentEncoding = Encoding.UTF8
            };
        }

        public string GetReponse(Dictionary<string, string> querys)
        {
            var searchReq = DefaultRequest(SBKRS);
            foreach (var query in querys)
            {
                searchReq.Querys.Add(query.Key, query.Value);
            }
            return SendRequest(searchReq);
        }
    }
}
