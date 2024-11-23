using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    ///<summary>
    ///Представляет коллекцию заметок.
    /// </summary>
    public class Project
    {
        private readonly List<Note> _notes;

        public IEnumerable<Note> Notes => _notes;

        public Project()
        {
            _notes = new List<Note>();

        }

        public void AddNote(Note note)
        {
            _notes.Add(note);
        }

        public void RemoveNote(Note note)
        {
            _notes.Remove(note);
        }
    }
}