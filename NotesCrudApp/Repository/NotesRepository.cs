using Microsoft.EntityFrameworkCore;
using NotesCrudApp.Data;
using NotesCrudApp.IRepository;
using NotesCrudApp.Model;

namespace NotesCrudApp.Repository
{
    public class NotesRepository: NotesIRepository
    {
        public readonly AppDbContext _dbContext;

     public NotesRepository(AppDbContext dbContext) { 
        this._dbContext = dbContext;
        }

        public async Task<Notes> AddAsync(Notes note)
        {
            this._dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
            return note;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var note = this._dbContext.Notes.Find(id);
            
            if(note == null)
            {
                return false;
            }

            this._dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Notes>> GetAllAsync()
        {
            return await this._dbContext.Notes.ToListAsync();
        }

        public async Task<Notes?> GetByIdAsync(int id)
        {
            return await this._dbContext.Notes.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Notes note)
        {
            //Notes notes = this._dbContext.Notes.Find(note.Id);
            //var existingNote = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == note.Id);
            //if (existingNote == null)
            //    return false;

            //existingNote.Title = note.Title;
            //existingNote.Content = note.Content;
            //existingNote.Priority = note.Priority;

           

            _dbContext.Notes.Update(note);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
