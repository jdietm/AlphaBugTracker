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
        public TicketHistoryRepository()
        {

        }

        public void Create(TicketHistory? entity)
        {
            _context.Add(entity);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();  // We should not be able to delete a ticket history
        }

        public TicketHistory? Get(Func<TicketHistory, bool>? firstFunction)
        {
            throw new NotImplementedException();
        }

        public virtual TicketHistory? GetById(int? id)
        {
            TicketHistory ticketHistory = _context.TicketHistory.Include(u=> u.AssignedToUser).
                                          First(t => t.Id.Equals(id));

            return ticketHistory;
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
            throw new NotImplementedException(); // We should not be able to modify a ticket history
        }
    }
}
