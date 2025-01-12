using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MiniDMS.Data;
using MiniDMS.Models;

namespace MiniDMS.Pages.Files
{
    public class EditModel : PageModel
    {
        private readonly MiniDMS.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment environment;
        public EditModel(MiniDMS.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        [BindProperty]
        public FileModel FileModel { get; set; } = default!;
        public IFormFile FormFile { get; set; }

        public int? _id;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _id = id;
            var filemodel =  await _context.Document.FirstOrDefaultAsync(m => m.Id == id);
            if (filemodel == null)
            {
                return NotFound();
            }
            FileModel = filemodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var filemodel = _context.Document.Find(id);

            try
            {
                Debug.WriteLine("DEBUGGGGINGGGG::::::  " + FileModel.FilePath);
                var auditRecord = new AuditRecord()
                {
                    Event = "Edit",
                    User = User.Identity.Name,
                    FileModel = filemodel
                };

                _context.AuditRecords.Add(auditRecord);


                if (FormFile != null)
                {
                    System.IO.File.Delete(filemodel.FilePath);

                    var userFolder = Path.Combine(environment.WebRootPath, "documents", User.Identity.Name);
                    Directory.CreateDirectory(userFolder);
                    var userFile = Path.Combine(userFolder, id.ToString() + FormFile.FileName);
                    using var fileStream = new FileStream(userFile, FileMode.Create);
                    await FormFile.CopyToAsync(fileStream);

                    filemodel.FilePath = userFile;

                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileModelExists(FileModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }

        private bool FileModelExists(int id)
        {
            return _context.Document.Any(e => e.Id == id);
        }
    }
}
