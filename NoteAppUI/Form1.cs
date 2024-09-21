using System;
using System.Linq;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class Form1 : Form
    {
        private Project project = new Project(); // Экземпляр проекта для хранени заметок

        public Form1()
        {
            InitializeComponent();
            InitializeCategories();
        }

        private void InitializeCategories()
        {
            // Добавляем предопределённые категории
            cmbCategories.Items.Add(NoteCategory.Work);
            cmbCategories.Items.Add(NoteCategory.Home);
            cmbCategories.Items.Add(NoteCategory.Finance);
            cmbCategories.Items.Add(NoteCategory.HealthAndSport);
            cmbCategories.Items.Add(NoteCategory.People);
            cmbCategories.Items.Add(NoteCategory.Documents);
            cmbCategories.Items.Add(NoteCategory.Other);

            // Установить первую категорию по умолчанию
            cmbCategories.SelectedIndex = 0;
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoteText.Text))
            {
                MessageBox.Show("Текст заметки не может быть пустым.");
                return;
            }

            var title = Microsoft.VisualBasic.Interaction.InputBox("Введите заголовок заметки");

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Заголовок не может быть пустым");
                return;
            }

            var newNote = new Note
            {
                Title = title,
                Text = txtNoteText.Text,
                Category = (NoteCategory)cmbCategories.SelectedItem // Приведение к NoteCategory
            };

            project.AddNote(newNote);
            LoadNotesForSelectedCategory(); // Обновить список заметок
            ClearInputs(); // Очистить текст заметки
        }

        private void btnEditNote_Click(object sender, EventArgs e)
        {
            var selectedNote = GetSelectedNote();
            if (selectedNote != null)
            {
                selectedNote.Update(selectedNote.Title, txtNoteText.Text, (NoteCategory)cmbCategories.SelectedItem);
                LoadNotesForSelectedCategory(); // Обновить список заметок
            }
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            var selectedNote = GetSelectedNote();
            if (selectedNote != null)
            {
                project.RemoveNote(selectedNote);
                LoadNotesForSelectedCategory(); // Обновить список заметок
                ClearInputs(); // Очистить текст заметки
            }
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedNoteInfo(); // Отображение информации о выбранной заметке
        }

        private void LoadNotesForSelectedCategory()
        {
            lstNotes.Items.Clear();
            var selectedCategory = (NoteCategory)cmbCategories.SelectedItem;

            foreach (var note in project.GetNotesByCategory(selectedCategory))
            {
                lstNotes.Items.Add(note.Title); // Добавляем названия заметок в ListBox
            }

            if (lstNotes.Items.Count >0)
            {
                lstNotes.SelectedIndex = 0; // Автоматический выбор первой заметки
            }
        }

        private Note GetSelectedNote()
        {
            if (lstNotes.SelectedItem != null)
            {
                string selectedTitle = lstNotes.SelectedItem.ToString();
                return project.GetNotes().FirstOrDefault(n => n.Title == selectedTitle);
            }
            return null;
        }

        private void DisplaySelectedNoteInfo()
        {
            var selectedNote = GetSelectedNote();
            if (selectedNote != null)
            {
                lblNoteTitle.Text = selectedNote.Title; // Обновляем заголовок
                txtNoteText.Text = selectedNote.Text;
                cmbCategories.SelectedItem = selectedNote.Category; // Устанавливаем выбранную категорию
            }
        }

        private void ClearInputs()
        {
            txtNoteText.Clear();
            cmbCategories.SelectedIndex = 0; // Сброс категории на первую
        }
    }
}
