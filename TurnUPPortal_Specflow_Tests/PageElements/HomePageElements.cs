using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TurnUPPortal_Specflow_Tests.PageElements
{
    public class HomePageElements
    {

        public readonly IWebDriver driver;
        public string timeAndMaterialUrl = "http://horse.industryconnect.io/TimeMaterial";
        public string ExpectedTimeAndMaterialUrl = "";

        public HomePageElements(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        public IWebElement administrationTab => driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
       public IWebElement timeAndMaterialOption => driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        public IWebElement employeeOption => driver.FindElement(By.XPath("//a[contains(text(),'Employees')]"));

    }
}
