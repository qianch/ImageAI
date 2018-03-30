using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImageSearch.Pages.ImageSearch
{
    public class CarKnowModel : PageModel
    {
        private readonly Models.WorldContext _context;

        public CarKnowModel(Models.WorldContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            var citys = _context.City.Count();
        }


        public void OnPost()
        {
            var citys = _context.City.Count();
        }
    }
}