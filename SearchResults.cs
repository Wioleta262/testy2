using Tests.Abstract;
using Xunit;

namespace Tests.Domain
{
    public class SearchResults : BaseTest
    {
        [Fact]
        public void Can_Search_Rezults()
        {
            var startPage = MainPage.Open(GetBrowser());
            startPage.CheckMainPage();
            var resultPage = startPage.SearchResults("Pocket ECG CRS");

            resultPage.AssertConditions();
        }
    }
}
