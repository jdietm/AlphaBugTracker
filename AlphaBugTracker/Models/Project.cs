namespace AlphaBugTracker.Models
{
    public class Project
    {
        public int Id { get; set; } 
        public string Name { get; set; }    

        public virtual ICollection<Ticket> Tickets { get; set;}
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
    }
}
