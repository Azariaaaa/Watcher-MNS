using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class LateMiss
    {
        [Key]
        public int Id { get; set; }
        public DateTime DeclarationDate { get; set; }
        public string LateMissType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Client Client { get; set; }
    }
}
