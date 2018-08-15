using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageSearch.Web.Models;
using ImageSearch.Web.Framework.Identity;
using System.Text;
using System.Text.Encodings.Web;

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

            //var bytes = Encoding.GetEncoding("GBK").GetBytes(IdentitySingle.Name);
            //var urlEncoder = UrlEncoder.Default;
            var querys = new Dictionary<string, string>
            {
                //{ "name", Encoding.UTF8.GetString(bytes)},
                {"name","%D0%EC%95F"},
                {"registerCode",IdentitySingle.CardNO }
            };

            //var result = _identitySearch.GetReponse(querys);
            //var identity = new Identity
            //{
            //    CardNO = IdentitySingle.CardNO,
            //    Name = IdentitySingle.Name,
            //    Result = result
            //};

            //_context.Identity.Add(identity);
            //await _context.SaveChangesAsync();
            TempData.Add("name", querys["name"]);
            TempData.Add("registerCode", querys["registerCode"]);
            return RedirectToPage("./Detail");
        }
    }
}
