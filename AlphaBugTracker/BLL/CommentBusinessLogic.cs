using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class CommentBusinessLogic
    {
        IRepository<TicketComment> repo;
        

        public CommentBusinessLogic(IRepository<TicketComment> repoArg)
        {
            repo = repoArg;
        }

        public TicketComment Get(int id)
        {
            return repo.Get(t => t.Id ==id);
        }

        public virtual TicketComment GetById(int? id)
        {
            return repo.GetById(id);
                
        }

        public void AddTicketComment(TicketComment ticketComment)
        {
            repo.Create(ticketComment);
            repo.Save();
        }


        

    }
}
