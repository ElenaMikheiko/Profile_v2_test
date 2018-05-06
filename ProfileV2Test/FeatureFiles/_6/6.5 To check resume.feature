#http://confluence.it-academy.by:8090/display/PROF/US+6.5+To+check+a+resume

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature: To check resume
  In order I can correct resume
  As HR
  I should have possibility to check resume

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I see page HR's list of students
And I opened Student's resume

Scenario: HR Sees hint
 Then I can see hint text
 |TEXT                                                                    |
 |To add a comment to a resume block please click on a resume block title.|

Scenario: HR Types text
 When I click on resume title
 Then I can type text in field under resume block
 And text color is red

  Scenario: HR checks language filter
  When I write "Абв" in input field under resume block
  #were "Аб" written on Russian keyboard layout and "в" on Belarussian keyboard layout
  Then I see written "Абв"

#Scenario: Allowed symbols in fields
#Input field under resume block: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space

Scenario: HR Saves text
 Given I type text in field under resume block
 When I press on button with tick
 Then Information is saved

#comment for one resume block
Scenario: HR Deletes text
 Given I type text in field under resume block
 When I press button with cross 
 Then I text in resume block is deleted

Scenario: HR Chooses option
 When I click on resume title
 Then I can choose option in resume block

Scenario: HR Edits resume
 Then I can edit resume
 And I can edit resume block "Personal and contact information"
 And I can edit resume block "Objective"
 And I can edit resume block "Summary"
 And I can edit resume block "Skills"
 And I can edit resume block "Foreign languages"
 And I can edit resume block "Education"
 And I can edit resume block "Professional development, courses"
 And I can edit resume block "Electronic certificates, tests, examinations"
 And I can edit resume block "Work experience"
 And I can edit resume block "Portfolio"
 And I can edit resume block "Military status"
 And I can edit resume block "Additional information"
 And I can edit resume block "Recommendations"

Scenario: HR Chooses value in field "Education"
When I see radio buttons in field "Education"
Then I can choose value "Technical"
And I can choose value "Non-technical"

Scenario: HR Chooses value in field "Archive"
When I see radio buttons in field ""Archive"
Then I can choose value "Employed"
And I can choose value "Unemployed"
And I can choose value "Didn't participate in the program"

Scenario: HR sets Student's resume status "Archive Employed"
When I choose value "Employed" in field ""Archive"
Then Student's resume status = "Archive Employed"

Scenario: HR sets Student's resume status "Archive Unemployed"
When I choose value "Unemployed" in field ""Archive"
Then Student's resume status = "Archive Unemployed"

Scenario: HR sets Student's resume status "Archive Didn't participate in the program"
When I choose value "Didn't participate in the program" in field ""Archive"
Then Student's resume status = "Archive Didn't participate in the program"

Scenario: HR Hides comment on resume
 When I approve resume by clicking button "APPROVE"
 Then comments on resume are hidden

Scenario: HR sets resume status "Approved"
 When I press on "APPROVE" button
 Then resume status = "Approved"

Scenario: HR sets resume status "REVIEW"
 Given I wrote comments on Student's resume
 When I press on "RETURN RESUME" button
 Then comments are sent to Student by e-mail
 And Student receives notification #5.18.2 To receive notification e-mail Comments on resume.feature
 And resume status = "Review"

#Scenario: HR Moves to previous page
#When I press button "BACK"
#Then I move to previously opened page

#comment for the whole resume
Scenario: HR Deletes comment for HR
Given I wrote comment for HR
When I click button with cross
Then my comment for HR is deleted