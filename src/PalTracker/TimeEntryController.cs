using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository repo;

        public TimeEntryController(ITimeEntryRepository repository)
        {
            repo = repository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
            var created = repo.Create(timeEntry);
            return CreatedAtRoute("GetTimeEntry", new { id = timeEntry.Id }, created);
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(repo.List());
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long id)
        {

            if (repo.Contains(id))
            {
                return Ok(repo.Find(id));
            }
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (repo.Contains(id))
            {
                repo.Delete(id);
                return NoContent();
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TimeEntry toUpdate)
        {
            if (repo.Contains(id))
            {
                return Ok(repo.Update(id, toUpdate));
            }
            else
            return NotFound();

        }
    }
}