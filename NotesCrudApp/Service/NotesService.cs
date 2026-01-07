using NotesCrudApp.IService;
using NotesCrudApp.IRepository;
using NotesCrudApp.Model;

namespace NotesCrudApp.Service
{
    public class NotesService : NotesIService
    {
        public readonly NotesIRepository _NotesIRepo;
        public NotesService(NotesIRepository repo){
            this._NotesIRepo = repo;
        }

        public async Task<IEnumerable<Notes>> GetAllNotes()
        {
            return await this._NotesIRepo.GetAllNotes();
        }

        public async Task<Notes?> GetByIdAsync(int id) => await _NotesIRepo.GetByIdAsync(id);

        public async Task<Notes> AddAsync(Notes notes) => await _NotesIRepo.AddAsync(notes);

        public async Task<bool> UpdateAsync(Notes note) => await _NotesIRepo.UpdateAsync(note);

        public async Task<bool> DeleteAsync(int id) => await _NotesIRepo.DeleteAsync(id);
    }
}
