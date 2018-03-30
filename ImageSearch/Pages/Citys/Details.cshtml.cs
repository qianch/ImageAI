using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearchApp.Models;

namespace ImageSearchApp.Pages.Citys
{
    public class DetailsModel : PageModel
    {
        private readonly WorldContext _context;

        public DetailsModel(WorldContext context)
        {
            _context = context;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City.SingleOrDefaultAsync(m => m.ID == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
