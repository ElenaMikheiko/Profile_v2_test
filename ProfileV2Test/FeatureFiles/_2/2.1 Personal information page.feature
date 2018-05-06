# http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=42304580
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|student  |Ivan                     |Ivanov               |student@profile.com     |student       |+375 44 123 45 67|
#|hr       |Maria                    |Zaporoschenko        |hr@it-academy.by        |              |                 |
#|Admin    |                         |                     |admin@profile.com       |admin123      |                 |
#|trainer  |                         |                     |trainer@profile.com     |trainer       |                 |

Feature: 2.1 Personal information page
  In order other users can find my contacts.
  As authorized user I want to have personal information, including name, surname, phone, email, role, photo

  Background:
    Given As unauthorized user I come to landing page of Profile
    And User log in as user # |admin|hr|trainer|student|

  Scenario: Verification photo of users
    Then I see field for photo

  Scenario: Verification data about user from DB (reguired fields)
    Then I see my name
    And I see my surname
    And I see my role
    And I see my e-mail
    And I see my phone number

  Scenario: Verification data about trainee from DB (not reguired field)
    Then I see my skype                                                         
    And I see my Linkedin

  Scenario: Verification that user can log out
    When I go to personal menu
    And I see "Log out" button
    Then I exit from my account
    And I see landing page

  @ignore @UI
  Scenario: Verification icon on personal page
    Then I see icon e-mail
    And I see icon phone number
    And I see icon skype
    And I see icon Linkedin