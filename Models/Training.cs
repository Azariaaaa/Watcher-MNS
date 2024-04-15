using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDateTraining { get; set; }
        public DateTime EndDateTraining { get; set;}
        public TrainingType TrainingType { get; set; }
    }
}
