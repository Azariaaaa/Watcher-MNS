using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class ClientRepository : AbstractRepository<Client>
    {
        public ClientRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
