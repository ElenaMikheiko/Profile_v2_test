#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43427468
#|Role     |name                     |surname              |e-mail                    |password      |phone number     |
#|student  |Brea                     |Breens			   |breabreens555@gmail.com   |brea123456    |+375 25 784 55 66|

Feature:  5.18.2 To receive notification e-mail "Comments on resume"
  In order I can know news about my resume
  As authorized user
  I should have possibility to receive notification e-mail "Comments on resume"

Background:
    Given I submitted my resume to HR
    And HR checked my resume
    And HR commented on my resume
    And HR sent comments on my resume

Scenario: Student receives e-mail informing about resume comments
    When I receive e-mail with header "Feedback on your resume"
    Then I see text
    |Text                                                                |
    |Dear <Name><Surname>!                                               |
    |You have just received feedback on your resume in Profile account.  |
    |You can see HR's comments following the link #link to resume#.      |
    |You can also find comments in Resume menu in your Profile account.  |
    |Best regards,                                                       |
    |Educational Center of HTP                                           |
    |#link to Profile#                                                   |
