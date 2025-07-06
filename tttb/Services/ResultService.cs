using Mapster;
using tttb.Contracts.Requests;
using tttb.Contracts.Responses;
using tttb.Exceptions;
using tttb.Models;
using tttb.Repositories;

namespace tttb.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IInterviewRepository _interviewRepository;

        public ResultService(IResultRepository resultRepository, IInterviewRepository interviewRepository)
        {
            _resultRepository = resultRepository;
            _interviewRepository = interviewRepository;
        }
        public async Task<NextQuestionIdResponse> AddAsync(CreateResultRequest resultRequest, int questionId)
        {
            var result = resultRequest.Adapt<Result>();
            result.QuestionId = questionId;

            await _resultRepository.AddAsync(result);

            var interview = await _interviewRepository.GetByIdAsync(resultRequest.InterviewId);
            
            if (interview is null)
                throw new QuestionNotFoundException();
            

            var currentOrderNumber = interview
                .Survey
                .Questions
                .FirstOrDefault(x => x.Id == questionId)?.OrderNumber;

            if (currentOrderNumber is null)
                 throw new BadRequestException();
            
               
            var nextQuestionId = interview
                .Survey
                .Questions
                .Where(x => x.OrderNumber > currentOrderNumber)
                .OrderBy(x => x.OrderNumber)
                .FirstOrDefault()?.Id;

            var nextQuestionIdResponse = new NextQuestionIdResponse
            {
                NextQuestionId = nextQuestionId
            };

            return nextQuestionIdResponse;
        }
    }
}
