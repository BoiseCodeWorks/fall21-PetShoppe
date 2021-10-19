using System;
using System.Collections.Generic;
using PetShoppe.Models;

namespace PetShoppe.Data
{
  public class FakeDb
  {
    private Random _random = new Random();
    public List<Cat> Cats = new List<Cat>();

    public int GenerateId()
    {
      return _random.Next(100000, 10000000);
    }

  }
}