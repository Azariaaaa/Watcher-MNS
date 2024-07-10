using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class TrainingRepository : AbstractRepository<Training>
    {
        public TrainingRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
