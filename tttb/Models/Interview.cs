namespace tttb.Models;

public class Interview
{
    public int Id { get; set; }
    public string RespondentName { get; set; }
    public string RespondentEmail { get; set; }
    public DateTime DateEvent { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
}
