using Microsoft.AspNetCore.Mvc;

namespace Cw5;

[ApiController]
[Route("Visits")]
public class VisitsController : ControllerBase
{
    private IMockDb _mockDb;

    public VisitsController(IMockDb mockDb)
    {
        _mockDb = mockDb;
    }

    [HttpGet("{id}")]
    public IActionResult GetVisits(int id)
    {
        var visits = _mockDb.GetVisits(id);
        if (visits is null) return NotFound();
        
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit, int id)
    {
        if (_mockDb.AddVisit(visit, id)) return Created();

        return NotFound();
    }
}
