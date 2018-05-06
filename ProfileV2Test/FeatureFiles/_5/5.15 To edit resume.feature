#http://confluence.it-academy.by:8090/display/PROF/US+5.15+To+edit+resume
#|Role   |name|surname|e-mail                 |password  |phone number     |
#|student|Brea|Breens |breabreens555@gmail.com|brea123456|+375 25 784 55 66|

 Feature:  5.15 To edit resume
    In order I can correct mistakes or add something
    As authorized user
    I should have possibility to edit my resume

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Brea Breens
    And I open my personal menu
    And I select button "Resume"
    And I am on completed resume page

 Scenario: Student moves to edit resume page
    When I press button "EDIT" on completed resume page
    Then I moved to edit resume page

 Scenario: Student changes data and save changes
    Given I write "Ivan" in field "Name"
    And I write "Ivanov" in field "Surname"
    When I press "PREVIEW" button
    Then I see my name and surname equal "Ivan Ivanov"

#Scenario: Student can edit resume
#When I press button "EDIT" on completed resume page
#Then I can edit information in text fields
 
#Scenario: Student can see "PREVIEW" button
#Given I made changes in resume
#When I press on "PREVIEW" button
#Then Information is saved
#And I see my completed resume

#Scenario: Student can see "BACK" button
#Given I made changes in resume
#When I choose to move to previous page
#Then Information is not saved
#And I see my completed resume

#Scenario: Student Edits block "Personal and contact information"
#When I choose to edit block "Personal and contact information"
#Then I can edit information in field "Name"
#And I can edit information in field "Surname"
#And I can edit information in field "Skype"
#And I can edit information in field "LinkedIn"

#Scenario: Student Edits block "Objective"
#When I choose to edit block "Objective"
#Then I can edit information in block "Objective"

#Scenario: Student Edits block "Summary"
#When I choose to edit block "Summary"
#Then I can edit information in block "Summary"

#Scenario: Student Edits block "Skills"
#When I choose to edit block "Skills"
#Then I can edit information in block "Skills"

#Scenario: Student Edits block "Foreign languages"
#When I choose to edit block "Foreign languages"
#Then I can edit information in field "Languages"
#And I can edit information in field "Proficiency"

#Scenario: Student Edits block "Education"
#When I choose to edit  block "Education"
#Then I can edit information in field "Level"
#And I can edit information in field "Name of educational institution"
#And I can edit information in field "Department"
#And I can edit information in field "Specialization"
#And I can edit information in field "Year of admission"
#And I can edit information in field "Year of graduation"

#Scenario: Student Edits block "Professional development, courses"
#When I choose to edit block "Professional development, courses"
#Then I can edit information in field "Responsible organization"
#And I can edit information in field "Specialization"
#And I can edit information in field "Year of graduation"

#Scenario: Student Edits block "Electronic certificates, tests, examinations"
#When I choose to edit block "Electronic certificates, tests, examinations"
#Then I can edit information in field "Responsible organization"
#And I can edit information in field "Certificate title"
#And I can edit information in field "Add a link to the certificate"
#And I can edit information in field "Test, examination title"

#Scenario: Student Edits block "Work experience"
#When I choose to edit block "Work experience"
#Then I can edit information in field "Start of work"
#And I can edit information in field "End of work"
#And I can edit information in field "Organization"
#And I can edit information in field "Position"
#And I can edit information in field "Responsibilities, tasks, activities"

#Scenario: Student Edits block "Portfolio"
#When I choose to edit block "Portfolio"
#Then I can edit information in field "Add a link"

#Scenario: Student Edits block "Military status"
#When I choose to edit block "Military status"
#Then I can edit information in block "Military status"

#Scenario: Student Edits block "Additional information"
#When I choose to edit block "Additional information"
#Then I can edit information in block "Additional information"

#Scenario: Student Edits block "Recommendations"
#When I choose to edit block "Recommendations"
#Then I can edit information in field "Name Surname"
#And I can edit information in field "Company/Position"
#And I can edit information in field "Contacts/Link"
