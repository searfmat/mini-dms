using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniDMS.Data;
using MiniDMS.Models;

namespace MiniDMS.Pages.Files
{
    public class CreateModel : PageModel
    {
        private readonly MiniDMS.Data.ApplicationDbContext _context;

        public CreateModel(MiniDMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public int? _id;
        public IActionResult OnGet(int? id)
        {
            _id = id;
            return Page();
        }

        [BindProperty]
        public FileModel FileModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(_id != null) FileModel.ParentId = (int)_id;
            _context.Document.Add(FileModel);
            var auditRecord = new AuditRecord()
            {
                Event = "Create",
                User = User.Identity.Name,
                FileModel = FileModel
            };

            _context.AuditRecords.Add(auditRecord);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
