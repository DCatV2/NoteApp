using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    ///<summary>
    ///Класс для сохранения и загрузки проекта
    /// </summary>
    public static class ProjectManager
    {
        private const string FilePath = @"C:\Users\Public\Documents\NoteApp.notes";

        public static void SaveToFile(Project project)
        {
            var json = JsonConvert.SerializeObject(project, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static Project LoadFromFile()
        {
            if (!File.Exists(FilePath))
                return new Project();

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<Project>(json);
        }
    }
}

               
  