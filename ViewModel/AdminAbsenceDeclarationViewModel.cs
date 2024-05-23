using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AdminAbsenceDeclarationViewModel
    {
        public Client User { get; set; }
        public List<LateMiss>? ExistingLateMisses { get; set; }
        public LateMiss NewLateMiss { get; set; }
    }
    
}
