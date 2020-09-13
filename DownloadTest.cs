using Tests.Abstract;
using Xunit;

namespace Tests
{
    public class DownloadTest : BaseTest
    {
        [Fact]
        public void Can_download_file()
        {
            var startPage = MainPage.Open(GetBrowser());
            startPage.NavigateToContactButton();
            var contactPage = startPage.GoToContactWeb();
            var mediaPack = contactPage.GoToMediaPack();
            var downloadlogotypy = mediaPack.DownloadFile();

            downloadlogotypy.AssertFileisDownloaded();
        }
    }
}
