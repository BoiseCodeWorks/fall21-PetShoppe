using System.ComponentModel.DataAnnotations;

namespace PetShoppe.Models
{
  public class Cat
  {

    public int Id { get; set; }

    [Required]
    [MinLength(4)]
    public string Name { get; set; }

    // You can set default values v like that
    [Range(1, int.MaxValue)]
    public int Age { get; set; } = 1;
    public string Color { get; set; }
    [Range(0, 15)]
    public int NumberOfLegs { get; set; } = 4;
    public bool HasTail { get; set; } = true;

    internal bool Removed { get; set; } = false;
  }
}