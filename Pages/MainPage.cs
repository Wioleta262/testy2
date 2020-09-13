using Tests.Pages.Abstract;
using OpenQA.Selenium;
using Tests.Pages;
using System.Threading;
using Xunit;

namespace Tests
{

    internal class MainPage : BasePage
    {
        private const string MAIN_PAGE_BASE_URL = "https://www.medicalgorithmics.pl/";

        private MainPage(IWebDriver browser) : base(browser)
        {
            browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
        }

        internal static MainPage Open(IWebDriver browser)
        {
            return new MainPage(browser);
        }

        public void scrollDown()
        {
            IJavaScriptExecutor js = browser as IJavaScriptExecutor;
            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0,950);");
        }

        public void scrollDownM()
        {
            IJavaScriptExecutor js = browser as IJavaScriptExecutor;
            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0,1050);");
        }

        public void scrollUp()
        {
            IJavaScriptExecutor js = browser as IJavaScriptExecutor;
            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0,-950);");
        }

        public void CheckMainPage()
        {
            scrollDown();
            browser.FindElement(By.XPath("//div[@class='wpb_wrapper']//h2[contains(text(),'Ostatnie aktualności')]"));
            scrollDown();
            browser.FindElement(By.XPath("//div[@class='wpb_wrapper']//h2[contains(text(),'Najnowsze oferty pracy')]"));
            scrollDownM();
            browser.FindElement(By.XPath("//div[@class='wpb_wrapper']//h2[contains(text(),'Newsroom')]"));
        }

        internal MainPage NavigateToContactButton()
        {

            WaitForClickable(By.Id("mega-menu-item-29"), 5);
            IWebElement Contact = browser.FindElement(By.Id("mega-menu-item-29"));
            string colorOne = Contact.GetCssValue(propertyName: "color");
            MoveToElement(By.Id("mega-menu-item-29"));
            WaitForClickable(By.Id("mega-menu-item-29"), 5);
            string colorTwo = Contact.GetCssValue(propertyName: "color");

            //Assert.True(colorOne != colorTwo);

            return this;
        }

        internal ContactPage GoToContactWeb()
        {
            IWebElement Contact = browser.FindElement(By.Id("mega-menu-item-29"));
            Contact.Click();

            return new ContactPage(browser);
        }

        internal ResultPage SearchResults(string searchedPhrase)
        {
            browser.FindElement(By.CssSelector(".icon_search ")).Click();
            browser.FindElement(By.CssSelector(".qode_search_field")).SendKeys(searchedPhrase);
            MoveToElement(By.CssSelector(".qode_search_submit"));
            WaitForClickable(By.CssSelector(".qode_search_submit")).Click();

            return new ResultPage(browser);
        }
    }
}