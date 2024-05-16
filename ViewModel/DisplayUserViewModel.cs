namespace WatchMNS.ViewModel
{
    public class DisplayUserViewModel
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string? PostCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? NativeCity { get; set; }
        public string? NativeCountry { get; set; }
        public string PhoneNumber { get; set; }
        public IList<string> Role { get; set; }
        public string? ProfessionnalStatusLabel { get; set; }

        public float AbsencePercentage { get; set; }
        public float DelayPercentage { get; set; }
        public int TotalAbsence { get; set; }
        public int TotalDelay { get; set; }
    }
}
