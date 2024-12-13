Feature: TimeAndMaterialModule

As an admin user i can login, navigate to Time and Material Page and then create , edit and delete a time Record

Background: 
	Given User logged in to the TurnUp portal
	And user navigates to Time and Material page


Scenario Outline: User can create a Time record
	
	When user creates a Time record using valid '<code>', '<description>' and '<price>' data
	Then The time record is created successfully with valid '<code>', '<description>' and '<price>' data

Examples: |
| code   | description   | price   |
| code 1 | description 1 | 1,234    |


Scenario Outline:  User can edit the created time record using valid data

	When user edits the created Time record with valid '<EditedCode>', '<EditedDescription>' and '<EditedPrice>' data
	Then the record is edited successfully with valid '<EditedCode>', '<EditedDescription>' and '<EditedPrice>' data

	Examples: 
	| EditedCode   | EditedDescription   | EditedPrice   |
	| Edited Code 1 | Edited Description 1 | 100 |
	| Edited Code 2 | Edited Description 2 | 200 |
	| Edited Code 3 | Edited Description 3 | 300 |


Scenario Outline: User can delete the created time record 

	When user deletes the edited Time record 
	Then The time record is deleted and does not contain '<EditedCode>'
	
	Examples: 
	| EditedCode   |
	| Edited code 3 |



