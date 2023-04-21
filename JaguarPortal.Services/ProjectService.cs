using JaguarPortal.Core.Exceptions;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Core.Models;
using JaguarPortal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace JaguarPortal.Core.Repositories
{
    public class ProjectService : IProjectService
    {
        private readonly ILogger<ProjectService> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectService(ILogger<ProjectService> logger, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<Project>> GetList()
        {
            return await unitOfWork.Projects.GetAll();
        }

        public async Task<Project> GetById(long id)
        {
            Project? proj = await unitOfWork.Projects.GetById(id);
            if (proj is null)
            {
                logger.LogInformation("Project not found");
                throw new NotFoundObjectException("Project not found");
            }

            return proj;
        }

        public async Task Insert(Project obj)
        {
            obj.CreatedDate = DateTime.UtcNow;
            obj.CreatedUser = httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            await unitOfWork.Projects.Add(obj);
            unitOfWork.Save();
            logger.LogInformation("Project {Name} add", obj.Name);
        }

        public async Task Delete(long id)
        {
            Project? project = await unitOfWork.Projects.GetById(id);
            if (project is null)
                throw new NotFoundObjectException("Project not found");
            unitOfWork.Projects.Delete(project);
            unitOfWork.Save();
            logger.LogInformation("Project {id} deleted", id);
        }

        public async Task Update(long id, Project obj)
        {
            Project? project = await unitOfWork.Projects.GetById(id);
            if (project is null)
                throw new NotFoundObjectException("Project not found");

            project.LastModifiedDate = DateTime.Now;
            project.LastModifiedUser = httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            project.Name = obj.Name;
            unitOfWork.Projects.Update(project);
            unitOfWork.Save();
            logger.LogInformation("Project {id} updated", id);
        }
    }
}
