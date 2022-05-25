using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaBugTracker.DAL
{
    public class CommentRepository : IRepository<TicketComment>
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(TicketComment? entity)
        {
            _context.TicketComment.Add(entity);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public TicketComment? Get(Func<TicketComment, bool>? firstFunction)
        {
            throw new NotImplementedException();
        }

        public ICollection<TicketComment>? GetList(Func<TicketComment, bool>? whereFunction)
        {
            
            List<TicketComment> ticketComment = _context.TicketComment.Where(whereFunction).ToList();

            return ticketComment;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TicketComment? entity)
        {
            throw new NotImplementedException();
        }
    }
}
