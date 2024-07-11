using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class LateMissDocRepository : AbstractRepository<LateMissDoc>
    {
        public LateMissDocRepository (DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
