using OpenQA.Selenium;
using Automation.Drivers;
using Automation;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace Automation.Pages
{
    /// <summary>
    /// This is a POM that represents the homepage.
    /// </summary>
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement cartitem1 => Driver.FindElement(By.XPath("//*[@data-product_id='54']"));
        private IWebElement cartitem2 => Driver.FindElement(By.XPath("//*[@data-product_id='26']"));
        private IWebElement cartitem3 => Driver.FindElement(By.XPath("//*[@data-product_id='27']"));
        private IWebElement cartitem4 => Driver.FindElement(By.XPath("//*[@data-product_id='25']"));

        public void NavigateToHome()
        {
            Driver.Navigate().GoToUrl(AppConfigReader.GetUrl);
        }

        public void AddItemsToCart()
        {
            cartitem1.Click();
            cartitem2.Click();
            cartitem3.Click();
            cartitem4.Click();
            Thread.Sleep(1000);
        }

        public void GotoCart()
        {
            var actions = new Actions(Driver);
            actions.SendKeys(Keys.Home).Build().Perform();
            Thread.Sleep(1000);
            Driver.FindElement(By.LinkText("CART")).Click();
            Assert.That(Driver.Url, Is.EqualTo("https://cms.demo.katalon.com/cart/"));
        }
    }
}
