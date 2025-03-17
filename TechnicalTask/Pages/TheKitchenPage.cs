using OpenQA.Selenium;

namespace TechnicalTAsk.Pages
{
    public class TheKitchenPage
    {
        private readonly IWebDriver _driver;

        // Constructor to initialize the WebDriver
        public TheKitchenPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Method to navigate to the Drag and Drop page
        public void NavigateToDragAndDrop()
        {
            _driver.FindElement(By.CssSelector("a[href='/ingredients/drag-and-drop']")).Click();
        }
    }
}
