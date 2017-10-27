using AutoMapper;
using Fetena.Dtos;
using Fetena.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Fetena.Controllers.Api
{
    [Authorize]
    public class AnswersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AnswersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetSummarizedResults()
        {
            var results = _context.Answers
               .Where(a => a.UserId == User.Identity.Name)
               .GroupBy(a => a.Quiz.Language.Name)
               .Select(item => new
               {
                   Language = item.Key,
                   Questions = item.Count(),
                   Result = item.Sum(a => a.Score)
               }).ToList();

            return Ok(results);
        }

        [HttpGet]
        public IHttpActionResult GetDetailedResults(string language)
        {
            if (string.IsNullOrWhiteSpace(language))
                return BadRequest();

            var answers =
                _context.Answers
                    .Include(a => a.Quiz)
                    .Include(a => a.Quiz.Level)
                    .Include(a => a.Quiz.Language)
                    .Include(a => a.Quiz.Category)
                    .Where(a => a.Quiz.Language.Name == language);

            var userScores = answers
                .Where(a => a.UserId == User.Identity.Name)
                .GroupBy(a => a.Quiz.Category.Name)
                .Select(g =>
                    new UserScoreDto()
                    {
                        Topic = g.Key,
                        Total = g.Count(),
                        UserScore = g.Sum(a => a.Score)
                    })
                .ToList();

            var scoreStatstics = answers
                .GroupBy(a => new { a.UserId, a.Quiz.Category.Name })
                .AsEnumerable()
                .Select(g => new
                {
                    Topic = g.Key.Name,
                    TotalScore = g.Sum(a => a.Score)
                })
                .GroupBy(g => g.Topic)
                .Select(g => new ScoreStatisticsDto()
                {
                    Topic = g.Key,
                    MaximumScore = g.Max(a => a.TotalScore),
                    MinimumScore = g.Min(a => a.TotalScore),
                    AverageScore = Math.Round(g.Average(a => a.TotalScore), 2)
                })
                .ToList();

            var resultDetails = new ResultDetailsDto()
            {
                IndividualScore = userScores,
                OverallScoreStatistics = scoreStatstics
            };

            return Ok(resultDetails);
        }

        [HttpPost]
        public IHttpActionResult PostAnswer(AnswerDto answerDto)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Select(m => m.Value.Errors)
                //    .Where(e => e.Count > 0)
                //    .ToList();
                return BadRequest();
            }

            var quizzes = _context.Quizzes.ToList();
            var answers = _context.Answers
                                  .ToList();

            answerDto.UserId = User.Identity.Name;

            var isAnswerCorrect = quizzes
                                        .FirstOrDefault(q =>
                                        q.Id == answerDto.QuizId
                                        && q.CorrectAnswer == answerDto.SelectedAnswer);

            answerDto.Score = (isAnswerCorrect == null) ? 0 : 1;

            var questionWasAnswered = answers
                                            .FirstOrDefault(a =>
                                            a.UserId == User.Identity.Name
                                            && a.QuizId == answerDto.QuizId);

            if (questionWasAnswered == null)
            {
                var answer = Mapper.Map<AnswerDto, Answer>(answerDto);
                _context.Answers.Add(answer);
            }
            else
            {
                // _context.Entry(questionWasAnswered).CurrentValues.SetValues(answerDto);
                Mapper.Map(answerDto, questionWasAnswered);
            }
            _context.SaveChanges();

            var question = quizzes.FirstOrDefault(q => q.Id == answerDto.QuizId);
            var correctAnswer = Convert.ToInt32(question.CorrectAnswer);

            return Ok(correctAnswer);

        }

    }
}
