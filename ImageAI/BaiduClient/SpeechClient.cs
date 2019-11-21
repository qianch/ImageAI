using Baidu.Aip.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAI.BaiduClient
{
    public class SpeechClient
    {
        private const string _appID = "14588026";
        private const string _appKey = "WHAHTdOdMdLoyM2FVWG0ppbj";
        private const string _secretKey = "2TxizQaauRLKHiUqGKSeikb8eqMUMDYp";

        public Tts SpeechSynthesis { get; set; }

        public SpeechClient()
        {
            SpeechSynthesis = new Baidu.Aip.Speech.Tts(_appKey, _secretKey)
            {
                Timeout = 6000
            };
        }
    }
}
