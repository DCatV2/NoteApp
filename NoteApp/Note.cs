using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp

{
    public class Note : ICloneable
    {
        public string Title { get; set; }
        public NoteCategory Category { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastModifiedTime { get; private set; }

        public Note()
        {
            CreationTime = DateTime.Now;
            LastModifiedTime = DateTime.Now;   
        }

        public void Update(string title, string text, NoteCategory category)
        {
            if (title.Length > 50)
            {
                throw new ArgumentException("Название не должно быть длиннее 50 символов.");
            }
            Title = title;
            Text = text;
            Category = category;
            LastModifiedTime = DateTime.Now;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}