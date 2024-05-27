using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PMS.DataLayer.Context;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.ProjectAppUsers;
using System;
using System.Collections.Generic;
using System.Linq;



namespace PMS.ServiceLayer.Services.Concrete
{
    public class ProjectAppUserService : IProjectAppUserService
    {
        private readonly PMSDbContext dbContext;
        private readonly IMapper mapper;

        public ProjectAppUserService(PMSDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public List<ProjectAppUserDto> GetAllListProjectAppUserNonDeletedAsync()
        {
            var projectAppUser =  dbContext.ProjectAppUsers.Include(x=>x.AppUser).Include(x => x.Project);
            
            var map = mapper.Map<List<ProjectAppUserDto>>(projectAppUser);

            return map;
        }
        public async System.Threading.Tasks.Task<bool> CreateProjectAppUserAsync(ProjectAppUserAddDto projectAppUserAddDto)
        {
            var map = mapper.Map<ProjectAppUser>(projectAppUserAddDto);
            var isAny = await dbContext.ProjectAppUsers.AnyAsync(x=>x.ProjectId==projectAppUserAddDto.ProjectId && x.AppUserId==projectAppUserAddDto.AppUserId);
            if(isAny != true)
            {
                await dbContext.ProjectAppUsers.AddAsync(map);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void DeleteProjectAppUser(Guid projectId,Guid appUserId)
        {
            var projectAppUser =  dbContext.ProjectAppUsers.FirstOrDefault(pau => pau.ProjectId == projectId && pau.AppUserId == appUserId);

            dbContext.ProjectAppUsers.Remove(projectAppUser);
            dbContext.SaveChanges();
        }
    }
}
