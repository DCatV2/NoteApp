using System;
using System.Linq;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class Form1 : Form
    {
        private Project project = new Project(); // ��������� ������� ��� ������� �������

        public Form1()
        {
            InitializeComponent();
            InitializeCategories();
        }

        private void InitializeCategories()
        {
            // ��������� ��������������� ���������
            cmbCategories.Items.Add(NoteCategory.Work);
            cmbCategories.Items.Add(NoteCategory.Home);
            cmbCategories.Items.Add(NoteCategory.Finance);
            cmbCategories.Items.Add(NoteCategory.HealthAndSport);
            cmbCategories.Items.Add(NoteCategory.People);
            cmbCategories.Items.Add(NoteCategory.Documents);
            cmbCategories.Items.Add(NoteCategory.Other);

            // ���������� ������ ��������� �� ���������
            cmbCategories.SelectedIndex = 0;
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoteText.Text))
            {
                MessageBox.Show("����� ������� �� ����� ���� ������.");
                return;
            }

            var title = Microsoft.VisualBasic.Interaction.InputBox("������� ��������� �������");

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("��������� �� ����� ���� ������");
                return;
            }

            var newNote = new Note
            {
                Title = title,
                Text = txtNoteText.Text,
                Category = (NoteCategory)cmbCategories.SelectedItem // ���������� � NoteCategory
            };

            project.AddNote(newNote);
            LoadNotesForSelectedCategory(); // �������� ������ �������
            ClearInputs(); // �������� ����� �������
        }

        private void btnEditNote_Click(object sender, EventArgs e)
        {
            var selectedNote = GetSelectedNote();
            if (selectedNote != null)
            {
                selectedNote.Update(selectedNote.Title, txtNoteText.Text, (NoteCategory)cmbCategories.SelectedItem);
                LoadNotesForSelectedCategory(); // �������� ������ �������
            }
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            var selectedNote = GetSelectedNote();
            if (selectedNote != null)
            {
                project.RemoveNote(selectedNote);
                LoadNotesForSelectedCategory(); // �������� ������ �������
                ClearInputs(); // �������� ����� �������
            }
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedNoteInfo(); // ����������� ���������� � ��������� �������
        }

        private void LoadNotesForSelectedCategory()
        {
            lstNotes.Items.Clear();
            var selectedCategory = (NoteCategory)cmbCategories.SelectedItem;

            foreach (var note in project.GetNotesByCategory(selectedCategory))
            {
                lstNotes.Items.Add(note.Title); // ��������� �������� ������� � ListBox
            }

            if (lstNotes.Items.Count >0)
            {
                lstNotes.SelectedIndex = 0; // �������������� ����� ������ �������
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
                lblNoteTitle.Text = selectedNote.Title; // ��������� ���������
                txtNoteText.Text = selectedNote.Text;
                cmbCategories.SelectedItem = selectedNote.Category; // ������������� ��������� ���������
            }
        }

        private void ClearInputs()
        {
            txtNoteText.Clear();
            cmbCategories.SelectedIndex = 0; // ����� ��������� �� ������
        }
    }
}
