using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vega.Core;
using vega.Core.Models;
using vega.Persistence;

namespace vega.Controllers.Resources
{
    [Route("/api/parkingLot")]
    public class ParkingLotController : Controller
    {
         private readonly IMapper mapper;
         private readonly VegaDbContext context;
         private readonly IParkingLotRepository repository;
         private readonly IUnitOfWork unitOfWork;

    public ParkingLotController(VegaDbContext context, IMapper mapper,IParkingLotRepository repository,IUnitOfWork unitOfWork)
    {
      this.mapper = mapper;
      this.context = context;
      this.repository = repository;
      this.unitOfWork = unitOfWork;

    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateParkingLot([FromBody] ParkingLotResource parkingLotResource)
    {
      var parkingLot = mapper.Map<ParkingLotResource, ParkingLot>(parkingLotResource);

      repository.Add(parkingLot);
      await unitOfWork.CompleteAsync();

      parkingLot = await repository.GetParkingLot(parkingLot.Id);

      var result = mapper.Map<ParkingLot,ParkingLotResource>(parkingLot);

      return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateParkingLot(int id, [FromBody] ParkingLotResource parkingLotResource)
    {
     var parkingLot = await repository.GetParkingLot(id);

      if (parkingLot == null)
        return NotFound();

      mapper.Map<ParkingLotResource, ParkingLot>(parkingLotResource, parkingLot);
      await unitOfWork.CompleteAsync();

      parkingLot = await repository.GetParkingLot(parkingLot.Id);
      var result = mapper.Map<ParkingLot, ParkingLotResource>(parkingLot);

      return Ok(result);
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteParkingLot(int id)
    {
      var parkingLot = await repository.GetParkingLot(id);

      if (parkingLot == null)
        return NotFound();
      repository.Remove(parkingLot);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    [HttpGet]
//  [Authorize]
    public async Task<IEnumerable<ParkingLotResource>> GetParkingLots()
    {
        var parkingLots = await repository.GetParkingLots();

        return mapper.Map<IEnumerable<ParkingLot>,IEnumerable<ParkingLotResource>>(parkingLots);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetParkingLot(int id)
    {
      var parkingLot = await repository.GetParkingLot(id);

      if (parkingLot == null)
        return NotFound();

      var parkingLotResource = mapper.Map<ParkingLot, ParkingLotResource>(parkingLot);

      return Ok(parkingLotResource);
    }
    }
}