using Application;
using AutoMapper;
using Domain.DTO;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repo
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesDBContext _dbContext;
        private readonly IMapper _mapper;
        public NotesRepository(NotesDBContext dBContext, IMapper mapper) 
        { _dbContext = dBContext;
            _mapper = mapper;
        }
       async Task<int> INotesRepository.AddNoteAsync(NoteDto noteDto)
        {
            var entityModel = _mapper.Map<Note>(noteDto);
            await _dbContext.Note.AddAsync(entityModel);
            commitTransaction();
            return 1;
        }

       async Task<int> INotesRepository.DeleteNoteAsync(NoteDto noteDto)
        {
            var entityModel = _mapper.Map<Note>(noteDto);
            var actualRow=await _dbContext.Note.Where(x=>x.Id==entityModel.Id).FirstOrDefaultAsync();
            if (actualRow != null)
            {
                _dbContext.Note.Remove(entityModel);
                commitTransaction();
                return 1;
            }
            else
                return 0;
        }

       async Task<int> INotesRepository.EditNoteAsync(NoteDto noteDto)
        {
            var entityModel = _mapper.Map<Note>(noteDto);
            var actualRow = await _dbContext.Note.Where(x => x.Id == entityModel.Id).FirstOrDefaultAsync();
            if (actualRow != null && actualRow.Id == entityModel.Id)
            {
                _dbContext.Note.Update(entityModel);
                commitTransaction();
                return 1;
            }
            else
                return 0;
        }

       async Task<List<NoteDto>> INotesRepository.GetAllNoteAsync()
        {
          return _mapper.Map<List<NoteDto>>(await _dbContext.Note.ToListAsync());
        }

      async Task<NoteDto> INotesRepository.GetNoteByTitleAsync(string title)
        {
            return _mapper.Map<NoteDto>(await _dbContext.Note.Where(n=>EF.Functions.Like(n.Title,title)).FirstOrDefaultAsync());
        }

        void commitTransaction()
        {
            _dbContext.SaveChanges();
        }
    }
}
