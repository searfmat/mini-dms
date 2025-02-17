﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniDMS.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string FileName { get; set; } = String.Empty;
        [DataType(DataType.Date)]
        [DisplayName("Date Uploaded")]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayName("Document Created Date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public double Version { get; set; } = 1.0;
        public bool IsFolder { get; set; } = false;
        public string Owner { get; set; } = String.Empty;
        public int ParentId { get; set; } = 0;
        public ICollection<FileModel> SubFiles { get; set; } = new List<FileModel>();
        public List<string> Whitelist { get; set; } = new();
        public ICollection<AuditRecord> AuditRecords { get; set; } = new List<AuditRecord>();
        public string FilePath { get; set; } = String.Empty;
    }
}
