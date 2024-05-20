using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AdminPanelViewModel
    {
        //public List<Client> Clients { get; set; }
        public List<LateMiss> LateMisses { get; set; }
        public string SortOrder { get; set; } = "default";
        public Dictionary<Client, int[]> ClientsData { get; set; } = new Dictionary<Client, int[]>();

    }
}
