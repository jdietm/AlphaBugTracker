using AlphaBugTracker.BLL;
using AlphaBugTracker.DAL;
using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlphaBugTracker.Controllers
{
    public class TicketController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _globalContext;
        private TicketBusinessLogic ticketBL;
        private ProjectBusinessLogic projectBL;



        public TicketController(ApplicationDbContext _context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ticketBL = new TicketBusinessLogic(new TicketRepository(_context));
            projectBL = new ProjectBusinessLogic(new ProjectRepository(_context));
            _userManager = userManager;
            _roleManager = roleManager;
            _globalContext = _context;
           
        }


        // GET: TicketController
        public ActionResult Index()
        {

            return View(ticketBL.ListTickets_ByDefault());
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.TicketId = id;
            return View(ticketBL.Get(id));
        }

        // GET: TicketController/Create
        public ActionResult Create(int id)
        {
            ViewBag.ProjectId = id;    

            // Types
            List<SelectListItem> types = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "Incident", Value = TicketTypeCheck.Incident.ToString() },
                new SelectListItem(){ Text = "LostRequest", Value = TicketTypeCheck.LostRequest.ToString() },
                new SelectListItem(){ Text = "LostResponse", Value = TicketTypeCheck.LostResponse.ToString() },
            };
            ViewBag.TicketTypeId = types;

            // Priorities
            List<SelectListItem> priorities = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "High", Value = TicketPriorityLevel.High.ToString() },
                new SelectListItem(){ Text = "Medium", Value = TicketPriorityLevel.Medium.ToString() },
                new SelectListItem(){ Text = "Low", Value = TicketPriorityLevel.Low.ToString() },
            };
            ViewBag.TicketPriorityId = priorities;

            // Statues
            List<SelectListItem> statues = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "Assigned", Value = TicketStatus.Assigned.ToString() },
                new SelectListItem(){ Text = "UnAssigned", Value = TicketStatus.UnAssigned.ToString() },
                new SelectListItem(){ Text = "InProgress", Value = TicketStatus.InProgress.ToString() },
                new SelectListItem(){ Text = "Completed", Value = TicketStatus.Completed.ToString() },
            };
            ViewBag.TicketStatusId = statues;

            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, int projectId)
        {
            string currUserName = User.Identity.Name;
            IdentityUser currUser = await _userManager.FindByNameAsync(currUserName);


            Ticket ticket = new Ticket();

            ticket.Title = collection["Title"].ToString();
            ticket.Description = collection["Description"].ToString();
            ticket.TicketTypeId = (TicketTypeCheck)Enum.Parse(typeof(TicketTypeCheck), collection["TicketTypeId"].ToString());
            ticket.TicketPriorityId = (TicketPriorityLevel)Enum.Parse(typeof(TicketPriorityLevel), collection["TicketPriorityId"].ToString());
            ticket.TicketStatusId = (TicketStatus)Enum.Parse(typeof(TicketStatus), collection["TicketStatusId"].ToString());
            ticket.OwnerUser = currUser;


            
            ticket.Project = projectBL.GetProjectById(p=> p.Id == projectId);
            ticketBL.AddTicket(ticket);


            return RedirectToAction("Index", "Ticket");
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketController/Edit/5
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

        // GET: TicketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketController/Delete/5
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
