using BasePage.Extensions;
using SeleniumFramework.PageObjects.TheInternet;
using static SeleniumFramework.PageObjects.TheInternet.DropdownPage;

namespace SeleniumFramework.Tests.TheInternet
{
    public class SelectElementTest : BaseTest
    {
        [Test]
        [Category("Select")]
        public void SelectElement()
        {
            Option option = Option.Option2;

            Driver.Value!.Url = "http://the-internet.herokuapp.com/dropdown";
            DropdownPage dropdownPage = new DropdownPage(Driver.Value!);
            dropdownPage.ChooseByText(option);

            Assert.That(dropdownPage.GetSelectedOption(), Is.EqualTo(option.GetDescription()), "Verify selected OPTION");
        }
    }
}