using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

using TurnUPPortal_Specflow_Tests.PageElements;
using TurnUPPortal_Specflow_Tests.Utilities;

namespace TurnUPPortal_Specflow_Tests.Pages
{
    public class EmployeePage
    {
        public readonly IWebDriver driver;
        public readonly EmployeePageElements employeePageElements;
        public readonly TMPageElements tmPageElements;
        public readonly HomePageElements homePageElements;

        public EmployeePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            // Initialize page elements
            employeePageElements = new EmployeePageElements(driver);
            tmPageElements = new TMPageElements(driver);
            homePageElements = new HomePageElements(driver);
        }

        public void CreateEmployeeRecord(string name, string username, string password)
        {
            try
            {
             //wait until create button is visible and then click   
                Wait.UntilElementIsVisible(employeePageElements.createButton);
                employeePageElements.createButton.Click();
            }
            catch (Exception ex)
            {
                //Throw an exception if create button is not found
                TestContext.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail("Create button hasn't been found.");

            }
            try
            {
                //wait unti the anme text box is visible and then type name
                Wait.UntilElementIsVisible(employeePageElements.nameTextbox);
                employeePageElements.nameTextbox.SendKeys(name);
            }
            catch (Exception ex)
            {
                //Throws an exception if name text box is not found
                TestContext.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail("name textbox hasn't been found.");

            }
            //wait until the username textbox is visible and the type username
            Wait.UntilElementIsInteractable(employeePageElements.usernameTextbox);
            employeePageElements.usernameTextbox.SendKeys(username);
            
            //wait until th epassword textbox is interactable and then enter password 
            Wait.UntilElementIsInteractable(employeePageElements.passwordTextbox);
            employeePageElements.passwordTextbox.SendKeys(password);
            
            //wait until the retype password textbox is interactable and the re-type the password
            Wait.UntilElementIsInteractable(employeePageElements.reTypePasswordTextbox);
            employeePageElements.reTypePasswordTextbox.SendKeys(password);

            //wait until the admin check box is clickable and then click on it
            Wait.UntilElementIsClickable(employeePageElements.isAdminCheckbox);
            employeePageElements.isAdminCheckbox.Click();
            
            //wait until the save button is active and clickable
            Wait.UntilElementIsClickable(employeePageElements.saveButton);
            employeePageElements.saveButton.Click();

            // the save button is not taking the user to the Employees page, click on administration tab and select the employee option
            homePageElements.administrationTab.Click();
            Wait.UntilElementIsVisible(homePageElements.employeeOption);
            homePageElements.employeeOption.Click();
            
            //Go to the last page of the Employees table
            Wait.UntilElementIsInteractable(tmPageElements.lastPageButton);

        }
        public string GetName()
        {

            TestContext.WriteLine("getting name text");
            //// Wait until the the last record enterd is visible in the table 
            Wait.UntilElementIsPresent(employeePageElements.nameInTableRow);
            Wait.UntilElementIsVisible(employeePageElements.nameInTableRow);
           // Returns the text of the cretaed record present in the last row of the Employee table
            return employeePageElements.nameInTableRow.Text;

        }

        public void EditEmployeeRecord(string editedName, string editedUsername, string editedPassword)
        {
            //wait until the edit button is clickable and then click
            Wait.UntilElementIsPresent(employeePageElements.editButton);
            Wait.UntilElementIsClickable(employeePageElements.editButton);
            employeePageElements.editButton.Click();

            //Edit the Employee name in th eName field
            Wait.UntilElementIsVisible(employeePageElements.nameTextbox);
            employeePageElements.nameTextbox.Clear();
            employeePageElements.nameTextbox.SendKeys(editedName);

            //wait until the username field is interactable and edit the username 
            Wait.UntilElementIsInteractable(employeePageElements.usernameTextbox);
            employeePageElements.usernameTextbox.Clear();
            employeePageElements.usernameTextbox.SendKeys(editedUsername);

            //wait until the password textbox is interactable and edit the password
            Wait.UntilElementIsInteractable(employeePageElements.passwordTextbox);
            employeePageElements.passwordTextbox.Clear();
            employeePageElements.passwordTextbox.SendKeys(editedPassword);

            //Wait until the re type password textbox is interactable and edit the password
            Wait.UntilElementIsInteractable(employeePageElements.reTypePasswordTextbox);
            employeePageElements.reTypePasswordTextbox.Clear();
            employeePageElements.reTypePasswordTextbox.SendKeys(editedPassword);

            //Wait until the save button is clickable and click on save button
            Wait.UntilElementIsClickable(employeePageElements.saveButton);
            employeePageElements.saveButton.Click();

            // click on administration tab and and slect employees option
            homePageElements.administrationTab.Click();
            Wait.UntilElementIsVisible(homePageElements.employeeOption);
            homePageElements.employeeOption.Click();

            //go to the last page 
            Wait.UntilElementIsInteractable(tmPageElements.lastPageButton);

        }

        public string GetEditedName()
        {
            TestContext.WriteLine("Getting edited employee name");
            Wait.UntilElementIsPresent(employeePageElements.nameInTableRow);
            Wait.UntilElementIsVisible(employeePageElements.nameInTableRow);
            return employeePageElements.nameInTableRow.Text;

        }

        public void DeleteEmployeeRecord()
        {
            // Wait until the delete button is clickable and and click on delete button
            //Wait.UntilElementIsPresent(employeePageElements.deleteButton);
            Wait.UntilElementIsClickable(employeePageElements.deleteButton);
            employeePageElements.deleteButton.Click();

            // Wait until the delete confiramtion alert box is displayed
            Wait.UntilAlertIsPresent();

            //Click OK to delete
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);
            //refresh the employees page
            driver.Navigate().Refresh();

            //Go to last page
            tmPageElements.lastPageButton.Click();
            Thread.Sleep(3000);
        }
        public string GetDeletedName()
        {
            //Return name text from last row of the table 
            Wait.UntilElementIsVisible(employeePageElements.nameInTableRow);
            return employeePageElements.nameInTableRow.Text;
        }

    }


}
