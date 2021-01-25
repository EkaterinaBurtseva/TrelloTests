Feature: Verify basic UI and API for Trello
	
Scenario: Existing user is able to add new card, update and delete it
	Given I add new card to the existing board with name Test
	When I update existing card name to Z
	Then I delete current card from the board

Scenario: Existing user isn't able to update or delete non-existing board
    Given I update board with id l1f to name test
    When I receive an error no ability to delete
	And I delete board with id 1
	Then I receive an error no ability to update

Scenario: Existing user is able to create a command and add members with invalid email addresses
    Given I login to the system as an existing user
    When I create a command smth with invalid email addresses testTvsd23@smth.com for members
    Then list of emails is displayed in members section for team smth

Scenario: Existing user is able to create, update and delete board without command
	Given I login to the system as an existing user
	When I create a dashboard defaultTestSmth
	And dashboard default is existed in the list for the current user
    And I add card test for 'TODO' list
    Then I delete dashboard default

