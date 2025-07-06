using Microsoft.AspNetCore.Mvc;
using tttb.Contracts.Requests;
using tttb.Contracts.Responses;
using tttb.Services;

namespace tttb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IResultService _resultService;
        public QuestionController(IQuestionService questionService, IResultService resultService)
        {
            _questionService = questionService;
            _resultService = resultService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var questionResponse = await _questionService.GetByIdAsync(id);

            return Ok(questionResponse);
        }

        [HttpPost("{questionId}/result")]
        [ProducesResponseType(typeof(NextQuestionIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SendAnswer([FromBody] CreateResultRequest resultRequest, int questionId)
        {
            var nextQuestionIdResponse = await _resultService.AddAsync(resultRequest, questionId);

            return Ok(nextQuestionIdResponse);
        }
    }
}
