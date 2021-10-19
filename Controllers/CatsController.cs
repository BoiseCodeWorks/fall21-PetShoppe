using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShoppe.Models;
using PetShoppe.Services;

namespace PetShoppe.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CatsController : ControllerBase
  {
    // The slot to recieve the catservice
    private readonly CatsService _cs;

    // this is a constructor 
    public CatsController(CatsService cs)
    {
      // receiver received and stored
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Cat>> GetCats()
    {
      try
      {
        var cats = _cs.Get();
        return Ok(cats);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    // NOTE the curly boiz denotes the route param
    [HttpGet("{catId}")]
    public ActionResult<Cat> GetCatById(int catId)
    {
      try
      {
        var cat = _cs.Get(catId);
        return Ok(cat);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Cat> CreateCat([FromBody] Cat catData)
    {
      try
      {
        var cat = _cs.CreateCat(catData);
        return Ok(cat);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{catId}")]
    public ActionResult<Cat> EditCat(int catId, [FromBody] Cat catData)
    {
      try
      {
        var cat = _cs.Edit(catId, catData);
        return Ok(cat);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{catId}")]
    public ActionResult<Cat> DeleteCat(int catId)
    {
      try
      {
        // TODO validate userId
        var cat = _cs.Delete(catId);
        return Ok(cat);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}