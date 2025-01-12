using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniDMS.Data.Migrations;
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

        public async Task<IActionResult> OnGetDownload(int id)
        {
            var fileModel = _context.Document.First(x => x.Id == id);
            string filePath = fileModel.FilePath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "application/octet-stream", Path.GetFileName(filePath));
        }
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
                // Create a new view audit record. Add to list
                var auditRecord = new AuditRecord() 
                {
                    Event = "View",
                    User = User.Identity.Name,
                    FileModel = filemodel
                };

                _context.AuditRecords.Add(auditRecord);
                //Whitelist test please remove
                //filemodel.Whitelist.Add("test user");
                await _context.SaveChangesAsync();

                filemodel.AuditRecords = await _context.AuditRecords.Where(x => x.FileModel.Id == filemodel.Id).OrderByDescending(y => y.EventDate).ToListAsync();
           
                FileModel = filemodel;
            }
            return Page();
        }
    }
}
