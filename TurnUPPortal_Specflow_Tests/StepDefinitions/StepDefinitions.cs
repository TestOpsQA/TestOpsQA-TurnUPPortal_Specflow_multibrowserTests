using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TurnUPPortal_Specflow_multiBrowserTests.Pages;
using TurnUPPortal_Specflow_Tests.Pages;
using TurnUPPortal_Specflow_Tests.Utilities;

namespace TurnUPPortal_Specflow_Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        // Declare drivers for each browser
        public IWebDriver chromeDriver;
        public IWebDriver firefoxDriver;
        public IWebDriver edgeDriver;

        // Declare page objects for each browser
        public LoginPage chromeLoginPage;
        public HomePage chromeHomePage;
        public TMPage chromeTMPage;
        public EmployeePage chromeEmployeePage;

        public LoginPage firefoxLoginPage;
        public HomePage firefoxHomePage;
        public TMPage firefoxTMPage;
        public EmployeePage firefoxEmployeePage;

        public LoginPage edgeLoginPage;
        public HomePage edgeHomePage;
        public TMPage edgeTMPage;
        public EmployeePage edgeEmployeePage;

        public StepDefinitions()
        {
            // Initialize drivers using CommonDrivers
            chromeDriver = CommonDrivers.chromeDriver ?? CommonDrivers.GetDriver();
            firefoxDriver = CommonDrivers.firefoxDriver ?? CommonDrivers.GetDriver();
            edgeDriver = CommonDrivers.edgeDriver ?? CommonDrivers.GetDriver();

            // Initialize page objects for each browser
            chromeLoginPage = new LoginPage(chromeDriver);
            chromeHomePage = new HomePage(chromeDriver);
            chromeTMPage = new TMPage(chromeDriver);
            chromeEmployeePage= new EmployeePage(chromeDriver);

            firefoxLoginPage = new LoginPage(firefoxDriver);
            firefoxHomePage = new HomePage(firefoxDriver);
            firefoxTMPage = new TMPage(firefoxDriver);
            firefoxEmployeePage = new EmployeePage(firefoxDriver);

            edgeLoginPage = new LoginPage(edgeDriver);
            edgeHomePage = new HomePage(edgeDriver);
            edgeTMPage = new TMPage(edgeDriver);
            edgeEmployeePage = new EmployeePage(edgeDriver);
        }
        //Log in to the TurnUp portal on Chrome, firefox and edge browsers 
        [Given(@"User logged in to the TurnUp portal")]
        public void GivenUserLoggedInToTheTurnUpPortal()
        {
            chromeLoginPage.EnterUsername();
            chromeLoginPage.EnterPassword();
            chromeLoginPage.ClickLoginButton();
            chromeLoginPage.WaitForUrl();
           
           
            firefoxLoginPage.EnterUsername();
            firefoxLoginPage.EnterPassword();
            firefoxLoginPage.ClickLoginButton();
            firefoxLoginPage.WaitForUrl();
            
            edgeLoginPage.EnterUsername();
            edgeLoginPage.EnterPassword();
            edgeLoginPage.ClickLoginButton();
            edgeLoginPage.WaitForUrl();

        }

        //Navigate to the Time and Materials page on Chrome, firefox and edge browsers 
        [Given(@"user navigates to Time and Material page")]
        public void GivenUserNavigatesToTimeAndMaterialPage()
        {
            chromeHomePage.NaviagateToTMPage();
            firefoxHomePage.NaviagateToTMPage();
            edgeHomePage.NaviagateToTMPage();
        }

        //Create a Time Record
        [When(@"user creates a Time record using valid '([^']*)', '([^']*)' and '([^']*)' data")]
        public void WhenUserCreatesATimeRecordUsingValidAndData(string code, string description, string price)
        {

            chromeTMPage.createTimeRecord(code,description,price);
            chromeTMPage.goToLastPage();
            firefoxTMPage.createTimeRecord(code, description, price);
           firefoxTMPage.goToLastPage();
            edgeTMPage.createTimeRecord(code, description, price);
            edgeTMPage.goToLastPage();
        }

        //Check if record has been created successfully
        [Then(@"The time record is created successfully with valid '([^']*)', '([^']*)' and '([^']*)' data")]
        public void ThenTheTimeRecordIsCreatedSuccessfullyWithValidAndData(string code, string description, string price)
        {
           string newCode = chromeTMPage.GetCode();
           string newDescription = chromeTMPage.GetDescription();
           string newPrice = chromeTMPage.GetPrice();
            TestContext.WriteLine(newPrice);
            Assert.That(newCode == code, "Actual Code and expected Code do not match.");
            Assert.That(newDescription == description, "Actual Description and expected Description do not match.");
            Assert.That(newPrice == "$" + price + ".00", "Actual Price and expected Price do not match.");
          
            string newCodeff = firefoxTMPage.GetCode();
            string newDescriptionff = firefoxTMPage.GetDescription();
            string newPriceff = firefoxTMPage.GetPrice();
            TestContext.WriteLine(newPrice);
            Assert.That(newCodeff == code, "Actual Code and expected Code do not match.");
            Assert.That(newDescriptionff == description, "Actual Description and expected Description do not match.");
            Assert.That(newPriceff == "$" + price + ".00", "Actual Price and expected Price do not match.");
            
            string newCodefe = edgeTMPage.GetCode();
            string newDescriptionfe = edgeTMPage.GetDescription();
            string newPricefe = edgeTMPage.GetPrice();
            TestContext.WriteLine(newPrice);
            Assert.That(newCodefe == code, "Actual Code and expected Code do not match.");
            Assert.That(newDescriptionfe == description, "Actual Description and expected Description do not match.");
            Assert.That(newPricefe == "$" + price + ".00", "Actual Price and expected Price do not match.");
        }

        //Edit the created Time record 
        [When(@"user edits the created Time record with valid '([^']*)', '([^']*)' and '([^']*)' data")]
        public void WhenUserEditsTheCreatedTimeRecordWithValidAndData(string EditedCode, string EditedDescription, string EditedPrice)
        {
            chromeTMPage.goToLastPage();
            chromeTMPage.EditTimeRecord(EditedCode, EditedDescription, EditedPrice);
            firefoxTMPage.goToLastPage();
            firefoxTMPage.EditTimeRecord(EditedCode, EditedDescription, EditedPrice);
            edgeTMPage.goToLastPage();
            edgeTMPage.EditTimeRecord(EditedCode, EditedDescription, EditedPrice);
        }

        //Verify if the Time record has been edited succesfully
        [Then(@"the record is edited successfully with valid '([^']*)', '([^']*)' and '([^']*)' data")]
        public void ThenTheRecordIsEditedSuccessfullyWithValidAndData(string EditedCode, string EditedDescription, string EditedPrice)
        {
            chromeTMPage.goToLastPage();
            string editedCode = chromeTMPage.GetEditedCode();
            string editedDescription = chromeTMPage.GetEditedDescription();
            string editedPrice = chromeTMPage.GetEditedPrice();

            //recheck code and description
            Assert.That(editedCode == EditedCode, "Expected Edited Code and actual edited code do not match.");
            Assert.That(editedDescription == EditedDescription, "Expected Edited Description and actual edited description do not match.");
            Assert.That(editedPrice == "$" + EditedPrice + ".00", "Expected Edited Price and actual edited price do not match.");

            firefoxTMPage.goToLastPage();
            string editedCodeff = firefoxTMPage.GetEditedCode();
            string editedDescriptionff = firefoxTMPage.GetEditedDescription();
            string editedPriceff = firefoxTMPage.GetEditedPrice();

            //recheck code and description
            Assert.That(editedCodeff == EditedCode, "Expected Edited Code and actual edited code do not match.");
            Assert.That(editedDescriptionff == EditedDescription, "Expected Edited Description and actual edited description do not match.");
            Assert.That(editedPriceff == "$" + EditedPrice + ".00", "Expected Edited Price and actual edited price do not match.");

            edgeTMPage.goToLastPage();
            string editedCodefe = edgeTMPage.GetEditedCode();
            string editedDescriptionfe = edgeTMPage.GetEditedDescription();
            string editedPricefe = edgeTMPage.GetEditedPrice();

            //Verify code, description and price
            Assert.That(editedCodefe == EditedCode, "Expected Edited Code and actual edited code do not match.");
            Assert.That(editedDescriptionfe == EditedDescription, "Expected Edited Description and actual edited description do not match.");
            Assert.That(editedPricefe == "$" + EditedPrice + ".00", "Expected Edited Price and actual edited price do not match.");


        }

        //Delete the edited Time Record
        [When(@"user deletes the edited Time record")]
        public void WhenUserDeletesTheEditedTimeRecord()
        {
            chromeTMPage.goToLastPage();
            chromeTMPage.DeleteTimeRecord();
            firefoxTMPage.goToLastPage();
            firefoxTMPage.DeleteTimeRecord();
            edgeTMPage.goToLastPage();
            edgeTMPage.DeleteTimeRecord();
        }


        //Verify if the Time Record has been succesfully deleted
        [Then(@"The time record is deleted and does not contain '([^']*)'")]
        public void ThenTheTimeRecordIsDeletedAndDoesNotContain(string EditedCode)
        {
            chromeTMPage.goToLastPage();
            string deletedCode= chromeTMPage.GetDeletedCode();
            Assert.That(deletedCode != EditedCode, "The record is not deleted");

            firefoxTMPage.goToLastPage();
            string deletedCodeff = firefoxTMPage.GetDeletedCode();
            Assert.That(deletedCodeff != EditedCode, "The record is not deleted");

            edgeTMPage.goToLastPage();
            string deletedCodefe = edgeTMPage.GetDeletedCode();
            Assert.That(deletedCodefe != EditedCode, "The record is not deleted");
        }

        //Navigate to the Employees Page 
        [Given(@"user navigates to Employee page")]
        public void GivenUserNavigatesToEmployeePage()
        {
            chromeHomePage.NavigateToEmployeePage();
            firefoxHomePage.NavigateToEmployeePage();
            edgeHomePage.NavigateToEmployeePage();        
            
        }

        //Create an Employee record
        [When(@"user creates an employee record with valid '([^']*)', '([^']*)', and '([^']*)'")]
        public void WhenUserCreatesAnEmployeeRecordWithValidAnd(string name, string userName, string password)
        {
          

        chromeEmployeePage.CreateEmployeeRecord(name, userName, password);
            firefoxEmployeePage.CreateEmployeeRecord(name, userName, password);
            edgeEmployeePage.CreateEmployeeRecord(name, userName, password);

            chromeTMPage.goToLastPage();
            firefoxTMPage.goToLastPage();
            edgeTMPage.goToLastPage();

        }

        //Verify that the Employee record has been successfully created
        [Then(@"Employee record must be successfully created with '([^']*)' data")]
        public void ThenEmployeeRecordMustBeSuccessfullyCreatedWithData(string newName)
        {
            string newNameCreated = chromeEmployeePage.GetName();
            Assert.That(newNameCreated == newName, "Then actual employee name and expaected employee name does not match");

            string newNameCreatedFF = firefoxEmployeePage.GetName();
            Assert.That(newNameCreatedFF == newName, "Then actual employee name and expaected employee name does not match");

            string newNameCreatedMe = edgeEmployeePage.GetName();
            Assert.That(newNameCreatedMe == newName, "Then actual employee name and expaected employee name does not match");
        }
        
        //Edit the Created Employee record
        [When(@"user edits the employee record with valid '([^']*)', '([^']*)', and '([^']*)'")]
        public void WhenUserEditsTheEmployeeRecordWithValidAnd(string editedName, string editedUsername, string editedPassword)
        {

            chromeTMPage.goToLastPage();
            chromeEmployeePage.EditEmployeeRecord(editedName, editedUsername, editedPassword);

            firefoxTMPage.goToLastPage();
            firefoxEmployeePage.EditEmployeeRecord(editedName, editedUsername, editedPassword);

            edgeTMPage.goToLastPage();
            edgeEmployeePage.EditEmployeeRecord(editedName, editedUsername, editedPassword);

        }

        //Verify if the Eployee record has been succesfully Edited
        [Then(@"employee record must be edited successfully with '([^']*)' data")]
        public void ThenEmployeeRecordMustBeEditedSuccessfullyWithData(string editedName)
        {
            chromeTMPage.goToLastPage();
            string EditedName = chromeEmployeePage.GetEditedName();
            Assert.That(EditedName == editedName, "The actual edited name and the expaected edited name does not match in chrome");

            firefoxTMPage.goToLastPage();
            string EditedNameFF = firefoxEmployeePage.GetEditedName();
            Assert.That(EditedNameFF == editedName, "The actual edited name and the expaected edited name does not match in firefox");
            
            edgeTMPage.goToLastPage();
            string EditedNameME = edgeEmployeePage.GetEditedName();
            Assert.That(EditedNameME == editedName, "The actual edited name and the expaected edited name does not match in msEdge");
        }

        //Delete the edited Employee record
        [When(@"user deletes an employee record")]
        public void WhenUserDeletesAnEmployeeRecord()
        {

            chromeTMPage.goToLastPage();
            chromeEmployeePage.DeleteEmployeeRecord();
          
            firefoxTMPage.goToLastPage();
            firefoxEmployeePage.DeleteEmployeeRecord();

            edgeTMPage.goToLastPage();
            edgeEmployeePage.DeleteEmployeeRecord();
        }


        //Verify if the Employee record has been deleted successfully
        [Then(@"the record is deleted successfully and the employees table must not contain '([^']*)' record")]
        public void ThenTheRecordIsDeletedSuccessfullyAndTheEmployeesTableMustNotContainRecord(string editedName)
        {
            chromeTMPage.goToLastPage();
            string DeletedName = chromeEmployeePage.GetDeletedName();
            Assert.That(DeletedName != editedName, "The record is not deleted in chrome");

            firefoxTMPage.goToLastPage();
            string DeletedNameFF = firefoxEmployeePage.GetDeletedName();
            Assert.That(DeletedNameFF != editedName, "The record is not deleted in firefox");

            edgeTMPage.goToLastPage();
            string DeletedNameME = edgeEmployeePage.GetDeletedName();
            Assert.That(DeletedNameME != editedName, "The record is not deleted in edge browser");
        }


    }
}
