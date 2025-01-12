using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniDMS.Data;
using MiniDMS.Models;

namespace MiniDMS.Pages.Files
{
    public class DeleteModel : PageModel
    {
        private readonly MiniDMS.Data.ApplicationDbContext _context;

        public DeleteModel(MiniDMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileModel FileModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filemodel = await _context.Document.FirstOrDefaultAsync(m => m.Id == id);

            if (filemodel == null)
            {
                return NotFound();
            }
            else
            {
                FileModel = filemodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filemodel = await _context.Document.FindAsync(id);
            if (filemodel != null)
            {
                FileModel = filemodel;
                var auditRecords = await _context.AuditRecords.Where(x => x.FileModel.Id == filemodel.Id).ToListAsync();
                foreach (var auditRecord in auditRecords)
                {
                    _context.AuditRecords.Remove(auditRecord);
                }
                await _context.SaveChangesAsync();

                if (!filemodel.FilePath.IsNullOrEmpty())
                {
                    System.IO.File.Delete(filemodel.FilePath);

                    _context.Document.Remove(FileModel);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
