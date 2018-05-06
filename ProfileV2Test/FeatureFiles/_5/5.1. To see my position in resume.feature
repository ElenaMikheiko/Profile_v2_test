#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417818
#|Role   |name|surname|e-mail             |password|phone number     |
#|student|Ivan|Ivanov |student@profile.com|student |+375 44 123 45 67|

 Feature: 5.1 To see my position in resume
    In order I know what is left for filling in in my resume
    As authorized user
    I should have possibility to see my position in resume

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Student
    And I open my personal menu
    And I select option to fill in resume
    And I start filling in my resume

 Scenario: Student can see order of items in status bar when he fills in resume
    Then I see that tab names are in the specific order
    |item name                             |n    |
    |Personal and contact information      |1    |
    |Objective                             |2    |
    |Summary                               |3    |
    |Skills                                |4    |
    |Foreign languages                     |5    |
    |Education                             |6    |
    |Professional development, courses     |7    |
    |Electronic certificates, tests, exams |8    |
    |Work experience                       |9    |
    |Portfolio                             |10   |
    |Military status                       |11   |
    |Additional information                |12   |
    |Recommendations                       |13   |

#Scenario: colored box when he fills in resume
#When I stay on particular resume block
#Then its corresponding box on status bar is colored
#This Scenario will be tested at every single block's FF