using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Core.Models;
using vega.Persistence;

namespace vega.Controllers
{
    public class StatesController: Controller
  {
    private readonly VegaDbContext context;
    private readonly IMapper mapper;
    public StatesController(VegaDbContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;
    }

    [HttpGet("/api/states")]
    public async Task<IEnumerable<StateResource>> GetStates()
    {
        var states = await context.States.ToListAsync();

        return mapper.Map<List<State>, List<StateResource>>(states);
    }
  }
}