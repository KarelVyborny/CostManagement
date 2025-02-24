using AutoMapper;
using CostManagementSystem.Application.Models.Projects;
using CostManagementSystem.Data;
using Microsoft.EntityFrameworkCore;


namespace CostManagementSystem.Application.Services.Projects;

public class ProjectService(ApplicationDbContext _context, IMapper _mapper) : IProjectService
{


    public async Task<List<ProjectVM>> GetAllAsync()

    {
        var data = await _context.Projects.ToListAsync();
        var viewdata = _mapper.Map<List<ProjectVM>>(data);
        return viewdata;
    }

    public async Task AddAsync(ProjectVM Project)
    {

        {
            var data = _mapper.Map<Project>(Project);
            _context.Add(data);
            await _context.SaveChangesAsync();
        }
    }
}
