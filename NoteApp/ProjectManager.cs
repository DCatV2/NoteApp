using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoteApp
{
    public static class ProjectManager
    {
        public static void SaveProject(Project project, string filePath) // Метод сохраняет объект Project в файл, преобразуя его в строку в формате json
        {
            var json = JsonConvert.SerializeObject(project, Formatting.Indented); // преобразование и форматирование в удобный вид (с отступами)
            File.WriteAllText(filePath, json); // сохранение в файл по указанному пути
        }

        public static Project LoadProject (string filePath) // загружает объект из файла по указанному пути
        {
            if (!File.Exists(filePath)) // проверяет, есть ли файл по указанному пути
            {
                throw new FileNotFoundException("Файл не найден."); //если файл не найден, вызывается это исключение
            }

            var json = File.ReadAllText(filePath); // считывает содержимое файла
            return JsonConvert.DeserializeObject<Project>(json); //возвращает файл json в виде объекта Project
        }
    }
}
