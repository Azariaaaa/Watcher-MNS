using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class DocumentStatus
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public List<Document> Documents { get; set;} = new List<Document>();
    }
}
