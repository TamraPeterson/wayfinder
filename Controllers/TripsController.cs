using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wayfinder.Models;
using wayfinder.Services;

namespace wayfinder.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]

  public class TripsController : ControllerBase
  {
    private readonly TripsService _ts;
    private readonly ReservationsService _rs;
    public TripsController(TripsService ts, ReservationsService rs)
    {
      _ts = ts;
      _rs = rs;
    }

    [HttpGet]
    public ActionResult<List<Trip>> GetAll()
    {
      try
      {
        List<Trip> trips = _ts.GetAll();
        return Ok(trips);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Trip> Create([FromBody] Trip tripData)
    {
      try
      {
        Trip trip = _ts.Create(tripData);
        return Ok(tripData);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Trip> GetById(int id)
    {
      try
      {
        Trip trip = _ts.GetById(id);
        return Ok(trip);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Remove(int id)
    {
      try
      {
        _ts.Remove(id);
        return Ok("dlorted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Trip> Update([FromBody] Trip tripData, int id)
    {
      try
      {
        tripData.Id = id;
        Trip trip = _ts.Update(tripData);
        return Ok(trip);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Get all reservations by trip id
    [HttpGet("{id}/reservations")]
    public ActionResult<List<Reservation>> GetAllReservations(int id)
    {
      try
      {
        List<Reservation> reservations = _rs.GetAll(id);
        return Ok(reservations);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}