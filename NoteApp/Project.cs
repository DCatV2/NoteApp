using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class Project
    {
        private List<Note> _notes;

        public Project()
        {
            _notes = new List<Note>();
        }
        public void AddNote (Note note) // Добавляет заметку в список
        {
            _notes.Add(note);
        }

        public void RemoveNote(Note note) // Удаляет заметку из списка
        {
            _notes.Remove(note);
        }
        public List<Note> GetNotes()
        {
            return _notes.ToList(); // Возвращаем копию списка
        }

        public List<Note> SortByModificationDate() 
        {
            return _notes.OrderByDescending(n => n.LastModifiedTime).ToList();
        }

        public List<Note> SortByCategory()
        {
            return _notes.OrderBy(n => n.Category).ToList();
        }
        
        public List<Note> GetNotesByCategory(NoteCategory category)
        {
            return _notes.Where(n => n.Category == category).ToList();
        }
    }
}
