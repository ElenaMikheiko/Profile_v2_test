#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43419573
#|Role     |name                     |surname              |e-mail                   |password      |phone number     |
#|student  |Oliver                   |Wilson               |wilsonoliver555@gmail.com|oliver123456  |+375 29 686 00 60|

Feature: 5.11 To fill in block "Additional information"
	In order to inform employer
	As authorized user
	I should have possibility to fill in block "Additional information"

Background:
	Given As unauthorised user I come to landing page of Profile
	And I log in as Additional1 Test
	And I open my personal menu
	And I select button "Resume"
	And I go to block "Additional information"

Scenario: Student checking resume block title of page
   Then I see resume block title "Additional information"
   And I see that tab name "Additional information" is active
   And I see placeholder text in field "Additional information"
   |TEXT                                                                                                  | 
   |Here you can write about your professional interests, hobby, civic activities, awards or volunteering |

Scenario: Student Saves information
    Given I filled all fields in "Additional information"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Additional information" is present

Scenario: Student check Countdown's work in block "Additional information"
    When I write in "Additional information" "1001" of symbol
	Then Countdown number is "-1/1000"
	And Countdown is encircled red
   	
Scenario: Student check language filter in block "Additional information"
	When I write "Абв" in field "Additional information"
	#were "Аб" written on the Russian keyboard layout and "в" on the Belorussian keyboard layout
	Then I see the written ""
  
#Scenario: Allowed symbols in fields in block "Additional information"
#Additional information A-Z a-z 0-9 !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
#https://www.owasp.org/index.php/Password_special_characters	

Scenario: Student can Check block "Additional information" on error
	Given I leave block "Additional information" empty
	When I press "NEXT" button
	Then I moved to block "Recommendations"