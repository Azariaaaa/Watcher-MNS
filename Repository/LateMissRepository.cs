using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class LateMissRepository : AbstractRepository<LateMiss>, ILateMissRepository
    {
        public LateMissRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
