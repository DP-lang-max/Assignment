using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NLog;

namespace TechnicalTAsk.Pages
{
    public class DragAndDropPage
    {
        private IWebDriver driver;
        private By orderTicket = By.Id("plate-items");
        private string menuItemXPath = "//li[@draggable='true' and text()='{0}']";
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // Constructor to initialize the WebDriver instance
        public DragAndDropPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Method to perform drag and drop action for a given menu item
        public void PerformDragAndDrop(string menuItem)
        {
            logger.Info($"Performing drag and drop for item: {menuItem}");
            var sourceElement = driver.FindElement(By.XPath(string.Format(menuItemXPath, menuItem)));
            var targetElement = driver.FindElement(orderTicket);

            try
            {
                Actions actions = new Actions(driver);
                actions.DragAndDrop(sourceElement, targetElement).Perform();
                logger.Info("Drag and drop action performed successfully");
            }
            catch (Exception ex)
            {
                logger.Error($"Drag and drop action failed: {ex.Message}. Attempting with JavaScript.");
                ExecuteJavaScriptDragAndDrop(sourceElement, targetElement);
            }
            // Assert that the border color is as expected
            var borderColor = targetElement.GetCssValue("border");
            if (borderColor.Contains("rgb(0, 162, 152)"))
            {
                logger.Info("Border color is correct after drag and drop");
            }
            else
            {
                logger.Error("Border color is incorrect after drag and drop");
                throw new Exception("Border color is incorrect after drag and drop");
            }
        }

        // Method to verify if the given menu item is present in the order ticket
        public bool VerifyDroppedItem(string menuItem)
        {
            logger.Info($"Verifying if item '{menuItem}' is in the Order Ticket");
            var droppedItems = driver.FindElements(By.XPath("//ul[@id='plate-items']/li"));
            foreach (var item in droppedItems)
            {
                if (item.Text.Trim().Equals(menuItem, System.StringComparison.OrdinalIgnoreCase))
                {
                    logger.Info($"Item '{menuItem}' successfully found in the Order Ticket");
                    return true;
                }
            }
            logger.Warn($"Item '{menuItem}' was NOT found in the Order Ticket");
            return false;
        }

        // Method to perform drag and drop using JavaScript
        private void ExecuteJavaScriptDragAndDrop(IWebElement source, IWebElement destination)
        {
            var script = @"
                function simulateDragDrop(sourceNode, destinationNode) {
                    var dataTransfer = new DataTransfer();

                    var dragStartEvent = new DragEvent('dragstart', {
                        bubbles: true,
                        cancelable: true,
                        dataTransfer: dataTransfer
                    });
                    sourceNode.dispatchEvent(dragStartEvent);

                    var dragOverEvent = new DragEvent('dragover', {
                        bubbles: true,
                        cancelable: true,
                        dataTransfer: dataTransfer
                    });
                    destinationNode.dispatchEvent(dragOverEvent);

                    var dropEvent = new DragEvent('drop', {
                        bubbles: true,
                        cancelable: true,
                        dataTransfer: dataTransfer
                    });
                    destinationNode.dispatchEvent(dropEvent);

                    var dragEndEvent = new DragEvent('dragend', {
                        bubbles: true,
                        cancelable: true,
                        dataTransfer: dataTransfer
                    });
                    sourceNode.dispatchEvent(dragEndEvent);
                }

                simulateDragDrop(arguments[0], arguments[1]);
            ";

            ((IJavaScriptExecutor)driver).ExecuteScript(script, source, destination);
            logger.Info("Drag and drop action performed successfully using JavaScript");
        }
    }
}

