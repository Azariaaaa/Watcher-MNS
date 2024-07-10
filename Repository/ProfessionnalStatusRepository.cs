using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class ProfessionnalStatusRepository : AbstractRepository<ProfessionnalStatus>
    {
        public ProfessionnalStatusRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
