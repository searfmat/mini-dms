using System.ComponentModel.DataAnnotations;

namespace MiniDMS.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
        public bool IsFolder { get; set; } = false;
        public string Owner { get; set; } = String.Empty;
        public int ParentId { get; set; }
        public ICollection<Document>? SubFiles { get; set; }
    }
}
