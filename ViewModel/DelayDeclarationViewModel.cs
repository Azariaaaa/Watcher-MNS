using System.ComponentModel.DataAnnotations;
using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class DelayDeclarationViewModel
    {
        public Client Client { get; set; }
        public List<LateMiss>? lateMissesList { get; set; }
        public LateMiss? LateMiss { get; set; }
        [Required]
        public string Motif { get; set; }
        public List<LateMissDoc>? LateMissDoc { get; set; }
    }
}
