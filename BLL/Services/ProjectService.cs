using System;
using System.Collections.Generic;
using Common.Models;
using DAL;
using DAL.Repositories;

namespace BLL.Services
{
    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository;

        public ProjectService(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<Project> GetProjects()
        {
            return _projectRepository.GetProjects();
        }

        public Project GetProjectById(Guid id)
        {
            return _projectRepository.GetProjectById(id);
        }

        public void CreateProject(Project project)
        {
            _projectRepository.CreateProject(project);
        }

        public void UpdateProject(Project project)
        {
            _projectRepository.UpdateProject(project);
        }

        public void DeleteProject(Guid id)
        {
            _projectRepository.DeleteProject(id);
        }
    }
}
