using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain.DTO;
namespace NotesTest
{
    [TestClass]
    public class NoteTest
    {
        [TestMethod]
        public void AddNote_Test()
        {
            // Arrange
            var note = new NoteDto
            {
                Title = "Test Note",
                Content = "This is a test note.",
                Priority = "High"
            };

            // Act
          // var result = notesRepository.AddNoteAsync(note);

            // Assert
            // Here you would assert that the note was added successfully
            // For example: Assert.IsTrue(result > 0);
        }
    }
}
