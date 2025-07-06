namespace tttb.Exceptions
{
    public interface IApiException 
    {
        int StatusCode { get; }
        string Message { get; }
    }
}
