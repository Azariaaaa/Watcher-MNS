using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class TrainingTypeRepository : AbstractRepository<TrainingType>, ITrainingTypeRepository
    {
        public TrainingTypeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
