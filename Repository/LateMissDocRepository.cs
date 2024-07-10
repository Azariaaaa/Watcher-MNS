using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class LateMissDocRepository : AbstractRepository<LateMissDoc>
    {
        public LateMissDocRepository (DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
