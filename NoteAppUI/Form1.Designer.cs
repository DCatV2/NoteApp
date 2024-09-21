namespace NoteAppUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbCategories = new ComboBox();
            lstNotes = new ListBox();
            lblNoteTitle = new Label();
            lblNoteCategory = new Label();
            lblNoteDates = new Label();
            txtNoteText = new TextBox();
            btnAddNote = new Button();
            btnEditNote = new Button();
            btnDeleteNote = new Button();
            SuspendLayout();
            // 
            // cmbCategories
            // 
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(7, 19);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(144, 23);
            cmbCategories.TabIndex = 0;
            cmbCategories.Text = "Выберите категорию";
            // 
            // lstNotes
            // 
            lstNotes.FormattingEnabled = true;
            lstNotes.ItemHeight = 15;
            lstNotes.Location = new Point(7, 48);
            lstNotes.Name = "lstNotes";
            lstNotes.Size = new Size(202, 304);
            lstNotes.TabIndex = 1;
            // 
            // lblNoteTitle
            // 
            lblNoteTitle.AutoSize = true;
            lblNoteTitle.Location = new Point(259, 27);
            lblNoteTitle.Name = "lblNoteTitle";
            lblNoteTitle.Size = new Size(59, 15);
            lblNoteTitle.TabIndex = 2;
            lblNoteTitle.Text = "Название";
            lblNoteTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblNoteTitle.DataContextChanged += lstNotes_SelectedIndexChanged;
            // 
            // lblNoteCategory
            // 
            lblNoteCategory.AutoSize = true;
            lblNoteCategory.Location = new Point(259, 42);
            lblNoteCategory.Name = "lblNoteCategory";
            lblNoteCategory.Size = new Size(63, 15);
            lblNoteCategory.TabIndex = 3;
            lblNoteCategory.Text = "Категория";
            lblNoteCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNoteDates
            // 
            lblNoteDates.AutoSize = true;
            lblNoteDates.Location = new Point(259, 57);
            lblNoteDates.Name = "lblNoteDates";
            lblNoteDates.Size = new Size(129, 15);
            lblNoteDates.TabIndex = 4;
            lblNoteDates.Text = "Добавлено/Изменено";
            // 
            // txtNoteText
            // 
            txtNoteText.Location = new Point(259, 75);
            txtNoteText.Multiline = true;
            txtNoteText.Name = "txtNoteText";
            txtNoteText.PlaceholderText = "Текст заметки";
            txtNoteText.Size = new Size(516, 363);
            txtNoteText.TabIndex = 5;
            // 
            // btnAddNote
            // 
            btnAddNote.Location = new Point(7, 358);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(200, 23);
            btnAddNote.TabIndex = 6;
            btnAddNote.Text = "Добавить заметку";
            btnAddNote.UseVisualStyleBackColor = true;
            btnAddNote.Click += btnAddNote_Click;
            // 
            // btnEditNote
            // 
            btnEditNote.Location = new Point(7, 387);
            btnEditNote.Name = "btnEditNote";
            btnEditNote.Size = new Size(200, 23);
            btnEditNote.TabIndex = 7;
            btnEditNote.Text = "Редактировать заметку";
            btnEditNote.UseVisualStyleBackColor = true;
            btnEditNote.Click += btnEditNote_Click;
            // 
            // btnDeleteNote
            // 
            btnDeleteNote.Location = new Point(7, 415);
            btnDeleteNote.Name = "btnDeleteNote";
            btnDeleteNote.Size = new Size(200, 23);
            btnDeleteNote.TabIndex = 8;
            btnDeleteNote.Text = "Удалить заметку";
            btnDeleteNote.UseVisualStyleBackColor = true;
            btnDeleteNote.Click += btnDeleteNote_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteNote);
            Controls.Add(btnEditNote);
            Controls.Add(btnAddNote);
            Controls.Add(txtNoteText);
            Controls.Add(lblNoteDates);
            Controls.Add(lblNoteCategory);
            Controls.Add(lblNoteTitle);
            Controls.Add(lstNotes);
            Controls.Add(cmbCategories);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategories;
        private ListBox lstNotes;
        private Label lblNoteTitle;
        private Label lblNoteCategory;
        private Label lblNoteDates;
        private TextBox txtNoteText;
        private Button btnAddNote;
        private Button btnEditNote;
        private Button btnDeleteNote;
    }
}
