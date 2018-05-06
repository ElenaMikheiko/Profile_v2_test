#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417895
#|Role     |name                     |surname              |e-mail                     |password      |phone number     |
#|student  |Victor                   |Willians             |williandvictor555@gmail.com|victor123456  |+375 33 504 99 39|

Feature: 5.6 To fill in block "Foreign languages"
    In order to inform employer
    As authorized user
    I have possibility to fill in block "Foreign languages"
  
Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Lang1 Test
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Foreign languages"

# The following test is commented out because it is INTEGRATIONAL
# Integrational tests expect certain values at the beginning
# and MODIFY them after run. Therefore, we cannot mix them up with 
# UNIT tests and should keep them in a separate FF.

#Scenario: Student checking resume block title of page
#    Then I see resume block title "Foreign languages"
#    And I see notification "Mandatory field"
#    And I see that tab name "Foreign languages" is active
#	And I see placeholder text in field "Languages, Proficiency"
#	| value   |
#	| English |
#	| ---     |

Scenario: Student Saves information

    Given I filled in block "Foreign languages"
    And I filled in field "Languages"
    And I filled in selector "Proficiency"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Foreign languages" is present

 Scenario: Student deletes added block "Language"
    Given I added one more block "Language"
    And I added proficiency level
    When I press button with cross 
    Then Block "Language" is deleted 

Scenario: Student checks list from field "Proficiency"
	Then I see values in the dropdown list
	| Values |
	|     ---   |
	|     A1 Elementary   |
	|     A2 Pre-Intermediate   |
	|     B1 Intermediate   |
	|     B2 Upper-Intermediate   |
	|     C1 Advanced   |
	|     C2 Proficiency   |
	|     Native   |
    
Scenario: Student can Check field "Proficiency" on error
    Given I left default value "---" in field "Proficiency"
    When I press "NEXT" button
    Then Text field "Proficiency" is encircled red
    And I stay in block "Foreign languages"
    
Scenario: Student moves to next page
    Given I filled all fields in "Foreign languages"
    When I choose to move to next page
#Information is saved
    Then I moved to block "Education"
    
#Scenario: Student can add more languages
#Then I can choose language from drop-down list
#And I can choose level from drop-down list
#Then I can add more languages