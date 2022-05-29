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

        public virtual List<ProjectUser> ListProjectsUsers_ByProject(int id)
        {
            return repo.GetList(p => p.Project.Id == id ).ToList();
        }

        public virtual List<ProjectUser> ListProjectsUsers_ByProjectFunc(Func<ProjectUser, bool>? whereFunction)
        {
            return repo.GetList(whereFunction).ToList();
        }



        public void AddProjectUser(ProjectUser projectUser)
        {
            repo.Create(projectUser);
            repo.Save();
        }

        public virtual ProjectUser GetProjectById(Func<ProjectUser,bool> funcArg)
        {
            return repo.Get(funcArg);
        }

        public virtual void RemoveUserFromProject (int id)
        {
            repo.Delete(id);
            repo.Save();
        }

    }
}
