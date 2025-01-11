using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniDMS.Models;

namespace MiniDMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MiniDMS.Models.FileModel> Document { get; set; } = default!;
        public IEnumerable<object> File { get; internal set; }
    }
}
