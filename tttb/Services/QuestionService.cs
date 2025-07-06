using Mapster;
using tttb.Contracts.Responses;
using tttb.Exceptions;
using tttb.Repositories;

namespace tttb.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionReposiroty _questionReposiroty;

    public QuestionService(IQuestionReposiroty questionRepository)
    {
        _questionReposiroty = questionRepository;
    }

    public async Task<QuestionResponse> GetByIdAsync(int id)
    {
        var question = await _questionReposiroty.GetByIdAsync(id);

        if (question is null)
        {
            throw new QuestionNotFoundException();
        }
        else
        {
            return question.Adapt<QuestionResponse>();
        }
    }
}
