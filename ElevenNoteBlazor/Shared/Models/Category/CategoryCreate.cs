using System.ComponentModel.DataAnnotations;

namespace ElevenNoteBlazor.Shared.Models.Category
{
    public class CategoryCreate
    {
        [Required]
        public string? Name { get; set; }
    }
}
