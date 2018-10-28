using ImageSearch.Web.BaiduClient;
using ImageSearch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImageSearch.Web.Pages.Speech
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ImageSearch.Web.Models.Speech Speech { get; set; }

        public void OnGet()
        {
            Speech = new Models.Speech
            {
                Speed = 3,
                Volume = 7
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var speechClient = new SpeechClient();
            var option = new Dictionary<string, object>()
            {
                {"spd", Speech.Speed}, // 语速
                {"vol", Speech.Volume}, // 音量
                {"per", 0}  // 发音人，4：情感度丫丫童声
            };

            var result = speechClient.SpeechSynthesis.Synthesis(Speech.Text, option);
            if (result.ErrorCode == 0)  // 或 result.Success
            {
                System.IO.File.WriteAllBytes($"{Speech.Text}.mp3", result.Data);
            }
            return Page();
        }
    }
}