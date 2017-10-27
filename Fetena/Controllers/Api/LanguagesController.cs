using AutoMapper;
using Fetena.Dtos;
using Fetena.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Fetena.Controllers.Api
{
    [Authorize]
    public class LanguagesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public LanguagesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetProgrammingLanguages()
        {
            var languages = _context.Languages
                                .OrderBy(l => l.Name);
            return Ok(languages);
        }

        [HttpPost]
        public IHttpActionResult CreateLanguage(LanguageDto languageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var language = Mapper.Map<LanguageDto, Language>(languageDto);

            _context.Languages.Add(language);
            _context.SaveChanges();

            languageDto.Id = language.Id;

            return Created(new Uri(Request.RequestUri + "/" + language.Id), languageDto);
        }

        [HttpPut]
        public void UpdateLanguage(int id, LanguageDto languageDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var languageInDatabase = _context.Languages.SingleOrDefault(c => c.Id == id);

            if (languageInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(languageDto, languageInDatabase);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteLanguage(int id)
        {
            var languageInDatabase = _context.Languages.SingleOrDefault(c => c.Id == id);

            if (languageInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Languages.Remove(languageInDatabase);
            _context.SaveChanges();
        }

    }
}
