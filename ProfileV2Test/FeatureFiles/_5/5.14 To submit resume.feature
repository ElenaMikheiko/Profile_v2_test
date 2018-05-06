#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43419615
#|Role     |name                     |surname              |e-mail                    |password      |phone number     |
#|student  |Submit1                  |Test				   |submit1test@gmail.com	  |s1t123456	 |+375 44 575 00 50|
#|student  |Submit2                  |Test				   |submit2test@gmail.com	  |s2t123456	 |+375 44 575 00 50|

 Feature:  5.14 To submit resume
    In order HR can check my resume
    As authorized user
    I should have possibility to submit my resume

Background:
	Given As unauthorised user I come to landing page of Profile

Scenario: Student sees notification
	Given I log in as Submit1 Test
	And I open my personal menu
	And I select button "Resume"
	And I am on completed resume page
	When I press button "SUBMIT"
	Then I see pop-up message
	|message text                                                                                  |
	|You're at the finish line! Please note that after submission the resume is closed for editing.|
	|When HR approves your resume, you’ll be informed by e-mail. If HR has comments on your resume,|
	|you’ll also be informed and resume will be returned to you for correction.                    |
	And I see button "OK"
	And I see button "CANCEL"
  
Scenario: Student Submits resume
	Given I log in as Submit2 Test
	And I open my personal menu
	And I select button "Resume"
	And I am on completed resume page
	When I press button "SUBMIT"
	And I press button "OK" on pop-up message
	#Then my resume is saved in system database
	#And HR receives notification 6.13.1 To receive notification email 'New resume submitted' for HR.feature 
	Then I moved to my personal page
	And I open my personal menu
	And I select button "Resume"
	Then I see my completed resume
	And I cannot edit it

Scenario: Student cancels submission of resume
	Given I log in as Submit1 Test
	And I open my personal menu
	And I select button "Resume"
	And I am on completed resume page
	When I press button "SUBMIT"
	And I press button "CANCEL" on pop-up message
	Then I am on completed resume page
	
