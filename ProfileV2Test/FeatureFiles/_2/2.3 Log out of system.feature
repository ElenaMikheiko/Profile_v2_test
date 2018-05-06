Feature: 2.3 Sign out of system
I should have possibility to log out of system
As user
In order to keep my account in security
  
	
Scenario Outline:  Sign out of Profile system
	Given As unauthorized user I come to landing page of Profile
	And I login using my "<login>" and "<password>"
	And I open my personal menu
	When I click "Log Out" button
	Then I on landing page of profile
	#also system should clean cookie files and block access for unauthorized users.
	#this functional released with "ASP.NET Identity". And we should not test it.
	Examples:
	|option |login                |password   |
	|option1|admin@profile.com    |admin123   |
	|option2|student@profile.com  |student    |
	|option3|trainer@profile.com  |trainer    |
	|option4|hr@profile.com       |hmanager123|