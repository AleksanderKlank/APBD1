using Microsoft.AspNetCore.Mvc;

namespace Cw5;

[ApiController]
[Route("animals")]
public class AnimalsController : ControllerBase
{
    private IMockDb _mockDb;
    
    public AnimalsController(IMockDb imockdb)
    {
        _mockDb = imockdb;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_mockDb.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var animal = _mockDb.GetById(id);
        if (animal is null) return NotFound();
            
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        _mockDb.Add(animal);
        return Created();
    }
    
    [HttpPut]
    public IActionResult Edit(int id, Animal animal)
    {
        if (_mockDb.Edit(id, animal))
            return Ok();
    
        return BadRequest();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        if (_mockDb.Delete(id))
            return Ok();
        
        return BadRequest();
    }
    
    
    
}