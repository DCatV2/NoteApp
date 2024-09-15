namespace NoteApp
{
    public class NoteCategory
    {
        public string Name { get; set; } // Имя категории

        // Конструктор для задания названия категории
        public NoteCategory(string name)
        {
            Name = name;
        }

        // Переопределяем метод ToString для удобного отображения категории
        public override string ToString()
        {
            return Name;
        }

        // Статические предустановленные категории
        public static NoteCategory Work { get; } = new NoteCategory("Работа");
        public static NoteCategory Home { get; } = new NoteCategory("Дом");
        public static NoteCategory Finance { get; } = new NoteCategory("Финансы");
        public static NoteCategory HealthAndSport { get; } = new NoteCategory("Здоровье и спорт");
        public static NoteCategory People { get; } = new NoteCategory("Люди");
        public static NoteCategory Documents { get; } = new NoteCategory("Документы");
        public static NoteCategory Other { get; } = new NoteCategory("Прочее");
    }
}
