using Microsoft.AspNetCore.Identity;
using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AdminEditRoleViewModel
    {
        public Client? Client { get; set; }
        public IList<string>? Role { get; set; }
        public List<IdentityRole>? ExistingRoles { get; set; }

    }
}
