using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class CommentBusinessLogic
    {
        IRepository<TicketComment> repo;
        IRepository<Ticket> repoTicket;
        private CommentRepository commentRepository;

        public CommentBusinessLogic(IRepository<TicketComment> repoArg, IRepository<Ticket> repoArgTicket)
        {
            repo = repoArg;
            repoTicket = repoArgTicket;
    }

        public CommentBusinessLogic(CommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public List<TicketComment> ListComments_ByTicketId(int id)
        {
            var ticketFound = repoTicket.Get(t => t.Id == id);
            return repo.GetList(c => c.Ticket == ticketFound).ToList();  
        }

        public TicketComment Get(int id)
        {
            return repo.Get(t => t.Id ==id);
        }

        public void AddTicketComment(TicketComment ticketComment)
        {
            repo.Create(ticketComment);
            repo.Save();
        }
    }
}
