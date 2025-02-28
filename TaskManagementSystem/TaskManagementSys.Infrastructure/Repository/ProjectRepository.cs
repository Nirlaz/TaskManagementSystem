﻿using Microsoft. EntityFrameworkCore;
using TaskManagementSystem. TaskManagementSys. Domain. Entites;
using TaskManagementSystem. TaskManagementSys. Domain. Interfaces;
using TaskManagementSystem. TaskManagementSys. Infrastructure. Database;

namespace TaskManagementSystem. TaskManagementSys. Infrastructure. Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository ( ApplicationDbContext context )
        {
            _context = context;
        }
        public async Task<string> AddProject ( Project project )
        {
            var result = await _context.Projects.AddAsync(project);
            await _context. SaveChangesAsync ( );
            return "Data Successfully added";
        }

        public async Task<string> DeleteProjectById ( Guid projectId )
        {
            var existingProject = await _context.Projects.FindAsync(projectId);
            if( existingProject != null ) {
                 _context. Projects. Remove ( existingProject );
                await _context.SaveChangesAsync ( );
                return "Project Delete Successful";
            }
            return @"Project Don't Exist";
        }


        public async Task<ICollection<Project?>> GetProjectById ( Guid projectId )
        {
            return await _context. Projects. Include ( p => p. Taskses ). Where ( p => p. ProjectId == projectId ).ToListAsync();
        }
    }
}
