using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniDMS.Data;
using MiniDMS.Models;
using NuGet.Protocol.Providers;

namespace MiniDMS.Pages.Documents
{
    public class CreateModel : PageModel
    {
        private readonly MiniDMS.Data.ApplicationDbContext _context;

        public CreateModel(MiniDMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string Owner { get; set; }
        public IActionResult OnGet()
        {
            Owner = User.Identity.Name;
            return Page();
        }

        [BindProperty]
        public Document Document { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Document.Add(Document);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
