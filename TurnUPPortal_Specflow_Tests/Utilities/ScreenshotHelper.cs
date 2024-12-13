using OpenQA.Selenium;
using System;
using System.IO;

namespace TurnUPPortal_Specflow_Tests.Utilities
{
    public class ScreenshotHelper
    {
      
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                // Verify whether the WebDriver instance supports taking screenshots through ITakesScreenshot interface.
                if (driver is ITakesScreenshot screenshotDriver)
                {
                    //Retrieve the screenshot from the WebDriver as an object.
                    Screenshot screenshot = screenshotDriver.GetScreenshot();

                    // Generate a timestamp to uniquely identify the screenshot file.
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

                    //Defines the directory path where screenshots will be saved.
                    string screenshotsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                    Directory.CreateDirectory(screenshotsDirectory);

                    //Construct the full file path and name for the screenshot, including the test name and timestamp.
                    string filePath = Path.Combine(screenshotsDirectory, $"{testName}_{timestamp}.png");
                    screenshot.SaveAsFile(filePath); //Defaults to PNG format
                    Console.WriteLine($"Screenshot saved at: {filePath}");
                }
                else
                {
                    Console.WriteLine("The WebDriver does not support taking screenshots.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }
    }
}