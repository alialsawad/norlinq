using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinqNotesApi.Models;

//TODO: 
// - Add a services layer that the controller will use to apply business logic to the data
// - Add better error handling to return a specific error structure for the API
namespace LinqNotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return Ok(note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> DeleteNote(int id)
        {
            if (await _context.Notes.FindAsync(id) is Note note)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return Ok(note);
            }
            return NotFound();
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Note>> UpdateNote(int id, Note inputNote)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return NotFound();

            note.Title = inputNote.Title;
            note.Content = inputNote.Content;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}