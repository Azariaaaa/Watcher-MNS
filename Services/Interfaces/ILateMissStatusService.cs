using WatchMNS.Models;

namespace WatchMNS.Services.Interfaces
{
    public interface ILateMissStatusService : IService<LateMissStatus>
    {
        Task<LateMissStatus?> GetLateMissStatusByNameAsync(string name);
    }
}
