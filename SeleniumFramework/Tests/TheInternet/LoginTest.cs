using SeleniumFramework.PageObjects.TheInternet;

namespace SeleniumFramework.Tests.TheInternet
{
    public class LoginTest : BaseTest
    {
        [Test]
        [Category("Login")]
        public void Login()
        {
            string username = TestData["username"];
            string password = TestData["password"];

            new LoginPage().Login(username, password);

            new SecurePage().Logout();

            Assert.AreEqual(Url, DriverInstance.Url, "Verify login URL");
        }
    }
}