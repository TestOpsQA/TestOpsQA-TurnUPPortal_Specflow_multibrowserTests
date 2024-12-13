using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TurnUPPortal_Specflow_Tests.PageElements;
using TurnUPPortal_Specflow_Tests.Utilities;


namespace TurnUPPortal_Specflow_multiBrowserTests.Pages
{
    public class HomePage
    {
        public readonly IWebDriver driver;
        public readonly HomePageElements homePageElements;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            // Initialize page elements
            homePageElements = new HomePageElements(driver);
        }

        public void NaviagateToTMPage()
        {
            //Wait until the administration tab is visible and clickable and then click 
            Wait.UntilElementIsVisible(homePageElements.administrationTab);
            Wait.UntilElementIsClickable(homePageElements.administrationTab);
            homePageElements.administrationTab.Click();

            // Select Time and Material option form administration dropdown
            Wait.UntilElementIsClickable(homePageElements.timeAndMaterialOption);
            homePageElements.timeAndMaterialOption.Click();
        }
        public void NavigateToEmployeePage()
        {
            //Wait until the administration tab is visible and clickable and then click 
            Wait.UntilElementIsVisible(homePageElements.administrationTab);
            Wait.UntilElementIsClickable(homePageElements.administrationTab);
            homePageElements.administrationTab.Click();

            //Wait until the Employees option is clickable and then click
            Wait.UntilElementIsClickable(homePageElements.employeeOption);
            homePageElements.employeeOption.Click();
        }
    }
}
