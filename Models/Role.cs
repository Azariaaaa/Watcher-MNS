using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
