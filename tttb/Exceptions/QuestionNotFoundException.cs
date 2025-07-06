namespace tttb.Exceptions
{
    public class QuestionNotFoundException : Exception, IApiException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string Message => "Question not found!";
    }
}
