using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniDMS.Models;

namespace MiniDMS.Pages
{
    public class IndexModel : PageModel 
    { 

       private readonly MiniDMS.Data.ApplicationDbContext _context;

        public IndexModel(MiniDMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Document> Documents { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                Documents = await _context.Document.Where(x => x.Owner.Equals(User.Identity.Name)).ToListAsync();
            }
        }
    }
}
