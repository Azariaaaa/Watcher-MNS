using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class ProfessionnalStatus
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public List<Client> ClientList { get; set; } = new List<Client>();
    }
}
