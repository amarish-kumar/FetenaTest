using AutoMapper;
using Fetena.Dtos;
using Fetena.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper.Internal;

namespace Fetena.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api")]
    public class QuizzesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public QuizzesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("getLanguagesList")]
        public IHttpActionResult GetLanguagesAndTheirCount()
        {
            var quizLanguagesAndTheirCount = _context.Quizzes
                .GroupBy(q => q.Language.Name)
                .Select(item => new
                {
                    Language = item.Key,
                    count = item.Count()
                }).ToList();

            return Ok(quizLanguagesAndTheirCount);
        }

        [HttpGet]
        [Route("getLevels")]
        public IHttpActionResult GetQuizLevels(string language)
        {
            if (string.IsNullOrWhiteSpace(language))
                return BadRequest();

            var quizLevels = _context.Quizzes
                .Where(q => q.Language.Name.Contains(language))
                .GroupBy(q => q.Level.Name)
                .Select(item => new
                {
                    Level = item.Key
                }).ToList();


            return Ok(quizLevels);
        }

        [HttpGet]
        [Route("getCategories")]
        public IHttpActionResult GetQuizCategories(string language, string level = null)
        {
            if (string.IsNullOrWhiteSpace(language))
                return BadRequest();

            var filterQuizByLanguage = _context.Quizzes
                .Where(q => q.Language.Name.Contains(language));

            object quizCategories = null;

            if (!string.IsNullOrWhiteSpace(level))
            {
                quizCategories = filterQuizByLanguage
                    .GroupBy(q => new { q.Level, q.Category },
                        (key, group) => new
                        {
                            level = key.Level.Name,
                            category = key.Category.Name
                        }).Where(q => q.level.Contains(level)).OrderBy(category => category).ToList();
            }

            if (string.IsNullOrWhiteSpace(level))
            {
                quizCategories = filterQuizByLanguage
                    .GroupBy(q => new { q.Level, q.Category },
                        (key, group) => new
                        {
                            level = key.Level.Name,
                            category = key.Category.Name
                        }).OrderBy(category => category).ToList();
            }

            return Ok(quizCategories);
        }

        [HttpGet]
        [Route("getImages")]
        public HttpResponseMessage GetImage(string imageName)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var path = "~/images/" + imageName + ".jpg";
            path = System.Web.Hosting.HostingEnvironment.MapPath(path);
            var ext = System.IO.Path.GetExtension(path);

            var contents = System.IO.File.ReadAllBytes(path);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(contents);

            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("image/" + ext);

            return response;
        }

        [HttpGet]
        [Route("getQuizById")]
        public IHttpActionResult GetQuiz(int id)
        {
            var quiz = _context.Quizzes
                .Include(q => q.Choices)
                .SingleOrDefault(q => q.Id == id);

            return Ok(Mapper.Map<Quiz, QuizDto>(quiz));
        }

        [HttpGet]
        [Route("getQuizzes")]
        public IHttpActionResult GetQuizzes(string language, string level = null, string category = null)
        {

            if (string.IsNullOrWhiteSpace(language))
                return BadRequest();

            var quizzes = _context.Quizzes
                .Include(q => q.Level)
                .Include(q => q.Language)
                .Include(q => q.Category)
                .Include(q => q.Choices);

            if (!string.IsNullOrWhiteSpace(level) && !string.IsNullOrWhiteSpace(category))
                quizzes = quizzes
                    .Where(q => q.Language.Name.Contains(language))
                    .Where(q => q.Category.Name.Contains(category))
                    .Where(q => q.Level.Name.Contains(level));

            if (!string.IsNullOrWhiteSpace(level) && string.IsNullOrWhiteSpace(category))
                quizzes = quizzes
                    .Where(q => q.Language.Name.Contains(language))
                    .Where(q => q.Level.Name.Contains(level));

            if (string.IsNullOrWhiteSpace(level) && !string.IsNullOrWhiteSpace(category))
                quizzes = quizzes
                    .Where(q => q.Language.Name.Contains(language))
                    .Where(q => q.Category.Name.Contains(category));

            if (string.IsNullOrWhiteSpace(level) && string.IsNullOrWhiteSpace(category))
                quizzes = quizzes
                    .Where(q => q.Language.Name.Contains(language));


            var quizDtos = quizzes.ToList().Select(Mapper.Map<Quiz, QuizDto>);

            return Ok(quizDtos);
        }


        [HttpPost]
        public IHttpActionResult CreateQuiz(QuizDto quizDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(m => m.Value.Errors)
                    .Where(e => e.Count > 0)
                    .ToList();
                return BadRequest();
            }

            //quizDto.LanguageId = quizDto.Language.Id;
            //quizDto.LevelId = quizDto.Level.Id;
            //quizDto.CategoryId = quizDto.Category.Id;

            var quiz = Mapper.Map<QuizDto, Quiz>(quizDto);
            _context.Quizzes.Add(quiz);
            _context.SaveChanges();

            quizDto.Id = quiz.Id;

            return Created(new Uri(Request.RequestUri + "/" + quiz.Id), quizDto);
        }

        [HttpPut]
        public void UpdateQuiz(int id, QuizDto quizDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var quizInDatabase = _context
                .Quizzes
                .Include(q => q.Choices)
                .ToList()
                .SingleOrDefault(c => c.Id == id);

            if (quizInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            _context.Entry(quizInDatabase).CurrentValues.SetValues(quizDto);

            foreach (var choice in quizDto.Choices)
            {
                var choiceItem = quizInDatabase.Choices
                    .SingleOrDefault(q => q.Id == choice.Id && q.Id != 0);
                _context.Entry(choiceItem).CurrentValues.SetValues(choice);
            }
           // Mapper.Map(quizInDatabase, quizDto);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteQuiz(int id)
        {
            var quizInDatabase = _context.Quizzes.SingleOrDefault(c => c.Id == id);

            if (quizInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Quizzes.Remove(quizInDatabase);
            _context.SaveChanges();
        }


    }
}
