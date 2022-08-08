using System.ComponentModel.DataAnnotations;

namespace ElevenNoteBlazor.Shared.Models.Category
{
    public class CategoryEdit
    {
        [Required]
        public string? Name { get; set; }
    }
}
