#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43417876
#list of users http://confluence.it-academy.by:8090/x/RwCxAg
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|student  |Kostia                   |Shtine               |smithivan.555@gmail.com |ivan123456    |+375 44 829 93 02|

Feature:  5.2 To fill in resume blocks
    In order to use completed resume later on
    As authorized user
    I should have possibility to fill in resume blocks

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Kostia Shtine
    And I open my personal menu
    And I select button "Resume"

 Scenario: Student is directed to editing resume page
    When I move to resume creation page
    Then I see Message 
    |Message                                                  |
    |Dear Kostia Shtine!                                      |
    |You will be offered to fill in your resume step by step. |
    |Our instructions will help you.                          |

 Scenario: Student starts to fill in resume
    When I move to resume creation page
    When I choose button "START"
    Then I go to block "Personal and contact information"
    
 Scenario: Student can cancel filling in resume
    When I choose button "START"
    Then I am on first tab and choose button "CANCEL"
    Then I'm on my personal page
