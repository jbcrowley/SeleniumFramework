using NUnit.Framework;
using SeleniumFramework.Utils;

namespace SeleniumFramework.Tests.TheInternet
{
    public class SampleTest : BaseTest
    {
        [Test]
        public void SampleTestMethod()
        {
            // TestData contains data specific to this test
            string username = TestData["username"];

            // GlobalData contains data that is not specific to this test
            string phoneNumber = GlobalData["defaultPhoneNumber"];

            // GenericHelper.Log adds info to the NUnit test log and is visible from the Test Explorer run or in Team Foundation Server/Azure DevOps run results
            GenericHelper.Log($"username: {username}");
            GenericHelper.Log($"phoneNumber: {phoneNumber}");
            GenericHelper.Log($"Title: {Driver.Value.Title}");
        }
    }
}