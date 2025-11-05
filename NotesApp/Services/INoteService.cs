using NotesApp.Data;

namespace NotesApp.Services
{
    public interface INoteService
    {
        Task<List<Note>> GetNotesAsync();
        Task<Note?> GetNoteAsync(int id);
        Task SaveNoteAsync(Note note);
        Task DeleteNoteAsync(int id);
    }
}