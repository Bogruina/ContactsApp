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
        private const string _filePath = @"C:\Users\aleks\OneDrive\Документы\ContactsApp";

        public static void SaveToFile(Contact data, string filename)
        {
            //JsonSerializer serializer = new JsonSerializer();
            //serializer.Serialize(filename,data);

        }

        public static Contact LoadFromFile(string filename)
        {

        }
    }
}
