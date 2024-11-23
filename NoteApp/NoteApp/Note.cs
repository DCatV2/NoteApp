using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    ///<summary>
    ///Предоставляет заметку с названием, категорией, текстом и датами.
    /// </summary>
    public class Note : ICloneable
    {
        private string _title;
        private string _text;
        private DateTime _creationTime;
        private DateTime _lastModified;

        public string Title
        {
            get => _title;
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("Название заметки не может быть длиннее 50 символов");
                _title = value;
                UpdateLastModified();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                UpdateLastModified();
            }
        }

        public NoteCategory Category { get; set; }

        public DateTime CreationTime => _creationTime;
        public DateTime LastModified => _lastModified;

        public Note()
        {
            _title = "Без названия";
            _creationTime = DateTime.Now;
            _lastModified = _creationTime;
        }

        private void UpdateLastModified()
        {
            _lastModified = DateTime.Now;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// Категория заметки.
    /// </summary>
    public enum NoteCategory
    {
        Работа,
        Дом,
        ЗдоровьеИСпорт,
        Люди,
        Документы,
        Финансы,
        Разное
    }
}