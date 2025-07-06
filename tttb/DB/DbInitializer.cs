using Microsoft.EntityFrameworkCore;
using tttb.Models;

namespace tttb.DB
{
    public class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            if (await db.Surveys.AnyAsync()) return;

            var survey = new Survey
            {
                Title = "Анкета разработчика",
                Description = "Автоматически сгенерированная анкета",
                Questions = []
            };

            for (int i = 1; i <= 10; i++)
            {
                var question = new Question
                {
                    OrderNumber = i,
                    Title = $"Вопрос №{i}",
                    Description = $"Описание к вопросу {i}",
                    Answers =
                        [
                            new() { Content = "Вариант A", IsCorrect = true },
                            new() { Content = "Вариант B", IsCorrect = false },
                            new() { Content = "Вариант C", IsCorrect = false }
                        ]
                };

                survey.Questions.Add(question);
            }

            await db.Surveys.AddAsync(survey);
            await db.SaveChangesAsync();

            var savedSurvey = await db.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .FirstAsync();
      
            for (int i = 1; i <= 2; i++)
            {
                var interview = new Interview
                {
                    RespondentName = $"User {i}",
                    RespondentEmail = $"user{i}@example.com",
                    DateEvent = DateTime.UtcNow,
                    SurveyId = savedSurvey.Id,
                    Survey = savedSurvey
                };

                await db.Interviews.AddAsync(interview);
                await db.SaveChangesAsync(); 

                var results = savedSurvey.Questions.Select(q => new Result
                {
                    InterviewId = interview.Id,
                    QuestionId = q.Id,
                    AnswerId = q.Answers.First().Id 
                }).ToList();

                await db.Results.AddRangeAsync(results);
            }

            await db.SaveChangesAsync();

        }
    }
}
