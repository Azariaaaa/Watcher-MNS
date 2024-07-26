using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchMNS.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "VARCHAR(100)")]
        public string Label { get; set; }
        [Required]
        [MaxLength(500)]
        [Column(TypeName = "VARCHAR(500)")]
        public string Path { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public Client Client { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }
}
