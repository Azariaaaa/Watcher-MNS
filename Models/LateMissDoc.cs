using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class LateMissDoc
    {
        [Key]
        public int? Id { get; set; }
        public string? Path { get; set; }
        public string? Label { get; set; }
        public DateTime UploadDate { get; set; }
        public LateMiss LateMiss {  get; set; }
    }
}
