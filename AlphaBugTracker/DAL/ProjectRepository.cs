using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaBugTracker.DAL
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ProjectRepository()
        {

        }

        public void Create(Project? entity)
        {
            _context.Project.Add(entity);
        }

        public void Delete(int? id)
        {
            _context.Project.Remove(_context.Project.First(i => Equals(id)));
        }

        public virtual Project? Get(Func<Project, bool>? firstFunction)
        {
            return _context.Project.First(firstFunction);
        }

        public Project? GetById(int? id)
        {
            return _context.Project.FirstOrDefault(i=> i.Id == id); 
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

        public void Update(int? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Project>? GetListOrdered(string orderCriteria, bool orderType)
        {
            throw new NotImplementedException();
        }
    }
}
