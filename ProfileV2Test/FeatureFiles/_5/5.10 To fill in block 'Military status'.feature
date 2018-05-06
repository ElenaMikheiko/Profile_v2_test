#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43418114
#|Role   |name|surname |e-mail                   |password  |phone number     |
#|student|Ruby|Javovich|javovichrubu555@gmail.com|ruby123456|+375 44 275 58 32|

 Feature: 5.10 To fill in block "Military status"
    In order to inform employer
    As authorized user
    I have possibility to fill in block "Military status"

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Ruby Javovich
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Military status"

 Scenario: Student Saves information
    Given I filled in field "Military status"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Military status" is present

 Scenario: Student Checks available option for military status
    When I see radio buttons in block "Military status"
    Then I see value "Doesn't apply"
    And I see value "Exempted"
    And I see value "Completed"
    And I see value "Postponed"
    And I see value "Currently serving"
    And I can choose military status

 Scenario: Student checking resume block title of page
    Then I see resume block title "Military status"
    And I see notification "Mandatory field"

 Scenario: Student Saves information
    Given I filled in field "Military status"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Military status" is present


 Scenario: Student Moves to next page
    Given I filled in block "Military status"
    When I choose to move to next page
#Then Information is saved
    Then I moved to block "Portfolio"