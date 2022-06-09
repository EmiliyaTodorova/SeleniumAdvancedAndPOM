using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver_POM_Example.Pages;
using System;
using System.Linq;

namespace SeleniumWebDriver_POM_Example.Tests
{
    public class AddStudentTests : BaseTests
    {
      
        [Test]
        public void Test_AddStudentPage_Url_Heading_Title()
        {
            var addStudent_page = new AddStudentsPage(driver);
            addStudent_page.Open();
            Assert.That(driver.Url, Is.EqualTo(addStudent_page.GetPageUrl()));
            Assert.That("Register New Student", Is.EqualTo(addStudent_page.GetPageHeading()));
            Assert.That(addStudent_page.GetPageTitle, Is.EqualTo("Add Student"));
        }
        [Test]
        public void Test_HomePage_HomeLinks()
        {
            var addStudent_page = new AddStudentsPage(driver);
            addStudent_page.Open();
            addStudent_page.HomeLink.Click();
            Assert.That(addStudent_page.GetPageTitle(), Is.EqualTo("MVC Example"));
        }
        [Test]
        public void Test_AddStudentPage_EmptyFields()
        {
            var add_Student = new AddStudentsPage(driver);
            add_Student.Open();
            Assert.That(add_Student.EmailName.Text, Is.EqualTo(""));
        }
        [Test]
       public void Test_AddStudentPage_AddValidStudent()
        {
            var add_student = new AddStudentsPage(driver);
            add_student.Open();
            string name = "Emi" + DateTime.Now.Ticks;
            string email = "Emi" + DateTime.Now.Ticks + "@gmaila.com";
            add_student.AddStudent(name, email);
            var view_student = new ViewStudentsPage(driver);
            Assert.That(view_student.isOpen);
            var students = view_student.GetRegisteredStudents();
            var lastStudent = students.Last();
            string expectedStudent = name + "(" + email +")";
            Assert.Contains(lastStudent, students);
        }
        [Test]
        public void Test_AddStudentsPage_AddInvalidStudent()
        {
            var add_student = new AddStudentsPage(driver);
            add_student.Open();
            string name = "";
            string email = "";
            add_student.AddStudent(name, email);
            Assert.IsTrue(add_student.isOpen());
            Assert.That(add_student.ErrorMessage.Text, Is.EqualTo("Cannot add student. Name and email fields are required!"));
        }
    }
}
