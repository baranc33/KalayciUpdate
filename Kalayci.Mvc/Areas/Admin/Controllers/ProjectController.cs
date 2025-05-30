using Kalayci.Entities.Concrete;
using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProjectController : Controller
    {
       private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
   
        
        public async Task<IActionResult> Index()
        {
            ICollection<Project> projects = await _projectService.projectsWithUser();
            return View(projects);
        }

        [HttpPost]
        public IActionResult AddProject()
        {
            return View();
        }



    }
}
