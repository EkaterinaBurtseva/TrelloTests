Feature: I want to be able to use trello over UI and API
	
@UI
Scenario: Existing user is able to create, update and delete board without command
	Given I login to the system as an existing user
	When I create a dashboard 
	And I add information for "TODO" card
	And dashboard is existed in the list for the current user
    Then I delete dashboard

@UI
Scenario: Existing user is able to create a command and add members with invalid email addresses
    Given I login to the system as an existing user
    When I create a command with invalid email addresses for members
    Then list of emails is displayed in members section


@API
Scenario: Existing user is able to add new card to the existing dashboard, update and delete it
    Given I add new card to the existing board with name
    When I add attachment to the card
    Then I delete card from the board

@API
Scenario: Existing user isn't able to update or delete non-existing board
    Given I update board named as test
    When I receive an error 
    And I delete board named as
    Then I receive an error 

