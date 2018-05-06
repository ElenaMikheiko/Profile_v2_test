#http://confluence.it-academy.by:8090/display/PROF/US+6.10+To+indicate+Student+is+looking+for+job

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |


Feature:  To indicate Student is looking for job
  In order I can see the status while working with resumes
  As HR
  I should have possibility to indicate Student is looking for job

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I stay on home page

Scenario: HR Checks possibility to choose option in column "Looking for job"
 Then I can choose option in column "Looking for job"

Scenario: HR Checks default data in "Looking for job" table cells
 When I see table column "Looking for job"
 Then I can see slider button is inactive by default
 And I can make it active

Scenario: HR Chooses option in table column "Looking for a job"
 When I see table column "Looking for a job"
 Then I can change option of slider button

Scenario Outline: HR chooses Slider button option meaning in table column "Looking for a job"
 When slider button in table column "Looking for a job" is "<state>"
 Then option meaning is "<meaning>"
    Examples:
     |option |state    |meaning                       |
     |option1|active   |Student is looking for job    |
     |option2|inactive |Student is not looking for job|
