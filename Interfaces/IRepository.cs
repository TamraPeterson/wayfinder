using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wayfinder.Interfaces
{
  public interface IRepository<T, Tid>
  {
    List<T> GetAll();
    T GetById(int id);
    T Create(T data);
    void Edit(T data);
    string Delete(Tid id);
  }
}