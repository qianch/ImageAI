﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearch.Models;

namespace ImageSearch.Pages.World
{
    public class IndexModel : PageModel
    {
        private readonly WorldContext _context;

        public IndexModel(WorldContext context)
        {
            _context = context;
        }

        public IList<City> City { get; set; }

        public async Task OnGetAsync()
        {
            City = await _context.City.Where(x => x.ID < 10).ToListAsync();
        }
    }
}
