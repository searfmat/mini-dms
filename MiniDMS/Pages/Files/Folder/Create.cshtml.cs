using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniDMS.Data;
using MiniDMS.Models;

namespace MiniDMS.Pages.Files.Folder
{
    public class CreateModel : PageModel
    {
        private readonly MiniDMS.Data.ApplicationDbContext _context;

        public CreateModel(MiniDMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        int? _parent;
        public IActionResult OnGet(int? parent)
        {
            _parent = parent;
            return Page();
        }

        [BindProperty]
        public FileModel FileModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? parent)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (parent != null) FileModel.ParentId = (int)parent;
            FileModel.Owner = User.Identity.Name;
            FileModel.IsFolder = true;
            _context.Document.Add(FileModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
