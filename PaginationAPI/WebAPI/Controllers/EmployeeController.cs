using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly PaginationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISieveProcessor _sieveProcessor;

        public EmployeeController(PaginationDbContext dbContext, IMapper mapper,
            ISieveProcessor sieveProcessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;   
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromBody]SieveModel query)
        {
            var results = _dbContext.Employees
                .Include(e => e.Address)
                .AsQueryable();

            var sievedModels = await _sieveProcessor.Apply(query, results)
                .ToListAsync();

            var employeesDto = _mapper.Map<List<EmployeeDto>>(sievedModels);

            var totalCount = await _sieveProcessor.Apply(query, results, 
                applyFiltering: false,
                applySorting: false)
                .CountAsync();

            var response = new PagedResult<EmployeeDto>(employeesDto, totalCount, query.Page.Value, query.PageSize.Value);

            return Ok(response);
        }
    }
}
