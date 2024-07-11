using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class ProfessionnalStatusRepository : AbstractRepository<ProfessionnalStatus>
    {
        public ProfessionnalStatusRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
