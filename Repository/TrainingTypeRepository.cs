using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class TrainingTypeRepository : AbstractRepository<TrainingType>
    {
        public TrainingTypeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
