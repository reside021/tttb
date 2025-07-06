using tttb.Models;

namespace tttb.Repositories
{
    public interface IQuestionReposiroty
    {
        Task<Question?> GetByIdAsync(int id);
    }
}
