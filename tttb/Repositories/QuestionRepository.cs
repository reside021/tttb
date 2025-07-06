using Microsoft.EntityFrameworkCore;
using tttb.DB;
using tttb.Models;

namespace tttb.Repositories
{
    public class QuestionRepository : IQuestionReposiroty
    {
        private readonly AppDbContext _dbContext;
        public QuestionRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _dbContext
                .Questions
                .Include(x => x.Answers)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
