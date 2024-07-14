using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class CreateProfessionnalStatusViewModel
    {
        public List<ProfessionnalStatus>? ExistingProfessionnalStatuses {  get; set; }
        public ProfessionnalStatus? ProfessionnalStatus { get; set; }
    }
}
