using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application;
using AutoMapper;
using Domain.DTO;

namespace NotesApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;
        public NotesController(INotesRepository notesRepository, IMapper mapper) { 
            _notesRepository = notesRepository; _mapper = mapper; }
        // GET: Notes
        public async Task<ActionResult> Index()
        {
            
            return View(await _notesRepository.GetAllNoteAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NoteDto noteDto)
        {
            noteDto.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("g"));
            await _notesRepository.AddNoteAsync(noteDto);
            return Json(new { success = true, noteDto });
        }
        
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] NoteDto noteDto)
        {
            await _notesRepository.EditNoteAsync(noteDto);
            return Json(new { success = true });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody]NoteDto noteDto)
        {
            var results = await _notesRepository.DeleteNoteAsync(noteDto.Id.ToString());
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<ActionResult> SearchByTitle(string title)
        {
            var notes = await _notesRepository.GetNoteByTitleAsync(title);
            return Json(new { notes });
        }

    }
}
