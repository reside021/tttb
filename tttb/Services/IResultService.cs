using tttb.Contracts.Requests;
using tttb.Contracts.Responses;

namespace tttb.Services
{
    public interface IResultService
    {
        Task<NextQuestionIdResponse> AddAsync(CreateResultRequest request, int questionId);
    }
}
