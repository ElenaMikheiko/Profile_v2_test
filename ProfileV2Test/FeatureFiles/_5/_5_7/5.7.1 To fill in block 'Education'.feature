#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417892
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|student  |Sveta                    |Evans                |evanssveta555@gmail.com |sveta123456   |+375 25 283 20 94|

 Feature: 5.7.1 To fill in block "Education"
    In order to inform employer
    As authorized user
    I should have possibility to fill in block "Education"

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Sveta Evans
    And I open my personal menu
    And I select button "Resume"
    And I am in block "Education"

 Scenario: Student checking resume block title of page part one
    Then I see resume block title "Education"
    And I see notification "Mandatory field"
    And I see text
    |Text                                                                                                   |
    |Here you can indicate the period of study in Educational Center of High Technologies Park (IT Academy).|

 Scenario: Student checking resume block title of page part two
    Then I see that tab name "Education" is active
    And I see hint text
    |Hint Text                                                             |
    |If you are currently studying — enter the expected year of graduation.|

 Scenario: Student adds more places of study
    When I press on button "Add one more place of study"
    Then I see new default field/selector Level with name "Bachelor"
    And I see new empty field "Name of educational institution"
    And I see new empty field "Department"
    And I see new empty field "Specialization"
    And I see new empty selector "Year of admission"
    And I see new empty selector "Year of graduation"

 Scenario: Student saves information
    Given I filled in field "Name of educational institution"
    And I filled in field "Department"
    And I filled in field "Specialization"
    And I filled in selector "Year of admission"
    And I filled in selector "Year of graduation"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Education" is present

 Scenario: Student deletes place about education
    Given I added places of study
    When I press on button with cross
    Then place of study is deleted

 Scenario: Student moves to next page
    Given I filled in block "Education"
    When I press "NEXT" button
#Information is saved
    Then I moved to block "Professional development, courses"

    Scenario: Student can Check block "Education" on error
    Given I leave field "Name of educational institution" empty
    And I leave field "Department" empty
    And I leave field "Specialization" empty
    And I leave selector "Year of admission" empty
    And I leave selector "Year of graduation" empty
    When I press "NEXT" button
    Then Text field "Name of educational institution" is encircled red
    And Text field "Department" is encircled red
    And Text field "Specialization" is encircled red
    And Selector "Year of admission" is encircled red
    And Selector "Year of graduation" is encircled red
    And I stay in block "Education"

 Scenario: Student checks values in drop-down list "Level"
    When I press on field "Level"
    Then drop-down list opens
    And I see value "Higher"
    And I see value "Bachelor"
    And I see value "Master"
    And I see value "Candidate of science"
    And I see value "Doctor of science"
    And I see value "Incomplete higher"
    And I see value "Vocational secondary"
    And I see value "Secondary"
    And I see value "another"

 Scenario Outline: Student check Countdown`s work
    When i write in "<field>" "<number>" of symbol
    Then Countdown number is "<countdown_number>"
    And Countdown number is red
    Examples:
    |option |field                          |number|countdown_number |
    |option1|Name of educational institution|101   |-1/100           |
    |option2|Department                     |102   |-2/100           |
    |option3|Specialization                 |103   |-3/100           |
	
 Scenario Outline: Student check language filter
    When I write "Абўі" in "<field>"
#Were "Аб" written on the Russian keyboard layout and "ўі" on the Belorussian keyboard layout
    Then I see the written ""
    Examples:
    |option |field                          |
    |option1|Name of educational institution|
    |option2|Department                     |
    |option3|Specialization                 |
  
#Scenario: Allowed symbols in fields
#Name of educational institution : A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Department: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Specialization: A-Z a-z 0-9 . , ? ! " ' : ; . – / space 

#Scenario: Student adds information about level of education
#When I press on field "Level"
#Then I can choose level of education from drop-down list

#Scenario: Student adds year of admission
#When I press on field "Year of admission"
#Then I can choose year from drop-down list

#Scenario: Student adds year of graduation
#When I press on field "Year of graduation"
#Then I can choose year from drop-down list

#Scenario: Student Checks list of year
#Then I can see year value within range + - 20 years from/to current year