using AlphaBugTracker.BLL;
using AlphaBugTracker.DAL;
using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlphaBugTracker.Controllers
{
    public class CommentController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _globalContext;
        private CommentBusinessLogic commentBL;
        private TicketBusinessLogic ticketBL;


        public CommentController(ApplicationDbContext _context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            commentBL = new CommentBusinessLogic(new CommentRepository(_context));
            ticketBL = new TicketBusinessLogic(new TicketRepository(_context));
            _userManager = userManager;
            _roleManager = roleManager;
            _globalContext = _context;

        }


        // GET: CommentController
        public ActionResult Index(int id)
        {
            ViewBag.TicketId = id;  
            return View(commentBL.ListComments_ByTicketId(id));
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentController/Create
        public ActionResult Create(int id)
        {
            ViewBag.TicketId = id;

            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, int id)
        {
            string currUserName = User.Identity.Name;
            IdentityUser currUser = await _userManager.FindByNameAsync(currUserName);

            TicketComment ticketComment = new TicketComment();
            ticketComment.Comment = collection["Comment"].ToString();
            ticketComment.UserCreator = currUser;
            ticketComment.Ticket = ticketBL.Get(id);

            commentBL.AddTicketComment(ticketComment);

            return RedirectToAction("Index", "Comment", new { id = id });
           
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
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

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
