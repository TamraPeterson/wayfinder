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
  [Route("api/[controller]")]
  public class ReservationsController : ControllerBase
  {

    private readonly ReservationsService _rs;
    public ReservationsController(ReservationsService rs)
    {
      _rs = rs;
    }

    [HttpPost]
    public ActionResult<Reservation> Create([FromBody] Reservation reservationData)
    {
      try
      {
        Reservation reservation = _rs.Create(reservationData);
        return Ok(reservation);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Reservation> GetById(int id)
    {
      try
      {
        Reservation reservation = _rs.GetById(id);
        return Ok(reservation);
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
        _rs.Remove(id);
        return ("delorted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Reservation> Edit([FromBody] Reservation resData, int id)
    {
      try
      {
        resData.Id = id;
        Reservation res = _rs.Edit(resData);
        return Ok(res);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}