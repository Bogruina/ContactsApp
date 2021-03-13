using System;
using System.Text;
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
        /// Поле хранит текущую кодировку для сериализации и десериализации
        /// </summary>
        private const string CurrentEncoding = "Windows-1251";
       
        /// <summary>
        /// Свойство позволяет получить путь к файлу
        /// /***/AppData/Roaming/ContactsApp/contacts.json
        /// </summary>
        public static string DefaultPath
        {
            get
            {
                var appDataFolder =
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var path = appDataFolder + @"\ContactsApp";
                return path;
            }
        }

        public static string DefaultFilePath
        {
            get
            {
                var filePath = DefaultPath + @"\contacts.json";
                return filePath;
            }
        }



        /// <summary>
        /// Метод сериализации
        /// </summary>
        /// <param name="project">список контактов</param>
        /// <param name="filename">название файла, в который будет
        /// производиться сериализация</param>
        public static void SaveToFile(Project project,string dirPath , string filePath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            if (!File.Exists((filePath)))
            {
                File.Create(filePath);
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(filePath, false,
                Encoding.GetEncoding(CurrentEncoding)))
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
                Project emptyProject = new Project();
                return emptyProject;

            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(filename, 
                Encoding.GetEncoding(CurrentEncoding)))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                var project = serializer.Deserialize<Project>(reader);

                if (project == null)
                {
                    Project emptyProject = new Project();
                    return emptyProject;
                }

                return project;
            }
            
        }
    }
}

