using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniDMS.Data;
using MiniDMS.Models;
using System.Collections.Generic;

namespace MiniDMS.Pages.Files
{
    public class IndexModel : PageModel
    {
        private readonly MiniDMS.Data.ApplicationDbContext _context;

        public IndexModel(MiniDMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FileModel> FileModel { get;set; } = default!;

        public async Task OnGetAsync()
        { 
            FileModel = await _context.Document.ToListAsync();
        }
    }
}
