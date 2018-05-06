#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417839
#|Role     |name                     |surname              |e-mail                   |password      |phone number     |
#|student  |Nikola                   |Brown                |brownnikola555@gmail.com |nikola123456  |+375 44 875 66 55|

Feature: 5.4 To fill in block "Summary"
    In order to inform employer
    As authorized user
    I should have possibility to fill in block "Summary"

Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Summary1 Test
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Summary"

Scenario: Student checking resume block title of page
    Then I see resume block title "Summary"
    And I see notification "Mandatory field"
    And I see that tab name "Summary" is active
	And I see placeholder text in field "Summary"
    |Text|
    |Here you can write a brief information about yourself, your personal qualities that could help in the professional implementation. Write how you can be useful for your future employer.|
    
Scenario: Student Saves information
    Given I filled all fields in "Summary"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Summary" is present

Scenario: Student can Check block "Summary" on error 
	Given I leave block "Summary" empty
	When I press "NEXT" button
	Then Text field "Summary" is encircled red
	And I stay in block "Summary"

Scenario: Student Moves to next page
	Given I filled all fields in "Summary"
	When I choose to move to next page
	# information is saved
	Then I moved to block "Skills"

Scenario: Student check Countdown`s work
	When I write in "Summary" "1001" of symbol
	Then Countdown number is "-1/1000"
	And Countdown is encircled red
   	
Scenario: Student check language filter
	When I write "Абв" in field "Summary"
	#were "Аб" written on the Russian keyboard layout and "в" on the Belorussian keyboard layout
	Then I see the written ""
  
#Scenario: Allowed symbols in fields
#Summary A-Z a-z !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ space
#https://www.owasp.org/index.php/Password_special_characters