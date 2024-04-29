using System.ComponentModel.DataAnnotations;

namespace WatchMNS.ViewModel
{
    public class UserEditUserViewModel
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string NativeCity { get; set; }
        public string NativeCountry { get; set; }
    }
}
