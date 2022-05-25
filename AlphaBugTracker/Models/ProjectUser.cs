using Microsoft.AspNetCore.Identity;

namespace AlphaBugTracker.Models
{
    public class ProjectUser
    {
        public int Id { get; set; }
        public Project  Project;
        public IdentityUser UserMember;
    }
}
