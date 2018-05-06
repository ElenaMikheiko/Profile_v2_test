#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417825
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|student  |Lena                     |Taylor               |taylorlena5555@gmail.com|lena123456    |+375 29 314 88 10|

 Feature: 5.7.3 To fill in block "Electronic certificates, tests, examinations"
    In order to inform employer
    As authorized user
    I should have possibility to fill in block "Electronic certificates, tests, examinations"

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Lena Taylor
    And I open my personal menu
    And I select button "Resume"
    And I am on block "Electronic certificates, tests, examinations"

 Scenario: Student checking resume block title of page
    Then I see resume block title "Electronic certificates"
    And I see resume block title "Tests, examinations"
    And I see that tab name "Electronic certificates, tests, exams" is active
    And I see hint text near selector "Year of graduation"
    |text                                                                   |
    |If you are currently studying — enter the expected year of attestation.|
		
 Scenario: Student Saves information in "Electronic certificates" block
    Given I filled in field "Responsible organization"
    And I filled in field "Certificate title"
    And I filled in selector "Year of attestation"
    And I filled in field "Add a link to the certificate"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Electronic certificates" is present
	
 Scenario: Student Saves information in "Tests, examinations" block
    Given I filled in field "Responsible organization"
    And I filled in field "Test, examination title"
    And I filled in selector "Year of attestation"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Tests, examinations" is present

 Scenario: Student adds one more block "Electronic certificates"
    When I press on button "Add one more certificate"
    Then I see new empty field "Responsible Organization"
    And I see new empty field "Certificate title"
    And I see new empty selector "Year of attestation"
    And I see new empty field "Add a link to the certificate"

 Scenario: Student deletes added block "Electronic certificates"
    Given I added one more block "Electronic certificates"
    When I press on button with cross
    Then Block "Electronic certificates" is deleted

 Scenario: Student adds one more block "Tests, examinations"
    When I press on button "Add one more test or exam"
    Then I see new empty field "Responsible Organization"
    And I see new empty field "Test, examination title"
    And I see new empty selector "Year of attestation"

 Scenario: Student deletes added block "Tests, examinations"
    Given I added one more block "Tests, examinations"
    When I press on button with cross
    Then Block "Tests, examinations" is deleted  

 Scenario: Student Moves to next page
    Given I filled in block "Electronic certificates, tests, exams"
    When I press "NEXT" button
    #Information is saved
    Then I moved to block "Work experience"

 Scenario Outline: Student check Countdown`s work in block
    When i write in "<field>" "<number>" of symbol
    Then Countdown number is "<countdown_number>"
    And Countdown number is red
    Examples:
    |option |field                          |number|countdown_number |
    |option1|Responsible organization       |101   |-1/100           |
    |option2|Certificate title              |102   |-2/100           |
    |option3|Responsible Organization       |103   |-3/100           |
    |option4|Test, examination title        |104   |-4/100           |
	
 Scenario Outline: Student check language filter in block
    When I write "Абў" in "<field>"
    #Were "Аб" written on the Russian keyboard layout and "ў" on the Belorussian keyboard layout
    Then I see the written ""
    Examples:
    |option |field                   |
    |option1|Responsible organization|
    |option2|Certificate title       |
    |option3|Responsible Organization|
    |option4|Test, examination title |
  
#Scenario: Allowed symbols in fields
#Responsible organization: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Certificate title: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Responsible Organization: A-Z a-z 0-9 . , ? ! " ' : ; . – / space 
#Test, examination title: A-Z a-z 0-9 . , ? ! " ' : ; . – / space 
#Add a link to the certificate: A-Z a-z А-Я а-я 0-9 !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ space
#https://www.owasp.org/index.php/Password_special_characters

#Scenario: Student Checks list of years
#Then I see value within range from "<current_year>" - 20 years to "<current_year>" + 20 years 