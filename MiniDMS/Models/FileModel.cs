using System.ComponentModel.DataAnnotations;

namespace MiniDMS.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; } = String.Empty;
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public double Version { get; set; } = 1.0;
        public bool IsFolder { get; set; } = false;
        public string Owner { get; set; } = String.Empty;
        public int ParentId { get; set; } = -1;
        public ICollection<FileModel> SubFiles { get; set; } = new List<FileModel>();
        public ICollection<string> Whitelist { get; set; } = new List<string>();
        public ICollection<AuditRecord> AuditRecords { get; set; } = new List<AuditRecord>();
    }
}
