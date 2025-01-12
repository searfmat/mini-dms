using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniDMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IList<FileModel> Files { get; set; } = new List<FileModel>();

        public int? _folder;
        public int? _parent;
        public async Task OnGetAsync(int? folder, int? parent)
        {
            _folder = folder == null ? 0 : folder;
            _parent = _folder != 0 ?  _context.Document.Where(x => x.Id == _folder).FirstOrDefault().ParentId : 0;
            
            Files = await _context.Document.Where(x => x.Owner.Equals(User.Identity.Name) && x.ParentId.Equals(_folder)).OrderByDescending(y => y.IsFolder).ToListAsync();

        }
    }
}
