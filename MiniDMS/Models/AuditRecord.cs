using System.ComponentModel.DataAnnotations;

namespace MiniDMS.Models
{
    public class AuditRecord
    {
        public int Id { get; set; }
        public string Event { get; set; } = String.Empty;
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; } = DateTime.Now;
        public string User {  get; set; } = String.Empty;
    }
}
