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
        public CommentRepository()
        {
                
        }

        public void Create(TicketComment? entity)
        {
            _context.TicketComment.Add(entity);
        }

        public void Delete(int? id)
        {
            _context.TicketComment.Remove(_context.TicketComment.First(i => Equals(id)));
        }

        public TicketComment? Get(Func<TicketComment, bool>? firstFunction)
        {
            throw new NotImplementedException();
        }

        public virtual TicketComment? GetById(int? id)
        {
            TicketComment ticketComment = _context.TicketComment.First(t => t.Id.Equals(id));

            return ticketComment;   
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

        public void Update(int? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TicketComment>? GetListOrdered(string orderCriteria, bool orderType)
        {
            throw new NotImplementedException();
        }
    }
}
