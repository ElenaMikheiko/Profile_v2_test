#http://confluence.it-academy.by:8090/display/PROF/US+6.1+To+see+default+list+of+Students

Feature: 6.1 To see default list of Students
In order I can work in my account
As HR
I should have possibility to see list of Students

Background:
	Given As unauthorised user I come to landing page of Profile
	And I log in as HR
	And I see page HR's list of students

Scenario: View list of student's  at HR's list of students page
	Then I can see Student's id number at column with header "№"
	And I can see column with header "Choose"
	And I can see Student's Stream at column with header "Stream"
	And I can see Student's Name.rus at column with header "Name rus"
	And I can see Student's Surname.rus at column with header "Surname rus"
	And I can see Student's Date of birth at column with header "Date of birth"
	And I can see Student's e-mail at column with header "E-mail"
	And I can see Student's Phone at column with header "Phone"
	# Phone format +375 xx xxx xx xx
	And I can see Student's Trainer at column with header "Trainer"
	## trainer's email
	And I can see Student's Date of graduate at column with header "Date of graduate"
	And I can see Student's final score at column with header "Final score"
	And I can see column with header "Companies where recommended"
	And I can see column with header "Employer company"
	And I can see column with header "Recommendaton/Employment date"
	And I can see column with header "Resume status"
	And I can see column with header "Comments"
	And I can see column with header "Education"
	And I can see column with header "Language"
	And I can see column with header "Language level"
	And I can see column with header "Skills"
	And I can see column with header "Looking for a job"