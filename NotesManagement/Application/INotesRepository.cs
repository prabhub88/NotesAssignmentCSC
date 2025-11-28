using Domain.DTO;
namespace Application
{
    public interface INotesRepository
    {
        public Task<int> AddNoteAsync(NoteDto note);
        public Task<int> EditNoteAsync(NoteDto note);
        public Task<int> DeleteNoteAsync(string id);
        public Task<List<NoteDto>> GetAllNoteAsync();
        public Task<List<NoteDto>> GetNoteByTitleAsync(string title);
    }
}
