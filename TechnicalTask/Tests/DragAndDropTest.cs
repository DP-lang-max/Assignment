using TechnicalTAsk.Pages;
using TechnicalTAsk;

namespace TechnicalTask.Tests
{
    public class DragAndDropTest : TestBase
    {
        [Test]
        [TestCase("Fried Chicken")]
        [TestCase("Hamburger")]
        [TestCase("Ice Cream")]
        public void TestDragAndDrop(string menuItem)
        {
            // Navigate to the Kitchen Applitools page
            NavigateToKitchenApplitools();

            // Initialize the Kitchen page object
            var theKitchenPage = new TheKitchenPage(driver);

            // Navigate to the Drag and Drop section
            theKitchenPage.NavigateToDragAndDrop();

            // Initialize the Drag and Drop page object
            var dragAndDropPage = new DragAndDropPage(driver);

            // Perform the drag and drop action for the specified menu item
            dragAndDropPage.PerformDragAndDrop(menuItem);

            // Verify that the item was dropped correctly
            Assert.That(dragAndDropPage.VerifyDroppedItem(menuItem), Is.True, $"The item {menuItem} was not dropped correctly.");
        }
    }
}
