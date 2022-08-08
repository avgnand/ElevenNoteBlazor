using System.ComponentModel.DataAnnotations;

namespace ElevenNoteBlazor.Shared.Models.Note
{
    public class NoteCreate
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        public int CategoryId { get; set; }
    }
}
