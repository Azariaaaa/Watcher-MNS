using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WatchMNS.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Invalid email address.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
