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
        private readonly IWebHostEnvironment environment;

        public CreateModel(MiniDMS.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }
        public int? _id;
        public string _date = DateTime.Now.ToString("yyyy-MM-dd");
        public IActionResult OnGet(int? id)
        {
            _id = id;
            return Page();
        }

        [BindProperty]
        public FileModel FileModel { get; set; } = default!;

        public IFormFile FormFile { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(_id != null) FileModel.ParentId = (int)_id;
            var userFolder = Path.Combine(environment.WebRootPath, "documents", User.Identity.Name);
            Directory.CreateDirectory(userFolder);
            var userFile = Path.Combine(userFolder, FormFile.FileName);
            using var fileStream = new FileStream(userFile, FileMode.Create);
            await FormFile.CopyToAsync(fileStream);

            FileModel.FilePath = userFile;
            FileModel.Owner = User.Identity.Name;
           
            _context.Document.Add(FileModel);

            await _context.SaveChangesAsync();

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
