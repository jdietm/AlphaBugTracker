using Microsoft.AspNetCore.Identity;

namespace AlphaBugTracker.Models
{
    public class TicketComment
    {

        public int Id { get; set; }
        public Ticket Ticket;
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public IdentityUser UserCreator { get; set; }   

    }
}
