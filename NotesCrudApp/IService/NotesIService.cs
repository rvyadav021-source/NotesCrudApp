using NotesCrudApp.Model;

namespace NotesCrudApp.IService
{
    public interface NotesIService
    {
        Task<IEnumerable<Notes>> GetAllNotes();
        Task<Notes?> GetByIdAsync(int id);
        Task<Notes> AddAsync(Notes note);
        Task<bool> UpdateAsync(Notes note);
        Task<bool> DeleteAsync(int id);

    }
}
