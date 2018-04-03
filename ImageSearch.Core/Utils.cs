using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace ImageSearch.Core
{
    public class Utils
    {
        public static string ParseQueryString(Dictionary<string, string> querys)
        {
            if (querys.Count == 0)
            {
                return "";
            }
            return querys
                .Select(pair => pair.Key + "=" + pair.Value)
                .Aggregate((a, b) => a + "&" + b);
        }

        public static string UriEncode(string input, bool encodeSlash = false)
        {
            var builder = new StringBuilder();
            foreach (var b in Encoding.UTF8.GetBytes(input))
                if (b >= 'a' && b <= 'z' || b >= 'A' && b <= 'Z' || b >= '0' && b <= '9' || b == '_' || b == '-' ||
                    b == '~' || b == '.')
                    builder.Append((char)b);
                else if (b == '/')
                    if (encodeSlash)
                        builder.Append("%2F");
                    else
                        builder.Append((char)b);
                else
                    builder.Append('%').Append(b.ToString("X2"));
            return builder.ToString();
        }

        /// <summary>
        ///     read stream to string. Will close the steam !
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="enc"></param>
        /// <returns></returns>
        public static string StreamToString(Stream ss, Encoding enc)
        {
            string ret;
            using (var reader = new StreamReader(ss, enc))
            {
                ret = reader.ReadToEnd();
            }
            ss.Close();
            return ret;
        }

        /// <summary>
        ///     Stream to bytes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}
