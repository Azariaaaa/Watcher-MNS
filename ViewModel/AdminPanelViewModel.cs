using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AdminPanelViewModel
    {
        public List<Client> Clients { get; set; }
        public List<LateMiss> LateMisses { get; set; }
    }
}
