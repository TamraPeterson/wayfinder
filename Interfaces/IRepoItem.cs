using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wayfinder.Interfaces
{
  public class IRepoItem<T>
  {
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}