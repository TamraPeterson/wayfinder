using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using wayfinder.Interfaces;
using wayfinder.Models;

namespace wayfinder.Repositories
{
  public class ReservationsRepository : IRepository<Reservation, int>
  {
    private readonly IDbConnection _db;
    public ReservationsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Reservation Create(Reservation data)
    {
      string sql = @"
      INSERT INTO reservations
      (type, name, confirmationNumber, address, date, cost, tripId)
      VALUES
      (@Type, @Name, @ConfirmationNumber, @Address, @Date, @Cost, @TripId);
      ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    internal string Remove(int id)
    {
      string sql = @"
      DELETE FROM reservations
      WHERE id = @id LIMIT 1;
      ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "Delorted";
      }
      throw new Exception("could not delete");
    }

    public string Delete(int id)
    {
      throw new NotImplementedException();
    }

    internal List<Reservation> GetAll(int id)
    {
      string sql = @"
      SELECT * FROM reservations r
      WHERE r.tripId = @id;";
      return _db.Query<Reservation>(sql, new { id }).ToList();
    }

    public void Edit(Reservation data)
    {
      string sql = @"
      UPDATE reservations
      SET type = @Type, name =@Name, confirmationNumber = @ConfirmationNumber, address = @Address, date = @Date, cost = @Cost
      WHERE id = @Id;
      ";
      _db.Execute(sql, data);
    }

    public List<Reservation> GetAll()
    {
      throw new NotImplementedException();
    }

    public Reservation GetById(int id)
    {

      string sql = @"
      SELECT * FROM reservations
      WHERE id = @id;
      ";
      return _db.Query<Reservation>(sql, new { id }).FirstOrDefault();
    }
  }
}