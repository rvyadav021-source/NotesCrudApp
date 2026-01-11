using Microsoft.AspNetCore.Mvc;
using NotesCrudApp.IService;
using NotesCrudApp.Model;

namespace NotesCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesIService _service; 
        public NotesController(NotesIService service)
        {
            _service = service;
        }

        // Get All notes api
        //returns list of notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notes>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        // Get note by Id API:  api/<NotesController>/5
        //Return specific note by Id else emoty note object
        [HttpGet("{id}")]
        public async Task<ActionResult<Notes?>> Get(int id)
        {
            var note = await _service.GetByIdAsync(id);
            if (note is null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // Method to create a new note : return created note 
        [HttpPost]
        public async Task<ActionResult<Notes>> Post([FromBody] Notes note_data)
        {
            var createdNote = await _service.AddAsync(note_data);
            return CreatedAtAction(nameof(Get), new { id = createdNote.Id }, createdNote);
        }

        // Update specific note 
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Notes note)
        {
            if (id != note.Id) return BadRequest();
            var updated = await _service.UpdateAsync(note);
            if (!updated) return NotFound();
            return NoContent();
        }

        // Delete specific note by it's id api/notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
