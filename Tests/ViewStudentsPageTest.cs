using NUnit.Framework;
using SeleniumWebDriver_POM_Example.Pages;

namespace SeleniumWebDriver_POM_Example.Tests
{
    public class ViewStudentsPageTest: BaseTests
    {
        [Test]
        public void Test_ViewStudentPage_TitleAndHeading()
        {
            var students_page = new ViewStudentsPage(driver);
            students_page.Open();
            Assert.That(students_page.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(students_page.GetPageHeadingTexts(), Is.EqualTo("Registered Students"));
        }

    }
}
