using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Selenium_Git
{
    [TestClass]
    public class Selenium_Setting
    {
        private IWebDriver FirefoxDriver;
        private IWebDriver ChromeDriver;
        private IWebDriver IEDriver;
        public IWebDriver EdgeDriver;
        private string serverPath = "Microsoft Web Driver";

        [TestInitialize()]
        public void TestInitialize()
        {
            // New up the driver to boot up a new browser for each test
            //ChromeDriver = new ChromeDriver();

            // This will maximize your window to 100%
            //ChromeDriver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void FirefoxDriverTest()
        {
            FirefoxDriver = new FirefoxDriver();

            FirefoxDriver.Navigate().GoToUrl("http://bing.com/");
            FirefoxDriver.Manage().Window.Maximize();

            IWebElement searchInput = FirefoxDriver.FindElement(By.Id("sb_form_q"));
            searchInput.SendKeys("HelloWorld");
            searchInput.SendKeys(Keys.Enter);

            FirefoxDriver.Close();
        }

        [TestMethod]
        public void ChromeDriverTest()
        {
            ChromeDriver = new ChromeDriver();

            ChromeDriver.Navigate().GoToUrl("http://bing.com/");
            ChromeDriver.Manage().Window.Maximize();

            IWebElement searchInput = ChromeDriver.FindElement(By.Id("sb_form_q"));
            searchInput.SendKeys("HelloWorld");
            searchInput.SendKeys(Keys.Enter);

            ChromeDriver.Close();
        }

        [TestMethod]
        public void IEDirverTest()
        {
            var options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            IEDriver = new InternetExplorerDriver(options);

            IEDriver.Navigate().GoToUrl("http://bing.com/");
            IEDriver.Manage().Window.Maximize();

            IWebElement searchInput = IEDriver.FindElement(By.Id("sb_form_q"));
            searchInput.SendKeys("HelloWorld");
            searchInput.SendKeys(Keys.Enter);

            IEDriver.Close();
        }




        [TestMethod]
        public void EdgeDriverTest()
        {
            if (System.Environment.Is64BitOperatingSystem)
            {
                serverPath = Path.Combine(System.Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%"), serverPath);
            }
            else
            {
                serverPath = Path.Combine(System.Environment.ExpandEnvironmentVariables("%ProgramFiles%"), serverPath);
            }

            EdgeOptions options = new EdgeOptions();
            options.PageLoadStrategy = EdgePageLoadStrategy.Eager;

            EdgeDriver = new EdgeDriver(serverPath, options);

            EdgeDriver.Navigate().GoToUrl("http://bing.com/");
            EdgeDriver.Manage().Window.Maximize();

            IWebElement searchInput = EdgeDriver.FindElement(By.Id("sb_form_q"));
            searchInput.SendKeys("HelloWorld");
            searchInput.SendKeys(Keys.Enter);

            EdgeDriver.Close();
        }

        [TestCleanup]
        void TestCleanup()
        {

        }
    }
}
