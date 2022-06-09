using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver_POM_Example.Tests
{
    public class BaseTests
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
