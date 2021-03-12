using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectTest
    {
        [TestCase(TestName = "Project getter positive test")]
        public void Project__CorrectValue_ReturnsSameValue()
        {
            //SetUp
            var expectedSurname = "Smith";
            var expectedName = "Jonh";
            var number = new PhoneNumber();
            number.Number = "79992223322";
            var expectedNumber = number;
            var expectedBirthday = new DateTime(2000, 01, 01);
            var expectedEmail = "fakemail@mail.com";
            var expectedIdVk = "id121212";
            var contact = new Contact(expectedSurname, expectedName,
                expectedNumber, expectedBirthday, expectedEmail, expectedIdVk);
            var contacts = new Project();

            //Testing
            contacts.Contacts.Add(contact);
            var actualSurname = contacts.Contacts[0].Surname;
            var actualName = contacts.Contacts[0].Name;
            var actualNumber = contacts.Contacts[0].PhoneNumber;
            var actualBirthday = contacts.Contacts[0].Birthday;
            var actualEmail = contacts.Contacts[0].Email;
            var actualIdVK = contacts.Contacts[0].IdVk;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname, "The surnames do not match");
                Assert.AreEqual(expectedName, actualName, "The names do not match");
                Assert.AreEqual(expectedNumber, actualNumber, "The numbers do not match");
                Assert.AreEqual(expectedBirthday, actualBirthday, "The birthdays do not match");
                Assert.AreEqual(expectedEmail, actualEmail, "The emails do not match");
                Assert.AreEqual(expectedIdVk, actualIdVK, "The Idvk do not match");
            });
        }
    }
}
