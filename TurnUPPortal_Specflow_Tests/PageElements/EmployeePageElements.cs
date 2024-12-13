using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace TurnUPPortal_Specflow_Tests.PageElements
{
    public class EmployeePageElements
    {
        public readonly IWebDriver driver;
        public EmployeePageElements(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }
        public IWebElement createButton => driver.FindElement(By.XPath("//a[contains(text(),'Create')]"));
        public IWebElement nameTextbox => driver.FindElement(By.XPath("//input[@id='Name']"));
        public IWebElement usernameTextbox => driver.FindElement(By.XPath("//input[@id='Username']"));
        public IWebElement passwordTextbox => driver.FindElement(By.XPath("//input[@id='Password']"));
        public IWebElement reTypePasswordTextbox => driver.FindElement(By.XPath("//input[@id='RetypePassword']"));
        public IWebElement isAdminCheckbox => driver.FindElement(By.XPath("//input[@id='IsAdmin']"));
        public IWebElement saveButton => driver.FindElement(By.XPath("//input[@id='SaveButton']"));

        public IWebElement nameInTableRow => driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        public IWebElement editButton => driver.FindElement(By.XPath("//tbody/tr[last()]/td[3]/a[1]"));

        public IWebElement deleteButton => driver.FindElement(By.XPath("//tbody/tr[last()]/td[3]/a[2]"));


    }
}
