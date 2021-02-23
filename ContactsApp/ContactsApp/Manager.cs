using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using  System.IO;

namespace ContactsApp
{
    public static class Manager
    {
        private const string FilePath = @"C:\ContactsApp\ContactsApp.json";

        public static void SaveToFile(Contact data)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(FilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                
                serializer.Serialize(writer, data);
            }
           

        }

        public static Contact LoadFromFile()
        {
            Contact contact = null;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(FilePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                contact = (Contact)serializer.Deserialize<Contact>(reader);
                return contact;
            }
        }
    }
}
