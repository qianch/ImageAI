using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearchApp.Models;

namespace ImageSearchApp.Pages.Faces
{
    public class DeleteModel : PageModel
    {
        private readonly ImageSearchApp.Models.WorldContext _context;

        public DeleteModel(ImageSearchApp.Models.WorldContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Face = await _context.Face.FindAsync(id);

            if (Face != null)
            {
                _context.Face.Remove(Face);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
