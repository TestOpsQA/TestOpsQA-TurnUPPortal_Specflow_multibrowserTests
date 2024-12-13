using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace TurnUPPortal_Specflow_Tests.Utilities
{
    public class Wait
    {
        private const int DefaultTimeoutInSeconds = 80;

        /// <summary>
        /// Waits until the specified WebElement is visible on the page.
        /// </summary>
        public static void UntilElementIsVisible(IWebElement element)
        {
            EnsureDriversAreInitialized();

            // Wait for each driver to be used separately
            WebDriverWait chromeWait = new WebDriverWait(CommonDrivers.chromeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait firefoxWait = new WebDriverWait(CommonDrivers.firefoxDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait edgeWait = new WebDriverWait(CommonDrivers.edgeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));

            chromeWait.Until(driver => element.Displayed);
            firefoxWait.Until(driver => element.Displayed);
            edgeWait.Until(driver => element.Displayed);
        }

        /// <summary>
        /// Waits until the specified WebElement is clickable.
        /// </summary>
        public static void UntilElementIsClickable(IWebElement element)
        {
            EnsureDriversAreInitialized();

            WebDriverWait chromeWait = new WebDriverWait(CommonDrivers.chromeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait firefoxWait = new WebDriverWait(CommonDrivers.firefoxDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait edgeWait = new WebDriverWait(CommonDrivers.edgeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));

            chromeWait.Until(driver => element.Enabled && element.Displayed);
            firefoxWait.Until(driver => element.Enabled && element.Displayed);
            edgeWait.Until(driver => element.Enabled && element.Displayed);
        }

        public static void UntilElementIsPresent(IWebElement element)
        {
            EnsureDriversAreInitialized();

            WebDriverWait chromeWait = new WebDriverWait(CommonDrivers.chromeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait firefoxWait = new WebDriverWait(CommonDrivers.firefoxDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait edgeWait = new WebDriverWait(CommonDrivers.edgeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));

            chromeWait.Until(driver => element != null);
            firefoxWait.Until(driver => element != null);
            edgeWait.Until(driver => element != null);
        }

        public static void UntilElementIsInteractable(IWebElement element)
        {
            EnsureDriversAreInitialized();

            WebDriverWait chromeWait = new WebDriverWait(CommonDrivers.chromeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait firefoxWait = new WebDriverWait(CommonDrivers.firefoxDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait edgeWait = new WebDriverWait(CommonDrivers.edgeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));

            chromeWait.Until(driver =>
                element.Displayed &&    // Element is visible
                element.Enabled &&      // Element is enabled
                IsElementReadyForInteraction(driver, element) // Element is stable for interaction
            );
            firefoxWait.Until(driver =>
                element.Displayed &&
                element.Enabled &&
                IsElementReadyForInteraction(driver, element)
            );
            edgeWait.Until(driver =>
                element.Displayed &&
                element.Enabled &&
                IsElementReadyForInteraction(driver, element)
            );
        }

        // Helper method to ensure the element is stable for interaction
        private static bool IsElementReadyForInteraction(IWebDriver driver, IWebElement element)
        {
            try
            {
                // Check if the element is still visible and enabled
                return element.Displayed && element.Enabled;
            }
            catch (StaleElementReferenceException)
            {
                // The element might have become stale during the interaction
                return false;
            }
        }

        public static void UntilAlertIsPresent()
        {
            EnsureDriversAreInitialized();

            WebDriverWait chromeWait = new WebDriverWait(CommonDrivers.chromeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait firefoxWait = new WebDriverWait(CommonDrivers.firefoxDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            WebDriverWait edgeWait = new WebDriverWait(CommonDrivers.edgeDriver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));

            chromeWait.Until(driver =>
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    return alert != null;
                }
                catch (NoAlertPresentException)
                {
                    return false; // Alert is not present
                }
            });

            firefoxWait.Until(driver =>
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    return alert != null;
                }
                catch (NoAlertPresentException)
                {
                    return false; // Alert is not present
                }
            });

            edgeWait.Until(driver =>
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    return alert != null;
                }
                catch (NoAlertPresentException)
                {
                    return false; // Alert is not present
                }
            });
        }

        private static void EnsureDriversAreInitialized()
        {
            if (CommonDrivers.chromeDriver == null && CommonDrivers.firefoxDriver == null && CommonDrivers.edgeDriver == null)
            {
                throw new InvalidOperationException("WebDriver(s) are not initialized. Call InitializeDrivers first.");
            }
        }
    }
}
