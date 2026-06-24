using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.ILevelRepositories
{
    public interface ILevelRepository : IBaseRepository<Level>
    {
        Task<Level?> GetByNameAsync(string name);
        Task<Level?> GetLevelForExperiencePointsAsync(int experiencePoints);
        Task<IEnumerable<Level>> GetAllOrderedByXpAsync();
    }
}