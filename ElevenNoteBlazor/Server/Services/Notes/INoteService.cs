using ElevenNoteBlazor.Shared.Models.Note;

namespace ElevenNoteBlazor.Server.Services.Notes
{
    public interface INoteService
    {
        Task<bool> CreateNoteAsync(NoteCreate model);
        Task<IEnumerable<NoteListItem>> GetAllNotesAsync();
        Task<NoteDetail> GetNoteByIdAsync(int noteId);
        Task<bool> UpdateNoteAsync(NoteEdit model);
        Task<bool> DeleteNoteAsync(int noteId);
        Task<bool> DeleteNoteAsync(string userId);
        void SetUserId(string userId);
    }
}
