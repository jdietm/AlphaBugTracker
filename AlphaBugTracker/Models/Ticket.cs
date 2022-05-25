using Microsoft.AspNetCore.Identity;

namespace AlphaBugTracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set;} = DateTime.Now;
        public Project Project { get; set; }
        public TicketTypeCheck TicketTypeId { get; set; }
        public TicketPriorityLevel TicketPriorityId { get; set; }
        public TicketStatus TicketStatusId { get; set; }
        public IdentityUser OwnerUser { get; set; }
        public IdentityUser AssignedToUser { get; set; }


        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }




    }
    public enum TicketPriorityLevel
    {
        High,
        Medium,
        Low
    }
    public enum TicketStatus
    {
        Assigned,
        UnAssigned,
        InProgress,
        Completed
    }
    public enum TicketTypeCheck
    {
        Incident,
        LostRequest,
        LostResponse,
    }
}
