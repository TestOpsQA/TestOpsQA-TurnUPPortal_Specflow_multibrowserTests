Feature: EmployeeModule

As an admin user I can create an employee record in Employee page



Background: 
Given User logged in to the TurnUp portal
And user navigates to Employee page

Scenario Outline: User can create an Employee record
	When user creates an employee record with valid '<name>', '<userName>', and '<password>' 
	Then Employee record must be successfully created with '<name>' data
	Examples: 
	| name   | userName   | password  |
	| name one | username one | p@ssWord1 |

Scenario Outline:  User can edit the Employee record
	When user edits the employee record with valid '<editedName>', '<editedUserName>', and '<editedPassword>'
	Then employee record must be edited successfully with '<editedName>' data

	Examples: 
	| editedName    | editedUserName    | editedPassword  |
	| edited name one | edited username one | editedP@ssWord1 |
	| edited name two | edited username two | editedP@ssWord2 |

Scenario Outline: user can delete th Employee record

	When user deletes an employee record 
	Then the record is deleted successfully and the employees table must not contain '<editedName>' record

	Examples: 
	| editedName    |
	| edited name two|


