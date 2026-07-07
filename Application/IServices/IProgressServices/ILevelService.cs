using Domain.DomainObjects.Progresses;

namespace Application.IServices.IProgressServices
{
    public interface ILevelService
    {
        Task<List<Level>> GetAllAsync();
        Task<Level?> GetCurrentLevelAsync(int experiencePoints);
    }
}