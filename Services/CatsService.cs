using System.Collections.Generic;
using System.Linq;
using PetShoppe.Data;
using PetShoppe.Models;

namespace PetShoppe.Services
{
  public class CatsService
  {

    private readonly FakeDb _db;

    public CatsService(FakeDb db)
    {
      _db = db;
    }

    public Cat CreateCat(Cat catData)
    {
      catData.Id = _db.GenerateId();
      _db.Cats.Add(catData);
      return catData;
    }

    // METHOD OVERLOADING

    /// <summary>
    /// Returns a list of all cats
    /// </summary>
    /// <returns></returns>
    public List<Cat> Get()
    {
      return _db.Cats.Where(c => c.Removed == false).ToList();
    }

    /// <summary>
    /// Finds and retuns a cat by its id
    /// </summary>
    /// <param name="catId"></param>
    /// <returns></returns>
    public Cat Get(int catId)
    {
      // TODO replace this line with async call to db
      var cat = _db.Cats.Find(c => c.Id == catId && c.Removed == false);
      if (cat == null)
      {
        throw new System.Exception("Invalid Cat Id");
      }
      return cat;
    }


    public Cat Edit(int catId, Cat catData)
    {
      var cat = Get(catId);
      // REVIEW NULL COALESCENCE ?? in JS it was ||
      cat.Name = catData.Name ?? cat.Name;
      cat.Color = catData.Color ?? cat.Color;
      cat.Age = catData.Age;
      cat.HasTail = catData.HasTail;
      cat.NumberOfLegs = catData.NumberOfLegs;
      return cat;
    }

    public Cat Delete(int catId)
    {
      var cat = Get(catId);
      cat.Removed = true;
      // _db.Cats.Remove(cat);
      return cat;
    }
  }
}