using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wayfinder.Models;
using wayfinder.Repositories;

namespace wayfinder.Services
{
  public class TripsService
  {
    private readonly TripsRepository _tr;
    public TripsService(TripsRepository tr)
    {
      _tr = tr;
    }
    internal List<Trip> GetAll()
    {
      return _tr.GetAll();
    }

    internal Trip Create(Trip tripData)
    {
      return _tr.Create(tripData);
    }

    internal Trip GetById(int id)
    {
      return _tr.GetById(id);
    }

    internal string Remove(int id)
    {
      return _tr.Remove(id);
    }

    internal Trip Update(Trip update)
    {
      Trip original = GetById(update.Id);
      original.Name = update.Name ?? original.Name;
      _tr.Edit(original);
      return original;
    }
  }
}