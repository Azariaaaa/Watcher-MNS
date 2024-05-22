using Microsoft.AspNetCore.Identity;
using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AdminEditRoleViewModel
    {
        public string ClientId { get; set; }
        public string ClientLastname { get; set; }
        public string ClientFirstname { get; set; }
        public IList<string>? Role { get; set; }
        public List<IdentityRole>? ExistingRoles { get; set; }
        public string? NewRoleName { get; set; }

    }
}
