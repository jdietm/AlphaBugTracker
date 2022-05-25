using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaBugTracker.DAL
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository()
        {

        }

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Project? entity)
        {
            _context.Project.Add(entity);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual  Project Get(Func<Project, bool> firstFunction)
        {

            Project project = _context.Project.Where(firstFunction).First();
            return project;
        }

        public ICollection<Project>? GetList(Func<Project, bool>? whereFunction)
        {
            List<Project> Project = null;
            if (whereFunction != null)
            {

                Project = _context.Project.Where(whereFunction).ToList();
            }
            return Project;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Project? entity)
        {
            throw new NotImplementedException();
        }
    }
}
