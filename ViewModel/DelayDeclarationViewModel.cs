using System.ComponentModel.DataAnnotations;
using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class DelayDeclarationViewModel
    {
        public List<LateMiss>? ExistingLateMisses { get; set; }
        public LateMiss NewLateMiss { get; set; }
    }
}
