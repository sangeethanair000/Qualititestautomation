using Automation.Pages;
using Automation.StepDefinitions;
using System;
using TechTalk.SpecFlow;

namespace Automation.StepDefinitions
{
    [Binding]
    public class AddUpdateCartStepDefinitions : StepDefinitionBase
    {
        //public CartAddPage CartAddPage { get; set; }
        public readonly HomePage _homePage;
        public readonly CartPage _cartPage;

        public AddUpdateCartStepDefinitions()
        {
            _homePage = new HomePage(Driver);
            _homePage.NavigateToHome();

            _cartPage = new CartPage(Driver);
        }

        [Given(@"I add four random items to my cart")]
        public void GivenIAddFourRandomItemsToMyCart()
        {
            _homePage.AddItemsToCart();
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            _homePage.GotoCart();
        }

        [Then(@"I find total four items listed in my cart")]
        public void ThenIFindTotalFourItemsListedInMyCart()
        {
            _cartPage.ConfirmElementsCount(4);
        }

        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
            _cartPage.FindLowestPricedItem();
        }

        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            _cartPage.RemoveLowestPricedItem();
        }

        [Then(@"I am able to verify three in my cart")]
        public void ThenIAmAbleToVerifyThreeInMyCart()
        {
            _cartPage.ConfirmElementsCount(3);
        }
    }
}
