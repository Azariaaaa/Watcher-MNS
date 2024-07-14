using WatchMNS.Models;

namespace WatchMNS.Services.Interfaces
{
    public interface ILateMissService : IService<LateMiss>
    {
        Task<List<LateMiss>> GetLateMissesFromUser(Client client, string lateMissType);

    }
}
