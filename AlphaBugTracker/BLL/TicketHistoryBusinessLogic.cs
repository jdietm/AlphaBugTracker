using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class TicketHistoryBusinessLogic
    {
        IRepository<TicketHistory> repo;

        public TicketHistoryBusinessLogic(IRepository<TicketHistory> repoArg)
        {
            repo = repoArg;
        }

        public List<TicketHistory> ListTicketsHistory_ByDefault()
        {
            return repo.GetList(t => true).ToList();
        }

        public TicketHistory Get(int id)
        {
            return repo.Get(t => t.Id ==id);
        }

        public virtual TicketHistory GetTicketHistoryById(int id)
        {
            return repo.GetById(id);    
        }


        public void AddTicketHistory(TicketHistory ticketHistory)
        {
            repo.Create(ticketHistory);
            repo.Save();
        }

        public void Update()
        {
            repo.Save();
        }

    }
}
