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

            Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo(option), "Verify selected OPTION");
        }
    }
}