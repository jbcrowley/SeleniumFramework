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

            new LoginPage(Driver.Value!).Login(username, password);

            new SecurePage(Driver.Value!).Logout();

            Assert.That(Driver.Value!.Url, Is.EqualTo(Url), "Verify login URL");
        }
    }
}