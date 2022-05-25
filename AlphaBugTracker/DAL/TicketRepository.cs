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
            _context.Ticket.Add(entity);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Ticket? Get(Func<Ticket, bool>? firstFunction)
        {
            Ticket ticket = _context.Ticket.Where(firstFunction).First();

            return ticket;
        }

        public ICollection<Ticket>? GetList(Func<Ticket, bool>? whereFunction)
        {
            List<Ticket> Ticket = null;
            if (whereFunction != null)
            {

                Ticket = _context.Ticket.Include(p => p.Project).Where(whereFunction).ToList();

            }
            return Ticket;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Ticket? entity)
        {
            throw new NotImplementedException();
        }
    }
}
