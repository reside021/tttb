using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tttb.Exceptions;

namespace tttb.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
           _logger.LogError(exception, "Произошла ошибка!");

            if (exception is IApiException apiException)
            {
                return Problem(
                    detail: apiException.Message,
                    statusCode: apiException.StatusCode
                );
            }

            return Problem(
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
}
