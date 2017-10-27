using Fetena.Models;
using System.Linq;
using System.Web.Http;

namespace Fetena.Controllers.Api
{
    [Authorize]
    public class LevelsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public LevelsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetLevels()
        {
            var levels = _context.Levels.OrderBy(l => l.Name);

            return Ok(levels);

        }

    }
}
