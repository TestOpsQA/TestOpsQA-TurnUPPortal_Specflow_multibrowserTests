using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TurnUPPortal_Specflow_Tests.PageElements;
using TurnUPPortal_Specflow_Tests.Utilities;

namespace TurnUPPortal_Specflow_Tests.Pages
{
    public class LoginPage
    {
        public readonly IWebDriver driver;
        public readonly LoginPageElements loginPageElements;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            // Initialize page elements
            loginPageElements = new LoginPageElements(driver);
        }

        //Enter user name in username field
        public void EnterUsername()
        {
            Wait.UntilElementIsVisible(loginPageElements.UsernameField);
            loginPageElements.UsernameField.Clear();
            loginPageElements.UsernameField.SendKeys("hari");
        }

        //Enter password in password field
        public void EnterPassword()
        {
            Wait.UntilElementIsVisible(loginPageElements.PasswordField);
            loginPageElements.PasswordField.Clear();
            loginPageElements.PasswordField.SendKeys("123123");
        }

        //Click on Login Button
        public void ClickLoginButton()
        {
            Wait.UntilElementIsClickable(loginPageElements.LoginButton);
            loginPageElements.LoginButton.Click();
        }
        //Check the user is Logged in succesfully and is on correct url
        public void WaitForUrl()
        {
            // Wait until the URL is the expected one
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(d => d.Url.Equals(loginPageElements.expectedUrl));

            // Get the current URL
            string currentUrl = driver.Url;

            // Assert that the URL is correct
            Assert.That(currentUrl, Is.EqualTo(loginPageElements.expectedUrl), $"Expected URL to be {loginPageElements.expectedUrl}, but found {currentUrl}.");
        }
    }
}
