using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wayfinder.Controllers;
using wayfinder.Models;
using wayfinder.Repositories;

namespace wayfinder.Services
{

  public class ReservationsService
  {
    private readonly ReservationsRepository _rr;
    public ReservationsService(ReservationsRepository rr)
    {
      _rr = rr;
    }


    internal List<Reservation> GetAll(int id)
    {
      return _rr.GetAll(id);
    }

    internal Reservation Create(Reservation reservationData)
    {
      return _rr.Create(reservationData);
    }

    internal Reservation GetById(int id)
    {
      return _rr.GetById(id);
    }

    internal string Remove(int id)
    {
      return _rr.Remove(id);
    }

    internal Reservation Edit(Reservation resData)
    {
      Reservation original = _rr.GetById(resData.Id);
      original.Type = resData.Type ?? original.Type;
      original.Name = resData.Name ?? original.Name;
      original.ConfirmationNumber = resData.ConfirmationNumber ?? original.ConfirmationNumber;
      original.Address = resData.Address ?? original.Address;
      original.Date = resData.Date ?? original.Date;
      original.Cost = resData.Cost;
      original.TripId = original.TripId;
      _rr.Edit(original);
      return original;
    }
  }
}