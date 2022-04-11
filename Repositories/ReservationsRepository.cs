using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wayfinder.Interfaces;
using wayfinder.Models;

namespace wayfinder.Repositories
{
  public class ReservationsRepository : IRepository<Reservation, int>
  {
    public Reservation Create(Reservation data)
    {
      throw new NotImplementedException();
    }

    public string Delete(int id)
    {
      throw new NotImplementedException();
    }

    public void Edit(Reservation data)
    {
      throw new NotImplementedException();
    }

    public List<Reservation> GetAll()
    {
      throw new NotImplementedException();
    }

    public Reservation GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}