#http://confluence.it-academy.by:8090/display/PROF/US+6.14+To+export+a+resume+in+MS+Word
#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To export resume for HR
In order I can work with resume
As HR
I should have possibility to export resume in MS Word

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I stay on HR's list of students

#by default: check boxes are empty 
Scenario: HR selects lines
When I check the box in one or more lines
Then I see that selected lines are highlighted

Scenario: HR unselects lines
Given I check the box in one line
When I uncheck the box in this line
Then I see that line is not highlighted

Scenario: HR Exports one resume
Given I select one line in list of students
When I press "Export resume" button
Then Word file is downloaded to my computer
And file's title is "<Name Surname>" equal to selected line

Scenario: HR Exports two resumes
Given I select two or more lines in list of students
When I press "Export resume" button
Then archive with two Word files is downloaded to my computer
And archive's title is date of export in format "<dd-mm-yyyy>"
And files' title is "<Name_Surname>" equal to selected lines