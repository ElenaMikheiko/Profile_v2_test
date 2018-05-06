#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43419570
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|student  |Sophie                   |Miler                |milersophie555@gmail.com|sophie123456  |+375 33 102 99 89|

 Feature: 5.9 To fill in block "Portfolio"
    In order to demonstrate my achievement
    As authorized user
    I should have possibility to fill in block "Portfolio"

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Sophie Miler
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Portfolio"
   
 Scenario: Student Checks resume block title of page
    Then I see resume block title "Portfolio"
    And I see that tab name "Portfolio" is active

 Scenario: Student Saves information
    Given I filled in field "Add a link"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Portfolio" is present

 Scenario: Student Adds one more field "Add a link"
    When I press button with plus
    Then I see new empty field "Add a link"

 Scenario: Student Deletes field "Add a link"
    Given I added one more field "Add a link"
    When I press on button with cross
    Then Field "Add a link" is deleted
     
 Scenario: Student Moves to next page
    Given I filled in block "Portfolio"
    When I choose to move to next page
#Information is saved
    Then I moved to block "Military status" 

# Scenario: Allowed symbols in fields
# Add a link: A-Z a-z А-Я а-я 0-9 !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ space
# https://www.owasp.org/index.php/Password_special_characters