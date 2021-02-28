using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using  System.IO;

namespace ContactsApp
{
    /// <summary>
    /// Класс позволяет сохранять в файл и извлекать из файла список контактов
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Свойство позволяет получить путь к файлу
        /// /***/AppData/Roaming/ContactsApp/contacts.json
        /// </summary>
        public static string DefaultFilename
        {
            get
            {
                var appDataFolder =
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var filename = appDataFolder + @"/ContactsApp/contacts.json";
                return filename;
            }
        }

        /// <summary>
        /// Метод сериализации
        /// </summary>
        /// <param name="project">список контактов</param>
        /// <param name="filename">название файла, в который будет
        /// производиться сериализация</param>
        public static void SaveToFile(Project project, string filename)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(filename, false,
                Encoding.GetEncoding("Windows-1251")))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, project);
                }
            }
        }

        /// <summary>
        /// Метод десериализации, включает проверки на существование файла 
        /// </summary>
        /// <param name="filename">название файла для десериализации</param>
        /// <returns></returns>
        public static Project LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new NullReferenceException("Файл не существует.");
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("Windows-1251")))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                var project = serializer.Deserialize<Project>(reader);
                if (project == null)
                {
                    Project emptyProject = null;
                    //return emptyProject;
                }
                
                return project;
            }
        }
    }
}

