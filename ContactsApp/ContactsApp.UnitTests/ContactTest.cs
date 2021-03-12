using System;

using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {

        [TestCase("", "An exception should be thrown if the surname is an empty string",
            TestName = "Assigning an empty string as a surname")]
        [TestCase("Smith-Smith-Smith-Smith-Smith-Smith-Smith-Smith-Smith-Smith", "There should be " +
                "exception if the surname is longer than 50 letters",
            TestName = "Assigning an incorrect surname more than 50 characters")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            //SetApp
            var contact = new Contact();
            
            //Assert
            Assert.Throws<ArgumentException>(
                () => { contact.Surname = wrongSurname; },
                message);
        }

        
        [TestCase(TestName = "Assigning the correct surname")]
        public void  Surname_CorrectValue_SetSameValue()
        {
            //SetUp
            var contact = new Contact();
            var expected = "Smith";
            contact.Surname = expected;
           
            //Testing
            var actual = contact.Surname;
            
            //Assert
            Assert.AreEqual(expected, actual, "The values are the same");
        }
        

        [TestCase(TestName = "Surname getter positive test")]
        public void Surname_CorrectValue_ReturnsSameValue()
        {
            //SetUp
            var expected = "Smith";
            var number = new PhoneNumber();
            number.Number = "79992223322";
            var contact = new Contact("Smith","John", number,
                new DateTime(2000,01,01),"fakemail@fake.com","id121212");
            
            //Testing
            var actual = contact.Surname;
            
            //Assert
            Assert.AreEqual(expected, actual, "Getter Surname returns wrong surname");
        }


        [TestCase("", "An exception should be thrown if name is an empty string",
            TestName = "Assigning empty string as a name")]
        [TestCase("Smith-Smith-Smith-Smith-Smith-Smith-Smith-Smith-Smith-Smith",
            "There should be exception if the name is longer than 50 letters",
            TestName = "Assigning an incorrect name more than 50 characters")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            //SetUp
            var contact = new Contact();
           
            //Assert
            Assert.Throws<ArgumentException>(
                () => { contact.Name = wrongName; },
                message);
        }


        [TestCase("Smith",
            TestName = "Assigning the correct name")]
        public void Name_CorrectValue_SetSameValue(string expected)
        {
            //SetUp
            var contact = new Contact();
            contact.Name = expected;
            
            //Testing
            var actual = contact.Name;
            
            //Assert
            Assert.AreEqual(expected, actual, "The values are the same");
        }


        [TestCase(TestName = "Name getter positive test")]
        public void Name_CorrectValue_ReturnsSameValue()
        {
            //SetUp
            var expected = "John";
            var number = new PhoneNumber();
            number.Number = "79992223322";
            var contact = new Contact("Smith", "John", number,
                new DateTime(2000, 01, 01), "fakemail@fake.com", "id121212");
           
            //Testing
            var actual = contact.Name;

            //Assert
            Assert.AreEqual(expected, actual, "Getter Name returns wrong surname");
        }


        [TestCase("1899.12.31", "An exception should be thrown if " +
                                "the Birthday is earlier than 01/01/1900",
            TestName = "Assigning Birthday earlier than 01/01/1900")]
        [TestCase("2048.12.12",
            "An exception should be thrown if Birthday later today",
            TestName = "Assigning Birthday later today")]
        public void TestBirthdaySet_ArgumentException(DateTime wrongBirthday, string message)
        {
            //SetUp
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { contact.Birthday = wrongBirthday; },
                message);
        }


        [TestCase("2000.01.01",
            TestName = "Assigning the correct Birthday")]
        public void Birthday_CorrectValue_SetSameValue(DateTime expected)
        {
            //SetUp
            var contact = new Contact();
            contact.Birthday = expected;
            
            //Testing
            var actual = contact.Birthday;

            //Assert
            Assert.AreEqual(expected, actual, "The values are the same");
        }

        [TestCase(TestName = "Birthday getter positive test")]
        public void Birthday_CorrectValue_ReturnsSameValue()
        {
            //SetUp
            var expected = new DateTime(2000,01,01);
            var number = new PhoneNumber();
            number.Number = "79992223322";
            var contact = new Contact("Smith", "John", number,
                expected, "fakemail@fake.com", "id121212");
           
            //Testing
            var actual = contact.Birthday;

            //Assert
            Assert.AreEqual(expected, actual, "Getter Birthday returns wrong surname");
        }

        [TestCase("", "An exception should be thrown if the IdVk " +
                      "is an empty string",
            TestName = "Assigning an empty string as a IdVk")]
        [TestCase("fakemailfakemailfakemailfakemailfakemailfakemailfakemailfakemail",
            "There should be exception if the IdVK is longer than 50 letters",
            TestName = "Assigning an incorrect IdVK more than 50 characters")]
        public void TestIdVklSet_ArgumentException(string wrongIdVk, string message)
        {
            //SetUp
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { contact.IdVk = wrongIdVk; },
                message);
        }

        [TestCase("id121212",
            TestName = "Assigning the correct email")]
        public void IdVk_CorrectValue_SetSameValue(string expected)
        {
            //SetUp
            var contact = new Contact();
            contact.IdVk = expected;

            //Testing
            var actual = contact.IdVk;

            //Assert
            Assert.AreEqual(expected, actual, "The values are the same");
        }

        [TestCase(TestName = "IdVk getter positive test")]
        public void IdVk_CorrectValue_ReturnsSameValue()
        {
            //SetUp
            var expected = "id121212";
            var number = new PhoneNumber();
            number.Number = "79992223322";
            var contact = new Contact("Smith", "John", number,
                new DateTime(2000, 01, 01), "fakemail@mail.ru",
                expected);

            //Testing
            var actual = contact.IdVk;

            //Assert
            Assert.AreEqual(expected, actual, "Getter Birthday returns wrong surname");
        }

        [TestCase("", "An exception should be thrown if the email " +
                      "is an empty string",
            TestName = "Assigning an empty string as a email")]
        [TestCase("fakemailfakemailfakemailfakemailfakemailfakemailfakemailfakemail",
            "There should be exception if the email is longer than 50 letters",
            TestName = "Assigning an incorrect email more than 50 characters")]
        public void TestEmailSet_ArgumentException(string wrongEmail, string message)
        {
            //SetUp
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { contact.Email = wrongEmail; },
                message);
        }

        [TestCase("email@mail.ru",
            TestName = "Assigning the correct email")]
        public void Email_CorrectValue_SetSameValue(string expected)
        {
            //SetUp
            var contact = new Contact();
            contact.Email = expected;

            //Testing
            var actual = contact.Email;

            //Assert
            Assert.AreEqual(expected, actual, "The values are the not same same");
        }

        [TestCase(TestName = "Email getter positive test")]
        public void Email_CorrectValue_ReturnsSameValue()
        {
            //SetUp
            var expected = "fakemail@mail.ru";
            var number = new PhoneNumber();
            number.Number = "79992223322";
            var contact = new Contact("Smith", "John", number,
                new DateTime(2000, 01, 01), expected, "id121212");

            //Testing
            var actual = contact.Email;

            //Assert
            Assert.AreEqual(expected, actual, "Getter Birthday returns wrong surname");
        }

        [TestCase(TestName = "Contact constructor positive test")]
        public void Contact_CorrectValue_Consctuctor()
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

            //Testing
            var actualSurname = contact.Surname;
            var actualName = contact.Name;
            var actualNumber = contact.PhoneNumber;
            var actualBirthday = contact.Birthday;
            var actualEmail = contact.Email;
            var actualIdVK = contact.IdVk;

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
