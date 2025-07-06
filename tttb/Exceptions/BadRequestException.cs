namespace tttb.Exceptions
{
    public class BadRequestException : Exception, IApiException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string Message => "Bad Request!";
    }
}
