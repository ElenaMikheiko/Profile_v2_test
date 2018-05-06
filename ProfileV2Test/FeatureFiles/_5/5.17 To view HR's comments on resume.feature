#http://confluence.it-academy.by:8090/display/PROF/US+5.17+To+view+HR%27s+comments+on+resume
#|Role     |name                     |surname              |e-mail                    |password      |phone number     |
#|student  |Brea                     |Breens			   |breabreens555@gmail.com   |brea123456    |+375 25 784 55 66|

 Feature:  5.17 To view HR's comments on resume
    In order I can correct mistakes or add something
    As authorized user
    I should have possibility to view HR's comments on my resume

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Brea Breens
    And I open my personal menu
    And I select button "Resume"
    And I filled in all resume blocks
    And I submitted my resume
    And I have comments on my resume

 Scenario: Student sees HR's Comments text color
    When I see HR's comments on resume
    Then I see text color is red
  
@ignore
 Scenario: Student sees HR's comments from e-mail
    Given I received e-mail informing me about HR's comments on my resume
    When I press link from e-mail
    Then I see linked page
    And I can see HR's comments on resume

@ignore
 Scenario: Student sees HR's comments in Profile
    When I choose to go to resume page in personal menu
    Then I see my completed resume
    And I can see HR's comments on resume

@ignore
 Scenario: Students sees HR's comments hidden
    Given I corrected my resume
    When I submit it to HR
    Then I see HR's comments are hidden for me