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
    public class CategoriesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categories = _context.Categories.OrderBy(c => c.Name);

            return Ok(categories);
        }

        [HttpPost]
        public IHttpActionResult CreateCategory(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var category = Mapper.Map<CategoryDto, Category>(categoryDto);

            _context.Categories.Add(category);
            _context.SaveChanges();

            categoryDto.Id = category.Id;

            return Created(new Uri(Request.RequestUri + "/" + category.Id), categoryDto);

        }

        [HttpPut]
        public void UpdateCategory(int id, CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var categoryInDatabase = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(categoryDto, categoryInDatabase);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCategoy(int id)
        {
            var categoryInDatabase = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Categories.Remove(categoryInDatabase);
            _context.SaveChanges();
        }


    }
}
