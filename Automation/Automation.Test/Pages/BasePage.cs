using OpenQA.Selenium;

namespace Automation.Pages
{
    /// <summary>
    /// This is the base for all Page Object Models.
    /// </summary>
    public class BasePage
    {
        protected IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
