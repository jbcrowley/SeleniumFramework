using SeleniumFramework.PageObjects.TheInternet;

namespace SeleniumFramework.Tests.TheInternet
{
    public class SelectElementTest : BaseTest
    {
        [Test]
        [Category("Login")]
        public void SelectElement()
        {
            Driver.Value.Url = "http://the-internet.herokuapp.com/dropdown";

            string option = "Option 1";
            DropdownPage dropdownPage = new DropdownPage(Driver.Value);
            dropdownPage.ChooseByText(option);

            Assert.AreEqual(option, dropdownPage.GetSelectedOption(), "Verify selected OPTION");
        }
    }
}