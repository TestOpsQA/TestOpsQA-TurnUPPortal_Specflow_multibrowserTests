using TechTalk.SpecFlow;

using OpenQA.Selenium;
using TurnUPPortal_Specflow_Tests.Utilities;

namespace TurnUPPortal_Specflow_Tests.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            // Initialize the WebDriver instances for all browsers
            CommonDrivers.GetDriver();

            // Check if each driver is initialized and navigate to the URL
            if (CommonDrivers.chromeDriver != null)
            {
                CommonDrivers.chromeDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            }
            if (CommonDrivers.firefoxDriver != null)
            {
                CommonDrivers.firefoxDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            }
            if (CommonDrivers.edgeDriver != null)
            {
                CommonDrivers.edgeDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            }
        }

        [AfterScenario]

        public static void AfterScenario(ScenarioContext scenarioContext)
        {
            var driver = CommonDrivers.GetDriver();
            try
            {
                // If the scenario fails, capture a screenshot
                if (scenarioContext.TestError != null)
                {
                    // Take screenshot
                    ScreenshotHelper.TakeScreenshot(driver, scenarioContext.ScenarioInfo.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
            finally
            {
                // Quit the WebDriver after each scenario
                CommonDrivers.QuitDriver();

            }
        }
    }
}
