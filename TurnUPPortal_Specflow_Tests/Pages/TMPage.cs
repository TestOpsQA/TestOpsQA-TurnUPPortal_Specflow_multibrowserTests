using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TurnUPPortal_Specflow_Tests.PageElements;
using TurnUPPortal_Specflow_Tests.Utilities;

namespace TurnUPPortal_Specflow_multiBrowserTests.Pages
{
    public class TMPage
    {

        public readonly IWebDriver driver;
        public readonly TMPageElements tmPageElements;
        
        public TMPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            // Initialize page elements
            tmPageElements = new TMPageElements(driver);
        }

        public void createTimeRecord(string code, string description, string price)
        {
            try
            {
                // Access elements through the tmPageElements instance and click on create new button
                Wait.UntilElementIsVisible(tmPageElements.createNewButton);
                Wait.UntilElementIsClickable(tmPageElements.createNewButton);
                tmPageElements.createNewButton.Click();
            }
            catch (Exception ex)
            {
                //Throw exception when Create New button is not found
                TestContext.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail("Create New button hasn't been found"+ driver);
            }
            try
            {
                // Access elements through the tmPageElements instance and click on typeCode dropdown
                Wait.UntilElementIsVisible(tmPageElements.typeCodeDropdown);
                tmPageElements.typeCodeDropdown.Click();
            }
            catch (Exception ex)
            {
                //Throw exception when Type code drop down not found
                TestContext.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail("type code drop down hasn't been found.");
            }
            //Click on Time Option from type code dropdown
            Wait.UntilElementIsVisible(tmPageElements.timeOption);
            tmPageElements.timeOption.Click();
           
            // Type code into Code textbox
            tmPageElements.codeTextbox.SendKeys(code);
         

            // Type description into Description textbox
            tmPageElements.descriptionTextbox.SendKeys(description);

            //Click on the butoon which is overlapping Price text box
            tmPageElements.priceTagOverlap.Click();

            // Type price into Price textbox
            tmPageElements.priceTextbox.SendKeys(price);

            //Wait until save button is clickable 
            Wait.UntilElementIsClickable(tmPageElements.saveButton);
            // Click on Save button
            tmPageElements.saveButton.Click();


            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
        }
        public void goToLastPage()
        {
            //Check if the page is compltely loaded
            if (((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete")
            {
                try
                { 
                    // Page is fully loaded, wait for the last page button to be clickable
                    Wait.UntilElementIsInteractable(tmPageElements.lastPageButton);
                    tmPageElements.lastPageButton.Click();

                    //last page button was not interactable on first attempt
                    Thread.Sleep(5000);
                    Wait.UntilElementIsInteractable(tmPageElements.lastPageButton);
                    tmPageElements.lastPageButton.Click();

                }

                /*  var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
                 wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete");
                 wait.Until(driver => driver.FindElements(By.TagName("tr")).Count > 0);
                 try
                 {
                     // Create a WebDriverWait instance
                     /* var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                      // **Condition: Wait for the entire page to fully load**
                      wait.Until(driver =>
                          ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete");
                      //tr
                      wait.Until(driver => driver.FindElements(By.TagName("tr")).Count > 0);
                      // Wait until the last page button is both visible and clickable
                      wait.Until(driver =>
                          tmPageElements.lastPageButton.Displayed && tmPageElements.lastPageButton.Enabled);

                      // Click the last page button*/
                /// tmPageElements.lastPageButton.Click();

                catch (Exception ex)
                {
                    //Throws exception when last page butoon not found
                    TestContext.WriteLine($"Element not found: {ex.Message}");
                    Assert.Fail("last page button hasn't been found."+nameof(driver));
                }
            }
            else
            {
                //Throw an eroor if unable to go to last page
                Assert.Fail("unable to go to last page");
            }
        }
        
        // Get Code from the last row
        public string GetCode()
        {
            TestContext.WriteLine("getting code text");

            // driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
         
            Wait.UntilElementIsVisible(tmPageElements.codeInRow);
            return tmPageElements.codeInRow.Text;

        }
        // Get Description from the last row
        public string GetDescription()
        {
            TestContext.WriteLine("getting description text");
            return tmPageElements.descriptionInRow.Text;
        }

        // Get Price from the last row
        public string GetPrice()
        {
            TestContext.WriteLine("getting price text");
            return tmPageElements.priceInRow.Text;
        }
        public void EditTimeRecord(string editedCode, string editedDescription, string editedPrice)
        {


            Wait.UntilElementIsVisible(tmPageElements.editButton);
            Wait.UntilElementIsClickable(tmPageElements.editButton);
            tmPageElements.editButton.Click();
            tmPageElements.codeTextbox.Clear();
            tmPageElements.codeTextbox.SendKeys(editedCode);
           
            tmPageElements.descriptionTextbox.Clear();
            tmPageElements.descriptionTextbox.SendKeys(editedDescription);

            Wait.UntilElementIsClickable(tmPageElements.priceTagOverlap);

            tmPageElements.priceTagOverlap.Click();

            // Wait for the second element (priceTextbox) to be interactable
            Wait.UntilElementIsInteractable(tmPageElements.priceTextbox);

            // Click and clear the text box to ensure it's ready for input
            tmPageElements.priceTextbox.Click();
            tmPageElements.priceTextbox.Clear();
            Thread.Sleep(3000);
            tmPageElements.priceTagOverlap.Click();
            tmPageElements.priceTextbox.Click();

            // Add an additional check for interactability before sending keys
            Wait.UntilElementIsInteractable(tmPageElements.priceTextbox);
            tmPageElements.priceTextbox.SendKeys(editedPrice);


            Wait.UntilElementIsVisible(tmPageElements.saveButton);
            tmPageElements.saveButton.Click();
           // Thread.Sleep(5000);
            Wait.UntilElementIsVisible(tmPageElements.lastPageButton);
            tmPageElements.lastPageButton.Click();
        }
        public string GetEditedCode()
        {
            //Get the edited code from last row
            return tmPageElements.codeInRow.Text;
        }

        public string GetEditedDescription()
        {

            //Get the edited description from the last row
            return tmPageElements.descriptionInRow.Text;
        }
        public string GetEditedPrice()
        {
            //Get the edited price from last row
            return tmPageElements.priceInRow.Text;
        }

        public void DeleteTimeRecord()
        {

            //Wait until delete button is visible and then click
            Wait.UntilElementIsVisible(tmPageElements.deleteButton);
            tmPageElements.deleteButton.Click();
            //Wait until delete confirmation alert box is displayed 
            Wait.UntilAlertIsPresent();

            //Click OK to delete
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            driver.Navigate().Refresh();

            //Check if the record is deleted
          
           tmPageElements.lastPageButton.Click();
            //Thread.Sleep(3000);

        }
        public String GetDeletedCode()
        {
            //Get the code from last row to check if the row has been deleted
            Wait.UntilElementIsVisible(tmPageElements.codeInRow);
            return tmPageElements.codeInRow.Text;
        }
    } }