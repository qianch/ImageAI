using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearch.Web.Models;

namespace ImageSearch.Web.Pages.Faces
{
    public class DetailsModel : PageModel
    {
        private readonly ImageSearch.Web.Models.WorldContext _context;

        public DetailsModel(ImageSearch.Web.Models.WorldContext context)
        {
            _context = context;
        }

        public Face Face { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Face = await _context.Face.SingleOrDefaultAsync(m => m.ID == id);

            if (Face == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
