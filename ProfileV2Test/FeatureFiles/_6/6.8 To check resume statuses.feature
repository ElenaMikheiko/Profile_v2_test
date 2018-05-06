#http://confluence.it-academy.by:8090/display/PROF/US+6.8+To+check+resume+statuses
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by        |              |                 |
#|student  |Kostia                   |Shtine               |smithivan.555@gmail.com |ivan123456    |+375 44 829 93 02|
#|student  |Brea                     |Breens			   |breabreens555@gmail.com |brea123456    |+375 25 784 55 66|
#|student  |Pavel                    |Submit               |breab.reens555@gmail.com|brea123456    |+375 44 575 00 50|

Feature:  To check resume statuses
  In order I can work with resumes
  As HR
  I should have possibility to check resume statuses

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I stay on HR's list of students

#Scenario: HR checks Value of resume statuses
#When I see table column "Resume status"
#Then I can see resume status "New"
#And I can see resume status "Submitted"
#And I can see resume status "Review"
#And I can see resume status "Approved"
#And I can see resume status "Recommended"
#And I can see resume status "Employed"
#And I can see resume status "Archive Employed"
#And I can see resume status "Archive Unemployed"
#And I can see resume status "Archive Didn't participate in the program"
#And I can see date of last resume status change in format "<hh:mm, dd.mm.yyyy>"

Scenario: HR Checks resume status New
Given Student Kostia Shtine has not subbmitted resume
Then I can see Student's resume status "New" "<hh:mm, dd.mm.yyyy>" in column "Resume status" on HR's list of students

Scenario: HR Checks resume status Submitted
Given Student Pavel Submit submitted resume
Then I can see Student's resume status "Submitted" "<hh:mm, dd.mm.yyyy>" in column "Resume status" on HR's list of students

#Scenario: HR Checks resume status Review
#Given Student Brea Breens submitted resume
#And I checked resume
#And I press button "Return resume"
#Then I can see resume status "Review" "<hh:mm, dd.mm.yyyy>" in column "Resume status" on HR's list of students

#Scenario: HR Checks resume status Approved
#Given Student Brea Breens submitted resume
#And I checked resume
#And I press button "Approve"
#Then I can see resume status "Approved" "<hh:mm, dd.mm.yyyy>" in column "Resume status" on HR's list of students

#Scenario: HR Checks resume status Recommended
#Given Student Brea Breens submitted resume
#And I filled in table column "Companies where recommended" 
#Or
#I sent Student's resume to company
#Then I see resume status "Recommended" "<hh:mm, dd.mm.yyyy>" in column "Resume status" on HR's list of students

#Scenario: HR Checks resume status Employed
#Given Student Brea Breens submitted resume
#And I filled in table column "Employer company"
#Then I can see resume status "Employed" "<hh:mm, dd.mm.yyyy>" in column "Resume status" on HR's list of students

#Scenario: HR Checks resume status Archive Employed
#Given Student Brea Breens submitted resume
#And I choose option "Archive Employed" in resume 
#Then I can see resume status "Archive Employed" "<hh:mm, dd.mm.yyyy>" in column "Resume status" on HR's list of students

#Scenario: HR Checks resume status Archive Unemployed
#Given Student Brea Breens submitted resume
#And I choose option "Archive Unemployed" in resume
#Then I can see resume status "Archive Unemployed" in column "Resume status" on HR's list of students

#Scenario: HR Checks resume status Archive Didn't participate in the program
#Given Student Kostia Shtine has not subbmitted resume
#And I choose option "Archive Didn't participate in the program" in resume
#Then I can see resume status "Archive Didn't participate in the program" "<hh:mm, dd.mm.yyyy>" in column "Resume status" on HR's list of students
