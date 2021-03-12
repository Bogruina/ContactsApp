using System;
using NUnit.Framework;
using System.IO;


namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        private string _pathDirectory = Environment.CurrentDirectory;
        private const string _validDataPath =  @"\TestData\ValidData.json";
        private const string _outputDataPath = @"\TestData\OutputData.json";
        [TestCase(TestName = "asdasd")]
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
            var expected = File.ReadAllText(Environment.CurrentDirectory + _validDataPath);

            //Testing
            ProjectManager.SaveToFile(project, (Environment.CurrentDirectory + _outputDataPath));
            var actual = File.ReadAllText((Environment.CurrentDirectory + _outputDataPath));

            //Assest
            Assert.AreEqual(expected, actual);


        }
    }
}
