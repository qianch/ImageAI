using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageAI.Models;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using ImageAI.BaiduClient;
using ImageAI.Utilities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ImageAI.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ImageAIContext _context;

        public IndexModel(ImageAIContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "必须上传图片")]
        public IFormFile ImageUpload { get; set; }

        public IList<Car> Car { get; set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Car = await _context.Car.AsNoTracking().ToListAsync();
                return Page();
            }

            var ImgContent = await FileHelpers.ProcessFormFile(ImageUpload, ModelState);

            if (!ModelState.IsValid)
            {
                Car = await _context.Car.AsNoTracking().ToListAsync();
                return Page();
            }

            var ImageClassify = new ImageClassifyClient().ImageClassify;
            var options = new Dictionary<string, object> { };
            var result = ImageClassify.CarDetect(Convert.FromBase64String(ImgContent), options);
            var title = Path.GetFileNameWithoutExtension(ImageUpload.FileName);

            var car = new Car
            {
                Title = title,
                ImgSize = ImageUpload.Length,
                ImgType = ImageUpload.ContentType,
                ImgContent = ImgContent,
                Data = result.ToString(),
                UploadDT = DateTime.UtcNow
            };

            _context.Car.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
