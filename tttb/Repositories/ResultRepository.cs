using tttb.DB;
using tttb.Models;

namespace tttb.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppDbContext _dbContext;

        public ResultRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Result result)
        {
            await _dbContext.Results.AddAsync(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
