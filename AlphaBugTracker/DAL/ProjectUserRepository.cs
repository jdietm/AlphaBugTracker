using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaBugTracker.DAL
{
    public class ProjectUserRepository : IRepository<ProjectUser>
    {
        private readonly ApplicationDbContext _context;

        public ProjectUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ProjectUserRepository()
        {

        }

        public void Create(ProjectUser? entity)
        {
            _context.ProjectUser.Add(entity);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual ProjectUser? Get(Func<ProjectUser, bool>? firstFunction)
        {
            return _context.ProjectUser.First(firstFunction);
        }

        public ProjectUser? GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ProjectUser>? GetList(Func<ProjectUser, bool>? whereFunction)
        {
            List<ProjectUser> ProjectUser = null;
            if (whereFunction != null)
            {

                ProjectUser = _context.ProjectUser.Where(whereFunction).ToList();
            }
            return ProjectUser;
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
