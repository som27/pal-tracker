// using Microsoft.AspNetCore.Mvc;

// namespace PalTracker
// {
//     [Route("/time_entries")]
//     public class TimeEntryController : ControllerBase
//     {
//         private readonly ITimeEntryRepository _repository;

//         public TimeEntryController(ITimeEntryRepository repository)
//         {
//             _repository = repository;
//         }

//         [HttpPost]
//         public IActionResult Create([FromBody] TimeEntry timeEntry)
//         {
//             var createdTimeEntry = _repository.Create(timeEntry);

//             return CreatedAtRoute("GetTimeEntry", new {id = createdTimeEntry.Id}, createdTimeEntry);
//         }

//         [HttpGet("{id}", Name = "GetTimeEntry")]
//         public IActionResult Read(long id)
//         {
//             return _repository.Contains(id) ? (IActionResult) Ok(_repository.Find(id)) : NotFound();
//         }

//         [HttpGet]
//         public IActionResult List()
//         {
//             return Ok(_repository.List());
//         }

//         [HttpPut("{id}")]
//         public IActionResult Update(long id, [FromBody] TimeEntry timeEntry)
//         {
//             return _repository.Contains(id) ? (IActionResult) Ok(_repository.Update(id, timeEntry)) : NotFound();
//         }

//         [HttpDelete("{id}")]
//         public IActionResult Delete(long id)
//         {
//             if (!_repository.Contains(id))
//             {
//                 return NotFound();
//             }

//             _repository.Delete(id);

//             return NoContent();
//         }
//     }
// }



using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time_entries")]
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
            return CreatedAtRoute("GetTimeEntry", new { id = created.Id }, created);
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