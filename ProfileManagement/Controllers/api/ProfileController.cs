using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileManagement.DBModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileManagement.Controllers.api
{
    [Route("api/[controller]")]         //  => [HttpGet("[action]")]
    //[Route("api/Profile/[action]")]   //  => [HttpGet]
    public class ProfileController : Controller
    {
        private readonly string uploadDirectory;
        private readonly PMDbContext _context;
        private readonly IHostingEnvironment _environment;

        public ProfileController(PMDbContext context, IHostingEnvironment environment) //, IHostingEnvironment environment
        {
            _context = context;
            _environment = environment;
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            uploadDirectory = _environment.WebRootPath + $@"/{"uploads"}";
            Directory.CreateDirectory(uploadDirectory);      //Should be in startup
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Insert(Profile data, ICollection<IFormFile> image)
        {
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(int currentPageNo = 1, int pageSize = 20)
        {
            var profiles = await _context.Profile
                //.Include(u => u.Descriptions)
                .Select(p => new {
                                    p.Id,
                                    p.Name,
                                    p.DateOfBirth
                                 })
                .Distinct()
                .OrderBy(p => p.Name)
                .Skip((currentPageNo-1)*pageSize)
                .Take(pageSize)
                .ToArrayAsync();

            //Creating a custom responce
            var response = profiles.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                dob = p.DateOfBirth
                //Descriptions = u.Descriptions.Select(p => p.Text),
                //BaseUrl = "/uploads/"
            });

            return Ok(response);
        }
    }
}
