using System.ComponentModel.DataAnnotations;

namespace WatchMNS.DTO
{
    public class ClientDTO
    {
        public string Password { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string NativeCity { get; set; }
        public string NativeCountry { get; set; }
        public int ProfessionnalStatusId { get; set; }
        public int RoleId { get; set; }
    }
}
