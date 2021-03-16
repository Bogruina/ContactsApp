using System;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;


namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        /// <summary>
        /// Поле хранит путь на корректный файл для тестов
        /// </summary>
        private const string CorrectProjectFilename = @"TestData\correctcontactsdata.json";
        /// <summary>
        /// Поле хранит путь на поврежденный файл
        /// </summary>
        private const string UncorrectProjectFilename = @"TestData\uncorrectcontactsdata.json";
        /// <summary>
        /// Поле хранит путь на файл для деста сериализации
        /// </summary>
        private const string OutputSaveFilename = @"Output\opaopa.json";


        [TestCase(TestName = "Positive test deserialize")]
        public void ProjectMamager_SaveCorrectionData_FileSavedCorrectly()
        {
            //SetUp
            var expectedProject = new Project();
            var number = new PhoneNumber();
            number.Number = "79236014455";
            var contact = new Contact("Surname", "Name", number, 
                new DateTime(2000, 12, 12), "email@mail.ru",  "id12121221");
            expectedProject.Contacts.Add(contact);
           
            number = new PhoneNumber();
            number.Number = "79236078844";
            contact = new Contact("Surnam2", "Name2", number, 
                new DateTime(2000, 12, 12), "gmail@gmail.com",  "id53432342");
            expectedProject.Contacts.Add(contact);

            //Testing
            var actualProject = ProjectManager.LoadFromFile(CorrectProjectFilename);

            //Assert
            Assert.AreEqual(expectedProject.Contacts.Count, actualProject.Contacts.Count);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expectedProject.Contacts.Count; i++)
                {
                    var expected = expectedProject.Contacts[i];
                    var actual = actualProject.Contacts[i];

                    Assert.AreEqual(expected,actual);
                }
            });
        }

        [TestCase(TestName = "Negative test deserialize, uncorrent file ")]
        public void ProjectMamager_SaveUncorrectFIle_RetursEmptyFile()
        {
            //SetUp
            var excpectedProject = new Project();

            //Testing
            var actualProject = ProjectManager.LoadFromFile(UncorrectProjectFilename);

            //Assert
            Assert.AreEqual(excpectedProject.Contacts.Count, actualProject.Contacts.Count);
            
        }

        [TestCase(TestName = "Negative test deserialize, non-existent file ")]
        public void ProjectMamager_SaveNonExistentFIle_RetursEmptyFile()
        {
            var expectedProject = new Project();

            var location = Assembly.GetExecutingAssembly().Location;
            var folder = Path.GetDirectoryName(location);

            //Testing
            var actualProject = ProjectManager.LoadFromFile($@"{folder}\TestData\opaopa.json");

            //Assert
            Assert.AreEqual(expectedProject.Contacts.Count, actualProject.Contacts.Count);

        }

        [TestCase(TestName = "Positive test serialize")]
        public void ProjectMamager_LoadCorrectionData_FileLoadedCorrectly()
        {
            //SetUp
            var expectedProject = new Project();
            var number = new PhoneNumber();
            number.Number = "79236014455";
            var contact = new Contact("Surname", "Name", number,
                new DateTime(2000, 12, 12), "email@mail.ru", "id12121221");
            expectedProject.Contacts.Add(contact);

            number = new PhoneNumber();
            number.Number = "79236078844";
            contact = new Contact("Surnam2", "Name2", number,
                new DateTime(2000, 12, 12), "gmail@gmail.com", "id53432342");
            expectedProject.Contacts.Add(contact);

            //Testing
            ProjectManager.SaveToFile(expectedProject, OutputSaveFilename);

            //Assert
            var actual = File.ReadAllText(OutputSaveFilename);
            var expected = File.ReadAllText(CorrectProjectFilename);
            Assert.AreEqual(expected,actual);

        }





    }
}
