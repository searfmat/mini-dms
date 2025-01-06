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
        public IList<Document> Documents { get; set; } = new List<Document>();
        private string _folder;
        public async Task OnGetAsync(string folder)
        {
            _folder = folder;

            if (User.Identity.IsAuthenticated)
            {

                IList<Document> userDocuments = await _context.Document.Where(x => x.Owner.Equals(User.Identity.Name)).ToListAsync();

                if (string.IsNullOrEmpty(_folder))
                {
                    Documents = userDocuments.Where(x => x.ParentId.Equals(-1)).ToList();
                }
                else
                {

                        Document parent = userDocuments.SingleOrDefault(x => x.FileName.Equals(HttpUtility.UrlDecode(_folder)));
                        if (parent != null)
                        {
                            Documents = parent.SubFiles.ToList();
                        }
                        else 
                        {
                        Response.Redirect("/Error");
                    }

                    


                }
                
            }
        }
    }
}
