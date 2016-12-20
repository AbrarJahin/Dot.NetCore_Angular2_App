using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileManagement.DBModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                .Skip((currentPageNo - 1) * pageSize)
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

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var profile = await _context.Profile
                .Where(p => p.Id== id)
                .FirstOrDefaultAsync();

            return Ok(profile);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(string name, string dob)
        {
            if(name.Length==0)
            {
                return View("Error"); ;
            }

            Profile profileToSave = new Profile
                                        {
                                            Name = name,
                                            DateOfBirth = DateTime.ParseExact(
                                                                    dob,
                                                                    "yyyy-MM-dd",
                                                                    CultureInfo.InvariantCulture
                                                            )
                                        };
            _context.Profile.Add(profileToSave);
            await _context.SaveChangesAsync();
            return Ok(profileToSave);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int profileID)
        {
            Profile profileToRemove = _context.Profile.SingleOrDefault(x => x.Id == profileID); //returns a single item.

            if (profileToRemove != null)
            {
                _context.Profile.Remove(profileToRemove);
                _context.SaveChanges();
                return Ok("Successfully Deleted");
            }
            else
                return NotFound("Profile Not Found");
        }
    }
}
