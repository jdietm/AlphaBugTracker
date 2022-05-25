using Microsoft.AspNetCore.Identity;

namespace AlphaBugTracker.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        public Ticket Ticket;
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public Project Project { get; set; }
        public TicketTypeCheck TicketTypeId { get; set; }
        public TicketPriorityLevel TicketPriorityId { get; set; }
        public TicketStatus TicketStatusId { get; set; }
        public IdentityUser OwnerUser { get; set; }
        public IdentityUser AssignedToUser { get; set; }

    }
}
