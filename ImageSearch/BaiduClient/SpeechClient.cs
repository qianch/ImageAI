namespace ImageSearch.Web.BaiduClient
{
    public class SpeechClient
    {
        private const string _appID = "14588026";
        private const string _appKey = "WHAHTdOdMdLoyM2FVWG0ppbj";
        private const string _secretKey = "2TxizQaauRLKHiUqGKSeikb8eqMUMDYp";

        public Baidu.Aip.Speech.Tts SpeechSynthesis { get; set; }

        public SpeechClient()
        {
            SpeechSynthesis = new Baidu.Aip.Speech.Tts(_appKey, _secretKey)
            {
                Timeout = 6000
            };
        }
    }
}
