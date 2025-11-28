using Domain.DTO;
namespace Application
{
    public interface INotesRepository
    {
        public Task<int> AddNoteAsync(NoteDto note);
        public Task<int> EditNoteAsync(NoteDto note);
        public Task<int> DeleteNoteAsync(NoteDto note);
        public Task<List<NoteDto>> GetAllNoteAsync();
        public Task<NoteDto> GetNoteByTitleAsync(string title);
    }
}
