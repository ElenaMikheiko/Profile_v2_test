#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43424262

#|Role     |name                     |surname              |e-mail                 |password      |phone number     |stream(import table)|stream name      |
#|student  |Pavel                    |Jones                |jonespavel555@gmail.com|pavel123456   |+375 44 575 00 50|ND                  |ASP.NET Developer|

Feature: 5.16 To fill in block "Objective"
    In order to inform employer
    As Student
    I can fill in the block "Objective"

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Objective1 Test
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Objective"

Scenario: Student checking resume block title of page
	Then I see resume block title "Objective"
	And I see that tab name "Objective" is active
	And I see text line "I am applying for a position of ASP.NET Developer."  
	#list of streams http://confluence.it-academy.by:8090/x/f4Dr

Scenario: Student Moves to next page
	When I press "NEXT" button
	#Then information is saved
	Then I moved to block "Summary"


#Scenario: Student Saves information
#Given I filled in field "Objective"
#When I press "NEXT" button
#And I press "BACK" button
#Then I can see data "Objective" is present

#Scenario: Student can Check block "Objective" on error
#Given I leave block "Objective" empty
#And I leave field "Objective" empty
#When I press "NEXT" button
#Then Text field "Objective" is encircled red
#And I stay in block "Objective"

#Scenario: Student sees his stream
#Given I have one stream in database
#Then I can see my default stream

#Scenario: Student Chooses stream
#Given I have several streams in database
#Then I can choose stream from drop-down list
