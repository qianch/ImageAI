using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearchApp.Models;
using ImageSearchApp.Utilities;
using System.IO;
using ImageSearchApp.BaiduClient;

namespace ImageSearchApp.Pages.Dishs
{
    public class IndexModel : PageModel
    {
        private readonly ImageSearchApp.Models.WorldContext _context;

        public IndexModel(ImageSearchApp.Models.WorldContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ImageUpload ImageUpload { get; set; }

        public IList<Dish> Dish { get; set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dish.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Dish = await _context.Dish.AsNoTracking().ToListAsync();
                return Page();
            }

            var ImgContent = await FileHelpers.ProcessFormFile(ImageUpload.UploadImg, ModelState);

            if (!ModelState.IsValid)
            {
                Dish = await _context.Dish.AsNoTracking().ToListAsync();
                return Page();
            }

            var ImageClassify = new ImageClassifyClient().imageClassify;
            var options = new Dictionary<string, object> { };
            var result = ImageClassify.DishDetect(Convert.FromBase64String(ImgContent), options);
            var title = string.IsNullOrEmpty(ImageUpload.Title) ?
                Path.GetFileNameWithoutExtension(ImageUpload.UploadImg.FileName) :
                ImageUpload.Title;

            var dish = new Dish
            {
                Title = title,
                ImgSize = ImageUpload.UploadImg.Length,
                ImgType = ImageUpload.UploadImg.ContentType,
                ImgContent = ImgContent,
                Data = result.ToString(),
                UploadDT = DateTime.UtcNow
            };

            _context.Dish.Add(dish);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
