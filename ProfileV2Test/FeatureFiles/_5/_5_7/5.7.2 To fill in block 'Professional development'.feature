#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417820
#|Role     |name                     |surname              |e-mail                   |password      |phone number     |
#|student  |Nadejda                  |Moore                |moorenadejda555@gmail.com|nadejda123456 |+375 44 203 94 48|

 Feature: 5.7.2 To fill in block "Professional development, courses"
    In order to inform employer
    As authorized user
    I should have possibility to fill in block "Professional development, courses"

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Nadejda Moore
    And I open my personal menu
    And I select button "Resume"
    And I am on block "Professional development, courses"

 Scenario: Student checks elements of block
    Then I see resume block title "Professional development, courses"
    And I see that tab name "Professional development, courses" is active
    And I see hint text near selector "Year of graduation"
    |text                                                                  |
    |If you are currently studying — enter the expected year of graduation.|
  
 Scenario: Student saves information 
    Given I filled in field "Responsible Organization"
    And I filled in field "Specialization"
    And I filled in selector "Year of graduation"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Professional development, courses" is present
    
 Scenario: Student adds more places of study
    When I press button "Add one more professional development course or other courses"
    Then I see new empty field "Responsible Organization"
    And I see new empty field "Specialization"
    And I see new empty selector "Year of graduation"

 Scenario: Student deletes block "Places of study"
    Given I added one more block "Places of study"
    When I press button with cross
    Then Block "Places of study" is deleted

 Scenario: Student moves to next page
    Given I filled in field "Professional development, courses"
    When I press "NEXT" button
    #Information is saved 
    Then I moved to block "Electronic certificates, tests, examinations"
	
 Scenario Outline: Student check Countdown`s work in block
    When i write in "<field>" "<number>" of symbol
    Then Countdown number is "<countdown_number>"
    And Countdown number is red
    Examples:
    |option |field                   |number|countdown_number|
    |option1|Responsible Organization|101   |-1/100          |
    |option2|Specialization          |102   |-2/100          |
	
 Scenario Outline: Student check language filter in block
    When I write "Абўі" in field "<field>"
    #Were "Аб" written on the Russian keyboard layout and "ўі" on the Belorussian keyboard layout
    Then I see the written ""
    Examples:
    |option |field                   |
    |option1|Responsible Organization|
    |option2|Specialization          |
  
#Scenario: Allowed symbols in fields in block
#Responsible Organization: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Specialization: A-Z a-z 0-9 . , ? ! " ' : ; . – / space

#Scenario: Student checks list of years
#Then I can see year value within range + - 20 years from/to current year