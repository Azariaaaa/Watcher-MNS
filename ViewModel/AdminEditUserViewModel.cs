using System.ComponentModel.DataAnnotations;
using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AdminEditUserViewModel
    {
        public string Id { get; set; }
        public Client UserToEdit { get; set; }
        public List<ProfessionnalStatus>? professionnalStatuses { get; set; }
    }
}
