Feature: Logged user is able to work with board and cards
	
Scenario: Existing user is able to add new card, update and delete it
	Given I add new card to the existing board with name Test
	When I update existing card name to Z
	Then I delete current card from the board

Scenario: Existing user isn't able to update or delete non-existing board
    Given I update board with id 1
    When I receive an error no ability to delete
	And I delete board with id 1
	Then I receive an error no ability to update

