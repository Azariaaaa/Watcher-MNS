using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AbsenceDeclarationViewModel
    {
        public List<LateMiss>? ExistingLateMisses { get; set; }
        public LateMiss NewLateMiss { get; set; }
    }
}
