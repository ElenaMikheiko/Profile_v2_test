#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417897
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|student  |Emily                    |Tomas                |tomasemely555@gmail.com |emily123456   |+375 25 129 92 99|

Feature: 5.8 To fill in block "Work experience"
    In order to inform employer
    As authorized user
    I should have possibility to fill in block "Work experience"
 
 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Emily Tomas
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Work experience"

 Scenario: Student checking resume block title of page
    Then I see resume block title "Work experience"
    And I see notification "Mandatory field"
    And I see that tab name "Work experience" is active
    And I see text "To present"
    And I see text
    |text                                                                                      |
    |Here you can mention your work on the project while studying in Educational Center of High|
    |Technologies Park (IT Academy).                                                           |

 Scenario: Student Saves information
    Given I filled in selector "Start of work"#.month
    And I filled in selector "Start of work"#.year
    And I filled in selector "End of work"#.month
    And I filled in selector "End of work"#.year
    And I filled in field "Organization"
    And I filled in field "Position"
    And I filled in field "Responsibilities, tasks, activities"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Work experience" is present

 Scenario: Student Adds one more block "Places of work"
    When I press on button "Add an employer"
    Then I see new empty selector "Start of work"#.month
    And I see new empty selector "Start of work"#.year
    And I see new empty selector "End of work"#.month
    And I see new empty selector "End of work"#.year
    And I see new empty field "Organization"
    And I see new empty field "Position"
    And I see new empty field "Responsibilities, tasks, activities"

 Scenario: Student deletes added block "Places of work"
    Given I added one more block "Places of work"
    When I press button with cross
    Then Block "Places of work" is deleted
 
 Scenario: Student Moves to next page
    Given I filled in block "Work experience"
    When I press "NEXT" button
#Then Information is saved
    And I moved to "Portflio" block

 Scenario: Student can Check block "Work experience" on error
    Given I leave selector "Start of work"#.month
    And I leave selector "Start of work"#.year
    And I leave selector "End of work"#.month
    And I leave selector "End of work"#.year
    And I leave field "Responsibilities, tasks, activities" empty
    And I leave field "Position" empty
    And I leave field "Organization" empty
    When I press "NEXT" button
    Then Selector "Start of work" is encircled red #.month
    And Selector "Start of work" is encircled red #.year
    And Selector "End of work"is encircled red #.month
    And Selector "End of work"is encircled red #.year
    And Text field "Organization" is encircled red   
    And Text field "Position" is encircled red
    And Text field "Responsibilities, tasks, activities" is encircled red
    And I stay in block "Work experience"

 Scenario Outline: Student check Countdown`s work in block "Work experience"
    When i write in "<field>" "<number>" of symbol
    Then Countdown number is "<countdown_number>"
    And Countdown number is red
    Examples:
    |option |field                              |number|countdown_number |
    |option1|Organization                       |101   |-1/100           |
    |option2|Position                           |102   |-2/100           |
    |option3|Responsibilities, tasks, activities|1003  |-3/1000          |
	
 Scenario Outline: Student check language filter in block "Work experience"
    When I write "Абўі" in "<field>"
#Were "Аб" written on the Russian keyboard layout and "ўі" on the Belorussian keyboard layout
    Then I see the written ""
    Examples:
    |option |field                              |
    |option1|Organization                       |
    |option2|Position                           |
    |option3|Responsibilities, tasks, activities|
  
#Scenario: Allowed symbols in fields
#Organization: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Position: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Responsibilities, tasks, activities: A-Z a-z А-Я а-я 0-9 !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ space
#https://www.owasp.org/index.php/Password_special_characters

#Scenario: Student Checks list of months
#When I see drop-down lists in field "Start of work" and "End of work" #.month
#Then I see values from "<January>" to "<December>"

#Scenario: Student Checks list of years
#Then I can see year value within range + - 20 years from/to current year