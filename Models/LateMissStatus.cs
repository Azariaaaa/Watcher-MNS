using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class LateMissStatus
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public List<LateMiss> lateMisses { get; set; } = new List<LateMiss>();
    }
}
