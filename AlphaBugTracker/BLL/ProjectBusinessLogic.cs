using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class ProjectBusinessLogic
    {
        IRepository<Project> repo;

        public ProjectBusinessLogic()
        {

        }

        public ProjectBusinessLogic(IRepository<Project> repoArg)
        {
            repo = repoArg;
        }

        public List<Project> ListProjects_ByDefault()
        {
            return repo.GetList(t => true).ToList();
        }

        public void AddProject(Project project)
        {
            repo.Create(project);
            repo.Save();
        }

        public Project GetProjectById(Func<Project,bool> funcArg)
        {
            return repo.Get(funcArg);
        }

    }
}
