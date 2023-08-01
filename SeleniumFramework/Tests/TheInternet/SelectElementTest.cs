using SeleniumFramework.PageObjects.TheInternet;

namespace SeleniumFramework.Tests.TheInternet
{
    public class SelectElementTest : BaseTest
    {
        [Test]
        [Category("Select")]
        public void SelectElement()
        {
            Driver.Value.Url = "http://the-internet.herokuapp.com/dropdown";

            string option = "Option 3";
            DropdownPage dropdownPage = new DropdownPage(Driver.Value);
            dropdownPage.ChooseByText(option);

            Assert.AreEqual(option, dropdownPage.GetSelectedOption(), "Verify selected OPTION");
        }
    }
}