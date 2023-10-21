using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Common.Models;

namespace DAL.Repositories
{
    public class ProjectRepository
    {
        private readonly string _dataFilePath = "../DataAccess/projects.json";

        public List<Project> GetProjects()
        {
            using (StreamReader reader = new StreamReader(_dataFilePath))
            {
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Project>>(json);
            }
        }

        public Project GetProjectById(Guid id)
        {
            var projects = GetProjects();
            return projects.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProject(Project project)
        {
            var projects = GetProjects();
            project.Id = Guid.NewGuid();
            projects.Add(project);
            SaveProjectsToJson(projects);
        }

        public void UpdateProject(Project project)
        {
            var projects = GetProjects();
            var existingProject = projects.FirstOrDefault(p => p.Id == project.Id);
            if (existingProject != null)
            {
                existingProject.Name = project.Name;
                existingProject.CustomerCompany = project.CustomerCompany;
                existingProject.ExecutorCompany = project.ExecutorCompany;
                existingProject.StartDate = project.StartDate;
                existingProject.EndDate = project.EndDate;
                existingProject.Priority = project.Priority;
                existingProject.ProjectManager = project.ProjectManager;

                SaveProjectsToJson(projects);
            }
        }

        public void DeleteProject(Guid id)
        {
            var projects = GetProjects();
            var projectToDelete = projects.FirstOrDefault(p => p.Id == id);
            if (projectToDelete != null)
            {
                projects.Remove(projectToDelete);
                SaveProjectsToJson(projects);
            }
        }

        private void SaveProjectsToJson(List<Project> projects)
        {
            string json = JsonSerializer.Serialize(projects);
            File.WriteAllText(_dataFilePath, json);
        }
    }
}
