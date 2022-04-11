using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wayfinder.Models
{
  public class Reservation
  {
    public int Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string ConfirmationNumber { get; set; }
    public string Address { get; set; }
    public string Date { get; set; }
    public int Cost { get; set; }
    public int TripId { get; set; }

  }
}