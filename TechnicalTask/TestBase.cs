using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using NLog;

namespace TechnicalTAsk
{
    public class TestBase : IDisposable
    {
        // WebDriver instance to control the browser
        protected IWebDriver driver;

        // WebDriverWait instance for explicit waits
        protected WebDriverWait wait;

        // Logger instance for logging information
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // Setup method to initialize WebDriver and other settings before each test
        [SetUp]
        public void Setup()
        {
            logger.Info("Setting up WebDriver");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Teardown method to clean up after each test
        [TearDown]
        public void Teardown()
        {
            Dispose();
        }

        // Dispose method to close and dispose WebDriver instance
        public void Dispose()
        {
            if (driver != null)
            {
                logger.Info("Closing WebDriver");
                driver.Quit();
                driver.Dispose();
            }
        }

        // Method to navigate to the Kitchen Applitools website
        public void NavigateToKitchenApplitools()
        {
            logger.Info("Navigating to Kitchen Applitools");
            driver.Navigate().GoToUrl("https://kitchen.applitools.com/");
        }
    }
}
