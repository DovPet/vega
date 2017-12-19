using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.Core;
using vega.Core.Models;
using vega.Persistence;

namespace vega.Controllers
{
     [Route("/api/reservations")]
    public class ReservationController : Controller
    {
        private readonly IMapper mapper;
         private readonly VegaDbContext context;
         private readonly IReservationRepository repository;
         private readonly IUnitOfWork unitOfWork;

        public ReservationController(VegaDbContext context, IMapper mapper,IReservationRepository repository,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateReservation([FromBody] ReservationResource reservationResource)
    {
      var reservation = mapper.Map<ReservationResource, Reservation>(reservationResource);

      repository.Add(reservation);
      await unitOfWork.CompleteAsync();

      reservation = await repository.GetReservation(reservation.Id);

      var result = mapper.Map<Reservation,ReservationResource>(reservation);

      return Ok(result);
    }

    [HttpPut("{id}")]
   // [Authorize]
    public async Task<IActionResult> UpdateReservation(int id, [FromBody] ReservationResource reservationResource)
    {
     var reservation = await repository.GetReservation(id);

      if (reservation == null)
        return NotFound();

      mapper.Map<ReservationResource, Reservation>(reservationResource, reservation);
      await unitOfWork.CompleteAsync();

      reservation = await repository.GetReservation(reservation.Id);
      var result = mapper.Map<Reservation, ReservationResource>(reservation);

      return Ok(result);
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteReservation(int id)
    {
      var reservation = await repository.GetReservation(id);

      if (reservation == null)
        return NotFound();
      repository.Remove(reservation);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    [HttpGet]
    //[Authorize]
    public async Task<IEnumerable<ReservationResource>> GetReservations()
    {
        var reservation = await repository.GetReservations();

        return mapper.Map<IEnumerable<Reservation>,IEnumerable<ReservationResource>>(reservation);
    }

    [HttpGet("{id}")]
    //[Authorize]
    public async Task<IActionResult> GetReservation(int id)
    {
      var reservation = await repository.GetReservation(id);

      if (reservation == null)
        return NotFound();

      var reservationResource = mapper.Map<Reservation, ReservationResource>(reservation);

      return Ok(reservationResource);
    }
    }
}