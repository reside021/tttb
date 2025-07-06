using tttb.Models;

namespace tttb.Repositories
{
    public interface IInterviewRepository
    {
        Task<Interview?> GetByIdAsync(int id);
    }
}
