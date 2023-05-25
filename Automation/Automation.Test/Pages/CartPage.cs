using NUnit.Framework;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void ConfirmElementsCount(int count)
        {
            var shopTable = Driver.FindElement(By.ClassName("shop_table"));
            var cartItems = shopTable
                .FindElement(By.TagName("tbody"))
                .FindElements(By.ClassName("cart_item"));
            Assert.That(cartItems.Count(), Is.EqualTo(count));
        }

        public void FindLowestPricedItem()
        {
            var item = GetLowestPricedItem();

            Assert.IsNotNull(item);
        }

        public void RemoveLowestPricedItem()
        {
            var item = GetLowestPricedItem();

            item
                .FindElement(By.ClassName("product-remove"))
                .FindElement(By.TagName("a"))
                .Click();

            Thread.Sleep(3000);
        }


        private WebElement GetLowestPricedItem()
        {
            var shopTable = Driver.FindElement(By.ClassName("shop_table"));
            var cartItems = shopTable.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));

            decimal lowestItemPrice = decimal.MaxValue;
            WebElement lowestPricedItem = default!;

            foreach (var cartItem in cartItems)
            {

                var price = cartItem
                .FindElement(By.XPath("//*[@data-title='Price']"))
                .FindElement(By.ClassName("amount"))
                .Text;

                var currentItemPrice = Convert.ToDecimal(price.Substring(1));

                if (currentItemPrice < lowestItemPrice)
                {
                    lowestItemPrice = currentItemPrice;
                    lowestPricedItem = (WebElement)cartItem;
                }
            }

            return lowestPricedItem;
        }
    }
}