using System;
using NUnit.Framework;
using System.IO;


namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        private const string _validDataPath = "..\\..\\..\\source\\repos\\ContactsApp\\ContactsApp\\ContactsApp.UnitTests\\TestData\\ValidData.json";
        private const string _outputDataPath = "..\\..\\..\\source\\repos\\ContactsApp\\ContactsApp\\ContactsApp.UnitTests\\TestData\\OutputData.json";
        
        [TestCase(TestName = "Positive test save to file")]
        public void SaveToFile_ResultCorrectValue()
        {
            //SetUp
            var project = new Project();
            var number = new PhoneNumber();
            number.Number = "79964156633";
            var contact = new Contact("Быков", "Сергей", number,
                new DateTime(2000, 12, 12), "fakemail@gmail.com",
                "id121212");
            project.Contacts.Add(contact);
            var expected = File.ReadAllText(_validDataPath);

            //Testing
            ProjectManager.SaveToFile(project, (_outputDataPath));
            var actual = File.ReadAllText((_outputDataPath));

            //Assest
            Assert.AreEqual(expected, actual);


        }
    }
}
