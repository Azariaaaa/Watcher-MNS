using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public string Path { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public Client Client { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }
}
