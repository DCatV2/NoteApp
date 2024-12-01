using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
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
            _project = ProjectManager.LoadFromFile(); //Инициализация экземпляра класса Project
            //Инициализируем компоненты конструктора
            NotesListBox.SelectedIndexChanged += NotesListBox_SelectedIndexChanged;
            this.EditNoteButton.Click += new System.EventHandler(this.EditNoteButton_Click);
            this.RemoveNoteButton.Click += new System.EventHandler(this.RemoveNoteButton_Click);
            this.CategoryFilterComboBox.SelectedIndexChanged += CategoryFilterComboBox_SelectedIndexChanged;

            //Заполняем ComboBox категориями, включая пункт "Все категории"
            var categories = new[] { "Все категории" }
            .Concat(Enum.GetValues(typeof(NoteCategory)).Cast<object>())
            .ToList();
            CategoryFilterComboBox.DataSource = categories;
            CategoryFilterComboBox.SelectedIndex = 0; //Устанавливаем "Все категории" как выбранное значение по умолчанию

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
                    ProjectManager.SaveToFile(_project); //Сохраняем проект в файл
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
                        ProjectManager.SaveToFile(_project); // Сохраняем проект в файл
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
                ProjectManager.SaveToFile(_project); // Сохраняем проект в файл
            }
        }

        private void UpdateNotesList()
        {
            //Получаем выбранную категорию из фильтра
            var selectedCategory = CategoryFilterComboBox.SelectedItem;

            //Фильтруем заметки по категории, если выбрана
            var filteredNotes = selectedCategory is NoteCategory category
                ? _project.Notes.Where(note => note.Category == category).ToList()
                : _project.Notes; //Если выбрано "Все категории", возвращаем полный список заметок

            NotesListBox.DataSource = null; //Сбрасываем текущий источник данных
            NotesListBox.DataSource = filteredNotes; //Назначаем отфильтрованный список заметок
            NotesListBox.DisplayMember = "Title"; //Отображаем название заметки
            NotesListBox.ClearSelected(); //Очищаем выбранные элементы
        }

        private void CategoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNotesList(); // Обновляем список заметок при изменении категории
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote)
            {
                NoteTextBox.Text = selectedNote.Text; //Отображаем текст заметки

                //Отображаем информацию о заметке
                TitleLabel.Text = $"{selectedNote.Title}";
                CreationDateLabel.Text = $"Создано: {selectedNote.CreationTime:G}";
                LastModifiedDateLabel.Text = $"Обновлено: {selectedNote.LastModified:G}";
            }
            else
            {
                NoteTextBox.Clear(); //Очищаем поле, если ничего не выбрано
                TitleLabel.Text = "Название заметки";
                CreationDateLabel.Text = "Создано: - ";
                LastModifiedDateLabel.Text = "Обновлено: - ";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
