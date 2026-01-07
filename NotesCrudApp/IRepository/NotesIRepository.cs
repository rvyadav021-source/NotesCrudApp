using NotesCrudApp.Model;

namespace NotesCrudApp.IRepository
{
    public interface NotesIRepository
    {
        Task <IEnumerable<Notes>> GetAllNotes();
        Task<Notes?> GetByIdAsync(int id);
        Task<Notes> AddAsync(Notes note);
        Task<bool> UpdateAsync(Notes note);
        Task<bool> DeleteAsync(int id);

    }
}
