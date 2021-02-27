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
    public static class Manager
    {
        private const string FilePath = @"C:\ContactsApp\ContactsApp.json";

        /// <summary>
        /// Метод сериализации
        /// </summary>
        /// <param name="data">Принимает список контактов</param>
        public static void SaveToFile(List<Contact> data)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(FilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Formatting = Formatting.Indented;
                for (int i = 0; i < data.Count; i++)
                {

                    serializer.Serialize(writer, data[i]);
                }

            }


        }

        /// <summary>
        /// Метод десериализации
        /// </summary>
        /// <returns></returns>
        public static Contact LoadFromFile()
        {



            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
            };

            
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(FilePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                
                Contact contact = (Contact)serializer.Deserialize(reader,typeof(Contact));
                
                return contact;

            }
          

            //Contact contact;
            //contact = JsonConvert.DeserializeObject<Contact>(serializer, settings);
            //Audio audio = newList.list[0] as Audio; // != null
        }
    }
}

