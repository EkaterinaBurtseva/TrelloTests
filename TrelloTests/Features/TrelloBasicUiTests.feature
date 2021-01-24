Feature: I as logged user
         is able to create/update/delete board and team
	
Scenario: Existing user is able to create, update and delete board without command
	Given I login to the system as an existing user
	When I create a dashboard default
	And dashboard default is existed in the list for the current user
    And I add card test for 'TODO' list
    Then I delete dashboard default

Scenario: Existing user is able to create a command and add members with invalid email addresses
    Given I login to the system as an existing user
    When I create a command smth with invalid email addresses test123@smth.com for members
    Then list of emails is displayed in members section for team smth
