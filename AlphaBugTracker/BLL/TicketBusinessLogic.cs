using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class TicketBusinessLogic
    {
        IRepository<Ticket> repo;

        public TicketBusinessLogic(IRepository<Ticket> repoArg)
        {
            repo = repoArg;
        }

        public List<Ticket> ListTickets_ByDefault()
        {
            return repo.GetList(t => true).ToList();
        }

        public virtual Ticket GetTicketByFunc(Func<Ticket, bool> funcArg)
        {
            return repo.Get(funcArg);
        }

        public Ticket Get(int id)
        {
            return repo.Get(t => t.Id ==id);
        }

        public Ticket GetTicketById(int id)
        {
            return repo.GetById(id);    
        }


        public void AddTicket(Ticket ticket)
        {
            repo.Create(ticket);
            repo.Save();
        }

        public void Update()
        {
            repo.Save();
        }

    }
}
