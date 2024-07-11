using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class TrainingRepository : AbstractRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
