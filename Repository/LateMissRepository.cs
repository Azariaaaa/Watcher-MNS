using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class LateMissRepository : AbstractRepository<LateMiss>
    {
        public LateMissRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
