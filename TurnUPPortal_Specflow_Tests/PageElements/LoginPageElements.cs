using OpenQA.Selenium;

namespace TurnUPPortal_Specflow_Tests.PageElements
{
    public class LoginPageElements
    {
        public readonly IWebDriver driver;
        public string expectedUrl = "http://horse.industryconnect.io/";

        public LoginPageElements(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        // Define elements
        public IWebElement UsernameField => driver.FindElement(By.Id("UserName"));
        public IWebElement PasswordField => driver.FindElement(By.Id("Password"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        public IWebElement welcomeMessage=> driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
    }
}
