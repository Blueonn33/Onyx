using Onyx.Models;

namespace Onyx.Repositories.Interfaces
{
    public interface ITutorialRepository : IRepository<Tutorial>
    {
        Task AddTutorialAsync(Tutorial tutorial);
        Task<Tutorial?> GetTutorialByIdAsync(int tutorialId);
        Task<IEnumerable<Tutorial>> GetAllTutorialsAsync();
        Task DeleteTutorialAsync(int tutorialId);
    }
}
