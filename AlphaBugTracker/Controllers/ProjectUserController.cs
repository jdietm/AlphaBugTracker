using AlphaBugTracker.BLL;
using AlphaBugTracker.DAL;
using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlphaBugTracker.Controllers
{
    public class ProjectUserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _globalContext;
        private ProjectBusinessLogic projectBL;
        private ProjectUserBusinessLogic projectUSerBL;



        public ProjectUserController(ApplicationDbContext _context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            projectBL = new ProjectBusinessLogic(new ProjectRepository(_context));
            projectUSerBL = new ProjectUserBusinessLogic(new ProjectUserRepository(_context));
            _userManager = userManager;
            _roleManager = roleManager;
            _globalContext = _context;

        }



        // GET: ProjectUserController
        public ActionResult Index(int id)
        {
            ViewBag.ProjectId = id;
            return View(projectUSerBL.ListProjectsUsers_ByProject(id));
        }

        // GET: ProjectUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectUserController/Create
        public ActionResult Create(int id)
        {
            ViewBag.ProjectId = id;
            //List the users availables to assign to a project
            List<IdentityUser> listOfUsers = _globalContext.Users.ToList();
            ViewBag.ListOfUsers = listOfUsers;  

            return View();
        }

        // POST: ProjectUserController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePU(int projectId, string userName)
        {
            Project project = projectBL.GetAProjectbyId(projectId);
            IdentityUser currUser = await _userManager.FindByNameAsync(userName);
            ProjectUser newProjectUser = new ProjectUser();
            newProjectUser.Project = project;
            newProjectUser.UserMember = currUser;
            projectUSerBL.AddProjectUser(newProjectUser);

            return RedirectToAction("Index", "ProjectUser", new { id = projectId });
        }

        // GET: ProjectUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectUserController/Delete/5
        public ActionResult Delete(int id, int projectId)
        {
            projectUSerBL.RemoveUserFromProject(id);
            return RedirectToAction("Index", "ProjectUser", new { id = projectId });
        }
    }
}
