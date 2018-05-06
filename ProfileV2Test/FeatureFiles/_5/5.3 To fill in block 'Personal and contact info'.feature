#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417829
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|student  |Ivan                     |Smith                |smithivan555@gmail.com  |ivan123456    |+375 44 575 00 50|

Feature: 5.3 To add personal and contact information
	In order other people can contact me
	As authorized user
	I should have possibility to add my personal information

Background:
	Given As unauthorised user I come to landing page of Profile
	And I log in as Personal1 Test
	And I open my personal menu
	And I select button "Resume"
	And I go to block "Personal and contact information"

Scenario: Student Moves to next page
    Given I filled all fields in "Personal and contact information"
    When I choose to move to next page
    Then I moved to block "Objective"

Scenario: Student can see Tab status in status bar
    Then I see that tab name "Personal and contact information" is active

Scenario: Student can Save information
    When I filled in field "Name"
    And I filled in field "Surname"
    And I filled in field "Phone number"
    And I filled in field "Skype"
    And I filled in field "LinkedIn"
    And I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Personal and contact information" is present
    
 Scenario: Student can Check block "Personal and contact information" on error
    Given I leave block "Personal and contact information" empty
    And I leave field "Name" empty
    And I leave field "Surname" empty
    And I leave text field "Phone number" empty
    And I leave text field "Skype" empty
    And I leave text field "Linkedin" empty
    When I press "NEXT" button
    Then Text field "Name" is encircled red
    And Text field "Surname" is encircled red
    And Text field "Phone number" is encircled red
    And I stay in block "Personal and contact information"

Scenario Outline: Student check Countdown`s work
	When I write in "<field>" "<number>" of symbol
	Then Countdown number is "<countdown_number>"
	And Countdown is encircled red
	Examples:
    |option |field    |number   |countdown_number |
    |option1|Name     |26       |-1/25            |
    |option2|Surname  |27       |-2/25            |
    |option3|Skype    |33       |-3/30            |
    |option4|LinkedIn |151      |-1/150           |
	
Scenario: Student check language filter
	When I write "Абв" in field "Name"
	#were "Аб" written on the Russian keyboard layout and "в" on the Belorussian keyboard layout
	Then I see the written ""
  
#Scenario: Allowed symbols in fields
#Name : A-Z a-z . - ' space
#Surname : A-Z a-z . - ' space
#Phone number : 0-9
#Skype : A-Z a-z А-Я а-я 0-9 . , ? ! " ' : ; . – /
#LinkedIn : A-Z a-z !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ space
# https://www.owasp.org/index.php/Password_special_characters