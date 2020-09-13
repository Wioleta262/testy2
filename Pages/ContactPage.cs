
using OpenQA.Selenium;
using System.Collections.Generic;
using Tests.Pages.Abstract;
using System.Linq;
using System.Threading;

namespace Tests.Pages
{
    class ContactPage : BasePage
    {
        public ContactPage(IWebDriver browser) : base(browser)
        {

        }

        public bool IsVisible()
        {
            IReadOnlyCollection<IWebElement> items = browser.FindElements(By.XPath(".//*[@class='wpb_wrapper']//h1[contains(text(), 'Siedziba główna')]"));
            return items.Count > 0 && items.First().Displayed;
        }

        internal MediaPage GoToMediaPack()
        {
            Thread.Sleep(5000);
            MoveToElement(browser.FindElement(By.XPath("//div[@class='wpb_wrapper']//a[contains(text(),'Media pack')]")));
            browser.FindElement(By.Id("cn-accept-cookie")).Click();
            WaitForClickable(By.XPath("//div[@class='wpb_wrapper']//a[contains(text(),'Media pack')]"), 5);
            browser.FindElement(By.XPath("//div[@class='wpb_text_column wpb_content_element  text-title']//a[contains(text(),'Media pack')]")).Click();
            return new MediaPage(browser);
        }
    }
}
