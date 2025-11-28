using Application;
using AutoMapper;
using Domain.DTO;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


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
          await  commitTransaction();
            return 1;
        }

       async Task<int> INotesRepository.DeleteNoteAsync(string  id)
        {
            var actualRow=await _dbContext.Note.Where(x=>x.Id== Convert.ToInt32(id)).FirstOrDefaultAsync();
            if (actualRow != null)
            {
                _dbContext.Note.Remove(actualRow);
               await commitTransaction();
                return 1;
            }
            else
                return 0;
        }

       async Task<int> INotesRepository.EditNoteAsync(NoteDto noteDto)
        {
            try
            {
                if (noteDto != null && noteDto.Id > 0)
                {
                    var actualRow = await _dbContext.Note.Where(x => x.Id == noteDto.Id).FirstOrDefaultAsync();
                    if (actualRow != null && actualRow.Id == noteDto.Id)
                    {

                        await _dbContext.Note
                               .Where(n => n.Id == noteDto.Id)
                               .ExecuteUpdateAsync(setters => setters
                                   .SetProperty(n => n.Title, noteDto.Title)
                                   .SetProperty(n => n.Content, noteDto.Content)
                                   .SetProperty(n => n.Priority, noteDto.Priority)
                               );
                        return 1;
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<List<NoteDto>> INotesRepository.GetAllNoteAsync()
        {
            var notes = await _dbContext.Note.OrderByDescending(o=>o.CreatedDate).ToListAsync();
            var mapnotes= _mapper.Map<List<NoteDto>>(notes);
            return mapnotes;
        }

      async Task<List<NoteDto>> INotesRepository.GetNoteByTitleAsync(string title)
        {
            var reslts = await _dbContext.Note.Where(n =>n.Title.Contains(title)).OrderByDescending(o=>o.CreatedDate).ToListAsync();
            return _mapper.Map<List<NoteDto>>(reslts);
        }

        async Task commitTransaction()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
