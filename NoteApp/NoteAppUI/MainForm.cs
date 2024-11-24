using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        private Project _project; //Поле для хранения экземпляра Project
        public MainForm()
        {
            InitializeComponent();
            _project = new Project(); //Инициализация экземпляра класса Project
            //Инициализируем компоненты конструктора
            NotesListBox.SelectedIndexChanged += NotesListBox_SelectedIndexChanged;
            this.EditNoteButton.Click += new System.EventHandler(this.EditNoteButton_Click);
            this.RemoveNoteButton.Click += new System.EventHandler(this.RemoveNoteButton_Click);
            UpdateNotesList(); //Заполняем список заметок, если они есть
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            using (var noteEditor = new NoteEditorForm(_project)) //передаем _project в конструктор
            {
                if (noteEditor.ShowDialog() == DialogResult.OK)
                {
                    _project.Notes.Add(noteEditor.Note); //Добавляем заметку
                    UpdateNotesList(); //Обновляем список заметок
                }
            }
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote)
            {
                var editorForm = new NoteEditorForm(_project, selectedNote); //передаем _project и выбранную заметку
                
                    if (editorForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateNotesList(); //Обновляем список заметок после редактирования
                    }
                
            }
            else
            {
                MessageBox.Show("Выберите заметку для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void RemoveNoteButton_Click(Object sender, EventArgs e)
        {
           var selectedNote = NotesListBox.SelectedItem as Note;
            if (selectedNote != null)
            {
                _project.Notes.Remove(selectedNote); //Удаляем заметку
                UpdateNotesList(); //Обновляем список
            }
        }

        private void UpdateNotesList()
        {
            NotesListBox.DataSource = null; //Сбрасываем текущий источник данных
            NotesListBox.DataSource = _project.Notes; //Назначаем список заметок
            NotesListBox.DisplayMember = "Title"; //Отображаем название заметки
            NotesListBox.ClearSelected(); //Очищаем выбранные элементы
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote)
            {
                NoteTextBox.Text = selectedNote.Text; //Отображаем текст заметки
            }
            else
            {
                NoteTextBox.Clear(); //Очищаем поле, если ничего не выбрано
            }
        }
    }
}
