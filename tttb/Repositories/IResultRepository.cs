using tttb.Models;

namespace tttb.Repositories
{
    public interface IResultRepository
    {
        Task AddAsync(Result result);
    }
}
