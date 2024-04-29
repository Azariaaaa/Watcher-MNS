using WatchMNS.Models;

namespace WatchMNS.Database.CRUD
{
    public class ClientRepository
    {
        private DatabaseContext dbContext = new DatabaseContext();

        private List<Client> GetAll()
        {
            return dbContext.Client.ToList();
        }

        private Client GetById(string id)
        {
            return dbContext.Client.Where(x => x.Id == id).FirstOrDefault();
        }

        private void Post(Client client)
        {
            dbContext.Client.Add(client);
            dbContext.SaveChanges();
        }

        private void Put(Client client)
        {

        }
    }
}
