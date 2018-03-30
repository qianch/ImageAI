using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearchApp.Models;

namespace ImageSearchApp.Pages.Dishs
{
    public class DetailsModel : PageModel
    {
        private readonly ImageSearchApp.Models.WorldContext _context;

        public DetailsModel(ImageSearchApp.Models.WorldContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dish.SingleOrDefaultAsync(m => m.ID == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
