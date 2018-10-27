using ImageSearch.Web.BaiduClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImageSearch.Web.Pages
{
    public class SpeechModel : PageModel
    {
        [Required(ErrorMessage = "请输入需要合成的文字")]
        [MinLength(1)]
        [BindProperty]
        public string Text { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var speechClient = new SpeechClient();
            var option = new Dictionary<string, object>()
            {
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", 0}  // 发音人，4：情感度丫丫童声
            };

            var result = speechClient.SpeechSynthesis.Synthesis(Text, option);
            if (result.ErrorCode == 0)  // 或 result.Success
            {
                System.IO.File.WriteAllBytes("合成的语音文件本地存储地址.mp3", result.Data);
            }
            return Page();
        }
    }
}