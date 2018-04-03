using System;
using System.Collections.Generic;
using System.Text;

namespace ImageSearch.Core
{
    [Serializable]
    public class SearchException : Exception
    {
        public int Code { get; set; }
        public SearchException()
        {
            Code = -1;
        }
        public SearchException(string message) : base(message)
        {
        }

        public SearchException(int code, string message) : base(message)
        {
            Code = code;
        }

    }
}
