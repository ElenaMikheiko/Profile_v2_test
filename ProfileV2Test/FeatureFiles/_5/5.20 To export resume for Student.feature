#http://confluence.it-academy.by:8090/display/PROF/US+5.20+To+export+resume+for+Student
#|Role     |name                     |surname              |e-mail                    |password      |phone number     |
#|student  |Brea                     |Breens			   |breabreens555@gmail.com   |brea123456    |+375 25 784 55 66|

Feature: 5.20 To export a resume in MS Word
In order I can work with resume
As Student
I should have possibility to export resume in MS Word

Background:
  Given As unauthorised user I come to landing page of Profile
  And I log in as Brea Breens
  And I filled in all resume blocks
  And I am on completed resume page

Scenario: Student Exports resume
When I press "EXPORT" button
Then Word file is downloaded to my computer
And file's title is "<Name_Surname>" from my resume