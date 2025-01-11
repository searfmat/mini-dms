using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniDMS.Data;
using MiniDMS.Models;

namespace MiniDMS.Pages.Files
{
    public class DetailsModel : PageModel
    {
        private readonly MiniDMS.Data.ApplicationDbContext _context;

        public DetailsModel(MiniDMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
                var auditRecord = new AuditRecord();
                auditRecord.Event = "View";
                auditRecord.User = User.Identity.Name;
                auditRecord.FileModel = filemodel;

                _context.AuditRecords.Add(auditRecord);
                await _context.SaveChangesAsync();
                filemodel.AuditRecords = await _context.AuditRecords.Where(x => x.FileModel.Id == filemodel.Id).ToListAsync();
           
                FileModel = filemodel;
            }
            return Page();
        }
    }
}
