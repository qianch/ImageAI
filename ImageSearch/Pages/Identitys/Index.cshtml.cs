using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearch.Web.Models;
using ImageSearch.Web.Framework.Identity;

namespace ImageSearch.Web.Pages.Identitys
{
    public class IndexModel : PageModel
    {
        private readonly ImageSearch.Web.Models.WorldContext _context;
        private readonly IdentitySearch _identitySearch;

        public IndexModel(ImageSearch.Web.Models.WorldContext context)
        {
            _context = context;
            _identitySearch = new IdentitySearch();
        }

        [BindProperty]
        public Identity IdentitySingle { get; set; }

        public IList<Identity> Identity { get; set; }

        public async Task OnGetAsync()
        {
            Identity = await _context.Identity.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Identity = await _context.Identity.AsNoTracking().ToListAsync();
                return Page();
            }

            var querys = new Dictionary<string, string>
            {
                { "name", "徐旻" },
                { "registerCode", "310104198008072018" }
            };

            var result = _identitySearch.getReponse(querys);
            var identity = new Identity
            {
                CardNO = IdentitySingle.CardNO,
                Name = IdentitySingle.Name,
                Result = result
            };

            _context.Identity.Add(identity);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
