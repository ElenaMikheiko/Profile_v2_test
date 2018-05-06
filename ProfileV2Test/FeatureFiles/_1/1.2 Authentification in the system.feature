# http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=42861110

Feature: 1.2 Authentication in the system
  In order to have access to functions of the system
  As unauthorized user
  I should have possibility to login to the system using my email and password

  Background:
    Given As unauthorized user I come to landing page of Profile
	
  #Data of users.feature
  Scenario: Authorization in the system of User (correct data)
    When I write e-mail of existing user
	And I write password of this user
    And I log in to the system
    Then I go to personal page

  Scenario: Authorization in the system (incorrect data)    
    When I write incorrect "some@email.com" as email
	When I write incorrect data in field password
    And I log in to the system
    Then I see error message "Hmm, that's not the right email or password. Please try again"
    And I do not get access to the system

  Scenario: Authorization with empty fields (incorrect data)
    When I log in to the system
    Then Fields are highlighted
    And I see error message "Email is required"
    And I do not get access to the system