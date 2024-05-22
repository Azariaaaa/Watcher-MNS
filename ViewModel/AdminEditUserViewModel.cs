using System.ComponentModel.DataAnnotations;
using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AdminEditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? PostCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NativeCity { get; set; }
        public string? NativeCountry { get; set; }
        public int? ProfessionnalStatusId { get; set; }
        public List<ProfessionnalStatus>? professionnalStatuses { get; set; }
    }
}
