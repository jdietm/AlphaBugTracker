using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaBugTracker.DAL
{
    public class TicketHistoryRepository : IRepository<TicketHistory>
    {
        private readonly ApplicationDbContext _context;

        public TicketHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(TicketHistory? entity)
        {
            _context.Add(entity);
        }

        public void Delete(int? id)
        {
            _context.Ticket.Remove(_context.Ticket.First(i => Equals(id)));
        }

        public TicketHistory? Get(Func<TicketHistory, bool>? firstFunction)
        {
            throw new NotImplementedException();
        }

        public TicketHistory? GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TicketHistory>? GetList(Func<TicketHistory, bool>? whereFunction)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
