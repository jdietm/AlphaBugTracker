using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaBugTracker.DAL
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Ticket? entity)
        {
            _context.Add(entity);
        }

        public void Delete(int? id)
        {
            _context.Ticket.Remove(_context.Ticket.First(i => Equals(id)));
        }

        public Ticket? Get(Func<Ticket, bool>? firstFunction)
        {
            Ticket ticket = _context.Ticket.First(firstFunction);

            return ticket;
        }

        public Ticket? GetById(int? id)
        {
            Ticket ticket = _context.Ticket.Include(p => p.Project)
                                           .Include(c => c.TicketComments)
                                           .Include(a => a.TicketAttachments)
                                           .Include(h => h.TicketHistories)
                                           .First(t => t.Id.Equals(id));
            return ticket;
        }

        public ICollection<Ticket>? GetList(Func<Ticket, bool>? whereFunction)
        {
            List<Ticket> tickets = _context.Ticket.Include(p => p.Project).Where(whereFunction).ToList();

            return tickets;
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
