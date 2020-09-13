using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Tests.Pages.Abstract;
using Xunit;

namespace Tests.Pages
{
    internal class ResultPage : BasePage
    {
        public ResultPage(IWebDriver browser) : base(browser)
        {

        }

        public bool IsVisible()
        {
            IReadOnlyCollection<IWebElement> items = browser.FindElements(By.XPath(".//*[@class='wpb_wrapper']//h1[contains(text(), 'Wyniki wyszukiwania')]"));
            return items.Count > 0 && items.First().Displayed;
        }

        internal ResultPage AssertConditions()
        {
            IReadOnlyCollection<IWebElement> collectionOfResults = browser.FindElements(By.CssSelector(".latest_post_custom"));
            int numberOfResults = collectionOfResults.Count;
            Assert.Equal(10, numberOfResults);

            var moreThanOneResult = browser.FindElements(By.CssSelector(".text-title"));
            moreThanOneResult.Single(x => x.Text == "PocketECG CRS – telerehabilitacja kardiologiczna");

            return this;
        }
    }
}
