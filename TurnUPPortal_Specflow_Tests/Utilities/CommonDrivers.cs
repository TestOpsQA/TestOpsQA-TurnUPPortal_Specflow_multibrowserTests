using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace TurnUPPortal_Specflow_Tests.Utilities
{
    public static class CommonDrivers
    {
        // Static WebDriver instances
        public static IWebDriver? chromeDriver;
        public static IWebDriver? firefoxDriver;
        public static IWebDriver? edgeDriver;

        // Get or initialize the WebDriver for all browsers
        public static IWebDriver GetDriver()
        {
            if (chromeDriver == null)
            {
                chromeDriver = new ChromeDriver();
                chromeDriver.Manage().Window.Maximize();
            }

            if (firefoxDriver == null)
            {
                firefoxDriver = new FirefoxDriver();
                firefoxDriver.Manage().Window.Maximize();
            }

            if (edgeDriver == null)
            {
                edgeDriver = new EdgeDriver();
                edgeDriver.Manage().Window.Maximize();
            }

            return chromeDriver; // This can be any driver as all will be initialized
        }

        // Quit all the WebDriver instances
        public static void QuitDriver()
        {
            if (chromeDriver != null)
            {
                try
                {
                    chromeDriver.Quit();
                }
                finally
                {
                    chromeDriver = null;
                }
            }

            if (firefoxDriver != null)
            {
                try
                {
                    firefoxDriver.Quit();
                }
                finally
                {
                    firefoxDriver = null; 
                }
            }

            if (edgeDriver != null)
            {
                try
                {
                    edgeDriver.Quit();
                }
                finally
                {
                    edgeDriver = null;
                }
            }
        }

        // Check if the drivers are initialized
        public static bool AreDriversInitialized()
        {
            return chromeDriver != null && firefoxDriver != null && edgeDriver != null;
        }
    }
}
