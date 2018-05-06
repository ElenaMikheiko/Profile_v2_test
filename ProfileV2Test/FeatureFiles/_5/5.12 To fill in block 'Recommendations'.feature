#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43419563
#|Role   |name|surname |e-mail                   |password  |phone number     |
#|student|Jack|Daniel's|danielsjack5555@gmail.com|jack123456|+375 25 384 75 29|

 Feature: 5.12 To fill in block "Recommendations"
    In order to inform an employer
    As authorized user
    I should have possibility to fill in block "Recommendations"

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Jack Daniel's
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Recommendations"

 Scenario: Student Checks resume block title of page
    Then I see resume block title "Recommendations"
    And I see notification "Add contacts of a person who can give a recommendation"
    And I see that tab name "Recommendations" is active
    And I see placeholder text in input field "Contacts/Link"
    |Placeholder  text                                                                          |
    |Here you can add contacts (phone, email, skype, etc) or a link for a recommendation letter.|

 Scenario: Student Saves information
    Given I filled in block "Recommendations"
    And I filled in field "Name Surname"
    And I filled in field "Company/Position"
    And I filled in field "Contacts/Link"	
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Recommendations" is present

 Scenario: Student can Check block "Recommendations" on error
    Given I leave block "Recommendations" empty
    And I leave field "Name Surname" empty
    And I leave field "Company/Position" empty
    And I leave field "Contacts/Link" empty
    When I press "NEXT" button
    Then I go to page with NOTIFICATION
    |NOTIFICATION                                  |
    |Congratulations!                              |
    |You have just finished to fill in your resume.|
    |Please check you resume                       |
    |before you submit it to our HR.               |
    And I see button "Check" #(US 5.13 To submit resume)

        
 Scenario: Student Adds more contacts
    When I press button "Add one more person"
    Then I see new empty field "Name Surname"
    And I see new empty field "Company/Position"
    And I see new empty field "Contacts/Link"

 Scenario: Student Deletes added one more block "Contacts"
    Given I added one more block "Contacts"
    When I press button with cross
    Then Block "Contacts" is deleted
 
 Scenario Outline: Student check Countdown`s work in block "Electronic certificates, tests, examinations"
    When i write in "<field>" "<number>" of symbol
    Then Countdown number is "<countdown_number>"
    And Countdown number is red
    Examples:
    |option |field            |number|countdown_number|
    |option1|Name Surname     |101   |-1/100          |
    |option2|Company/Position |102   |-2/100          |
   	
 Scenario Outline: Student check language filter in block "Electronic certificates, tests, examinations"
    When I write "Абўі" in "<field>"
#Were "Аб" written on the Russian keyboard layout and "ўі" on the Belorussian keyboard layout
    Then I see the written ""
    Examples:
    |option |field           |
    |option1|Name Surname    |
    |option2|Company/Position|
    |option3|Contacts/Link   |
	  
#Scenario: Allowed symbols in fields
#Name Surname: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Company/Position: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Contacts/Link: A-Z a-z А-Я а-я 0-9 !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ space
#https://www.owasp.org/index.php/Password_special_characters