using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniDMS.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MiniDMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MiniDMS.Models.FileModel> Document { get; set; } = default!;

        public virtual DbSet<AuditRecord> AuditRecords { get; set; }
    }
}
