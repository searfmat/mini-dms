using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniDMS.Models;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Web;

namespace MiniDMS.Pages
{
    public class IndexModel : PageModel 
    { 

       private readonly MiniDMS.Data.ApplicationDbContext _context;

        public IndexModel(MiniDMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Models.FileModel> Files { get; set; } = new List<Models.FileModel>();
        private string _folder;
        public async Task OnGetAsync(string folder)
        {
            _folder = folder;
        }
    }
}
