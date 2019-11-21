using ImageAI.BaiduClient;
using ImageAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ImageAI.Pages.Speech
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ImageAI.Models.Speech Speech { get; set; }

        public void OnGet()
        {
            Speech = new Models.Speech
            {
                Speed = 5,
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
            var fileName = $"Media/{Speech.Text}.mp3";
            var dir = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (result.ErrorCode == 0)  // 或 result.Success
            {
                return File(result.Data, "audio/mp3", $"{Speech.Text}.mp3");

            }
            return Page();
        }
    }
}