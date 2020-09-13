using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Tests.Pages.Abstract;
using Xunit;

namespace Tests.Pages
{
    internal class MediaPage : BasePage
    {
        public MediaPage(IWebDriver browser) : base(browser)
        {
        }

        public bool IsVisible()
        {
            IReadOnlyCollection<IWebElement> items = browser.FindElements(By.CssSelector(".vc_row wpb_row section vc_row-fluid  section-banner grid_section animated"));
            return items.Count > 0 && items.First().Displayed;
        }
        internal MediaPage DownloadFile()
        {
            WaitForClickable(By.XPath("//strong[contains(text(),'Logotypy')]"), 5);
            browser.FindElement(By.XPath("//strong[contains(text(),'Logotypy')]")).Click();

            return this;
        }

        public MediaPage AssertFileisDownloaded()
        {
            string expectedFilePath = @"C:\Downloads\logotypy.zip";

            Thread.Sleep(8000);
            FileInfo fileInfo = new FileInfo(expectedFilePath);
            Assert.Equal(fileInfo.Name, "logotypy.zip");
            Assert.Equal(fileInfo.FullName, @"C:\Downloads\logotypy.zip");

            return this;
        }
    }
}
