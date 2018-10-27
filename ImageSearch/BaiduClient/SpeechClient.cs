namespace ImageSearch.Web.BaiduClient
{
    public class SpeechClient
    {
        private const string _appID = "";
        private const string _appKey = "";
        private const string _secretKey = "";

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
