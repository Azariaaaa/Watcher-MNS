using WatchMNS.DTO;
using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class ClientRolesStatusViewModel
    {
        public Client? Client { get; set; }
        public List<Role>? Roles { get; set; }
        public List<ProfessionnalStatus>? ProfessionnalStatuses { get; set; }
    }
}
