using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class ClientRepository : AbstractRepository<Client>
    {
        public ClientRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
