using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearchApp.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using ImageSearchApp.Utilities;
using System.IO;
using ImageSearchApp.BaiduClient;

namespace ImageSearchApp.Pages.Faces
{
    public class IndexModel : PageModel
    {
        private readonly ImageSearchApp.Models.WorldContext _context;

        public IndexModel(ImageSearchApp.Models.WorldContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "必须上传图片")]
        public IFormFile ImageUpload { get; set; }

        public IList<Face> Face { get; set; }

        public async Task OnGetAsync()
        {
            Face = await _context.Face.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Face = await _context.Face.AsNoTracking().ToListAsync();
                return Page();
            }

            var ImgContent = await FileHelpers.ProcessFormFile(ImageUpload, ModelState);

            if (!ModelState.IsValid)
            {
                Face = await _context.Face.AsNoTracking().ToListAsync();
                return Page();
            }

            var groudId = "ZZX";
            var options = new Dictionary<string, object> { };
            var face = new FaceClient().Face;
            var result = face.Identify(groudId, Convert.FromBase64String(ImgContent), options);
            var title = Path.GetFileNameWithoutExtension(ImageUpload.FileName);

            var car = new Face
            {
                Title = title,
                ImgSize = ImageUpload.Length,
                ImgType = ImageUpload.ContentType,
                ImgContent = ImgContent,
                Data = result.ToString(),
                UploadDT = DateTime.UtcNow
            };

            _context.Face.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
