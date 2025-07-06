using Microsoft.EntityFrameworkCore;
using tttb.DB;
using tttb.Models;

namespace tttb.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly AppDbContext _dbContext;
        public InterviewRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Interview?> GetByIdAsync(int id)
        {
            return await _dbContext
                .Interviews
                .Include(x => x.Survey)
                    .ThenInclude(s => s.Questions)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
