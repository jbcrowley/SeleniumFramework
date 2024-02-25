using SeleniumFramework.PageObjects.TheInternet;

namespace SeleniumFramework.Tests.TheInternet
{
    public class SelectElementTest : BaseTest
    {
        [Test]
        [Category("Select")]
        public void SelectElement()
        {
            string option = "Option 2";

            Driver.Value!.Url = "http://the-internet.herokuapp.com/dropdown";
            DropdownPage dropdownPage = new DropdownPage(Driver.Value!);
            dropdownPage.ChooseByText(option);

            Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo(option), "Verify selected OPTION");
        }
    }
}