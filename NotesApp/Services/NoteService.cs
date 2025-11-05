using Microsoft.EntityFrameworkCore;
using NotesApp.Data;

namespace NotesApp.Services
{
    public class NoteService : INoteService
    {
        private readonly NotesDbContext _context;
        public NoteService(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            return await _context.Notes.OrderByDescending(n => n.CreatedAt).ToListAsync();
        }

        public async Task<Note?> GetNoteAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task SaveNoteAsync(Note note)
        {
            if (_context.Notes.Any(n => n.Id == note.Id))
            {
                note.UpdatedAt = DateTime.UtcNow;
                _context.Notes.Update(note);
            }
            else
            {
                _context.Notes.Add(note);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }
    }
}