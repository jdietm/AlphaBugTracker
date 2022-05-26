using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class ProjectUserBusinessLogic
    {
        IRepository<ProjectUser> repo;

        public ProjectUserBusinessLogic(IRepository<ProjectUser> repoArg)
        {
            repo = repoArg;
        }
        public ProjectUserBusinessLogic()
        {

        }

        public List<ProjectUser> ListProjectsUsers_ByProject(int id)
        {
            return repo.GetList(u => u.Id == id ).ToList();
        }

        public  void AddProject(ProjectUser projectUser)
        {
            repo.Create(projectUser);
            repo.Save();
        }

        public virtual ProjectUser GetProjectById(Func<ProjectUser,bool> funcArg)
        {
            return repo.Get(funcArg);
        }

    }
}
