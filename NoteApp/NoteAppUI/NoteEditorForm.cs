using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace NoteAppUI
{
    public partial class NoteEditorForm : Form
    {
        private Project _project;
        public Note Note { get; private set; }
        public NoteEditorForm(Project project, Note note = null)
        {
            InitializeComponent();

            _project = project;

            //Привязка обработчиков событий
            OkButton.Click += OkButton_Click;
            CancelButton.Click += CancelButton_Click;

            //Заполняеем ComboBox значениями перечисления NoteCategory
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));

            if (note != null)
            {
                Note = note;
                TitleTextBox.Text = note.Title;
                CategoryComboBox.SelectedItem = note.Category;
                NoteTextBox.Text = note.Text;
            }
            else
            {
                Note = new Note("Без названия", NoteCategory.Разное, "");
            }
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
                //Получаем значения из текстового поля и комбинированного списка
                string title = TitleTextBox.Text; // TextBox для ввода названия
                if (string.IsNullOrEmpty(title)) //Проверка на пустое название
                {
                    title = "Без названия"; //Если пусто - ставим дефолтное название
                }

                //Проверка на длину названия
                if (title.Length > 50)
                {
                    MessageBox.Show("Название заметки не должно быть длиннее 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; //Возвращаем управление, не продолжая выполнение метода
                }

                NoteCategory category = (NoteCategory)CategoryComboBox.SelectedItem; //ComboBox для категории
                string text = NoteTextBox.Text; //TextBox для текста заметки

                //Если передана существующая заметка, обновляем её
                if (Note != null)
                {
                    Note.Title = title;
                    Note.Category = category;
                    Note.Text = text;
                }
                else
                {
                //Если это новая заметка, создаем её
                    Note newNote = new Note(title, category, text);
                    _project.AddNote(newNote);
                }

                //Если всё прошло успешно, закрываем форму для редактирования 
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        private void CancelButton_Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; //закрываем форму
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NoteEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("Форма пытается закрыться.");
        }

        private void NoteEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Debug.WriteLine("Форма закрыта.");
        }
    }
}
