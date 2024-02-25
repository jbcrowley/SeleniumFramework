using SeleniumFramework.Common;

namespace SeleniumFramework.Tests.TheInternet
{
    public class SampleTest : BaseTest
    {
        [Test]
        [Category("Sample")]
        public void SampleTestMethod()
        {
            // TestData contains data specific to this test
            string username = TestData["username"];

            // GlobalData contains data that is not specific to this test
            string phoneNumber = GlobalData["defaultPhoneNumber"];

            // Logger.Log adds info to the NUnit test log and is visible from the Test Explorer run or in Azure DevOps run results
            Logger.Log($"username: {username}");
            Logger.Log($"phoneNumber: {phoneNumber}");
            Logger.Log($"Title: {Driver.Value!.Title}");
        }
    }
}